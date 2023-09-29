import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { AccountHolderFormComponent } from '../account-holder-form/account-holder-form.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent {
  data: any;

  constructor(private serviceCall: ApiService, private dialog:MatDialog,private router:Router){

  }

  ngOnInit(){
    this.GetAllAccountHolderList();
  }

  GetAllAccountHolderList(){
    this.serviceCall.GetAllAccountHolderList().subscribe((response:any) => {
      console.log('response=> ', response);
      this.data = response;  
    })
  }

  sendData(Id: any){
    this.router.navigate(['add'], {queryParams: {id: Id}})
  }

  add(){
    this.router.navigate(['add']);
  }

  DeleteById(Id: any){
    this.serviceCall.DeleteAccountHolderDetailsById(Id).subscribe((response: any) => {
      alert('Delete Succesfully');
      this.GetAllAccountHolderList();
      this.router.navigate(['']);
    })
  }
}
