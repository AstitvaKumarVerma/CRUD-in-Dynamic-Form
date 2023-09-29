import { Component, ErrorHandler } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-account-holder-form',
  templateUrl: './account-holder-form.component.html',
  styleUrls: ['./account-holder-form.component.css']
})
export class AccountHolderFormComponent {
  NomineeForm!: FormGroup;
  addNominee: boolean = false;
  selected!: number;
  accountholderId!: number;
  data: any

  ageOptions: number[] = [];

  constructor(private serviceCall: ApiService, private formbuilder: FormBuilder, private router: Router, private routes: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.routes.queryParams.subscribe(params => {
      this.accountholderId = + params['id'];
    })

    this.initializeAgeOptions();

    this.NomineeForm = this.formbuilder.group({
      accountholderId: new FormControl(this.accountholderId),
      accountholderName: new FormControl('', [Validators.required]),
      accountType: new FormControl('', Validators.required),
      accountNumber: new FormControl('', [Validators.required]),
      nominees: this.formbuilder.array([]),
    });

    if (this.accountholderId > 0) {
      this.getById();
    }
    else {
      this.addRowItem(0)
    }
  }

  ArrayItem(index: number) {
    return this.formbuilder.group
      ({
        nomineeId: new FormControl(0),
        nomineeName: new FormControl('', Validators.required),
        nomineeAge: ['', [Validators.required]],
        addressType: ['', [Validators.required]],
        address: ['', [Validators.required]],
      });
  }

  get details() {
    return this.NomineeForm.get('nominees') as FormArray;
  }

  initializeAgeOptions() {
    // Initialize age options from 40 to 50
    for (let i = 40; i <= 50; i++) {
      this.ageOptions.push(i);
    }
  }

  getById() {
    this.serviceCall.GetAccountHolderbyId(this.accountholderId).subscribe((response: any) => {
      this.data = response.accounHolderData;
      this.NomineeForm.patchValue(this.data);
      console.warn('this.data Response=> ', this.data);
    })
  }

  addRowItem(index: number) {
    const control = <FormArray>this.NomineeForm.controls['nominees'];
    control.push(this.ArrayItem(index));

    if (this.accountholderId > 0) {
      let listArray = this.NomineeForm.get('nominees') as FormArray;
      listArray.controls[index].patchValue({ "nomineeId": this.data.nominees[index].nomineeId })
      listArray.controls[index].patchValue({ "nomineeName": this.data.nominees[index].nomineeName });
      listArray.controls[index].patchValue({ "nomineeAge": this.data.nominees[index].nomineeAge });
      listArray.controls[index].patchValue({ "addressType": this.data.nominees[index].addressType });
      listArray.controls[index].patchValue({ "address": this.data.nominees[index].address });
    }
  }

  removeRowItem(index: number) {
    if (index > 0) {
      const control = <FormArray>this.NomineeForm.controls['nominees'];
      control.removeAt(index);

      if (confirm("Are you sure to remove ?")) {
        this.serviceCall.DeleteNomineeDetailsById(this.data.nominees[index].nomineeId).subscribe((response: any) => {
          console.log('response', response);
        });
      }
    }
  }

  AddNominee() {
    this.addNominee = true;

    for (let i = 0; i < this.data.nominees.length; i++) {
      this.addRowItem(i);
    }
  }

  cancel() {
    this.router.navigate(['']);
  }

  onFormSubmit(val: any) {
    console.log(val);

    if (this.NomineeForm.value.accountholderId) {

      const formValueForEdit = this.NomineeForm.value
      console.warn('formValueForEdit=> ', formValueForEdit)

      this.serviceCall.UpdateAccountHolderDetails(formValueForEdit).subscribe((response: any) => {
        alert('Update Succesfully');
        this.router.navigate(['']);
      })
    }
    else {
      this.serviceCall.AddAccountHolderDetails(this.NomineeForm.value).subscribe((response: any) => {
        alert('Add Successfully.');
        this.router.navigate(['']);
      });
    }
  }
}
