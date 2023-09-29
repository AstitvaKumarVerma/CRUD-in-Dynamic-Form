import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountHolderFormComponent } from './account-holder-form/account-holder-form.component';
import { ShowComponent } from './show/show.component';

const routes: Routes = [
  {
    path:'', component:ShowComponent
  },
  {
    path:'add', component:AccountHolderFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
