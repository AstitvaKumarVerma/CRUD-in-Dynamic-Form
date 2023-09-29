import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  GetAllAccountHolderList(){
    return this.http.get<any>('https://localhost:7232/api/AccountHolder/GetAllAccountHolderList');
  }

  GetAccountHolderbyId(Id: any){
    return this.http.get<any>('https://localhost:7232/api/AccountHolder/GetAllAccountHolderbyId?AccountHolderId='+Id);
  }

  AddAccountHolderDetails(data: any){
    return this.http.post<any>('https://localhost:7232/api/AccountHolder/AddAccountHolderDetails',data);
  }

  UpdateAccountHolderDetails(data: any){
    return this.http.put<any>('https://localhost:7232/api/AccountHolder/UpdateAccountHolderDetails',data);
  }

  DeleteAccountHolderDetailsById(Id: any){
    return this.http.delete('https://localhost:7232/api/AccountHolder/DeleteAccountHolderDetailsById?AccountHolderId='+Id);
  }

  DeleteNomineeDetailsById(Id: any){
    return this.http.delete('https://localhost:7232/api/AccountHolder/DeleteNomineeDetailsById?NomineeId='+Id);
  }
}
