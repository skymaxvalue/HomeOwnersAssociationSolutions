import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './ParkingComponents/dashboard/dashboard.component';
import { SignupComponent } from './ParkingComponents/signup/signup.component';
import { LoginComponent } from './ParkingComponents/login/login.component';
import { OTPComponent } from './ParkingComponents/otp/otp.component';
import { CustomerProfileComponent } from './ParkingComponents/Customer/customer-profile/customer-profile.component';
import { NotFoundComponent } from './Shared/Component/not-found/not-found.component';
import { UnAuthorizedComponent } from './Shared/Component/un-authorized/un-authorized.component';
import { LayoutComponent } from './ParkingComponents/layout/layout.component';
import { AuthGuard } from './auth.guard';

import { CustomerHomePageComponent } from './ParkingComponents/Customer/customer-home-page/customer-home-page.component';
import { ParkingWorkFlowComponent } from './ParkingComponents/parking-work-flow/parking-work-flow.component';
import { MyParkingManagementComponent } from './ParkingComponents/Customer/my-parking-management/my-parking-management.component';
import { HOAHomePageComponent } from './ParkingComponents/HOA/hoahome-page/hoahome-page.component';
import { TowingCompanyHomePageComponent } from './ParkingComponents/TowingCompany/towing-company-home-page/towing-company-home-page.component';

const routes: Routes =
 
[ 
  {path: '', title: 'Login', component: LoginComponent},
 
  {path: 'otp', title: 'Enter OTP', component: OTPComponent},
  {path: 'signup', title: 'Sign Up', component: SignupComponent},
  {path: 'UnAuthorized', title: 'UnAuthorized', component: UnAuthorizedComponent},
  {path: 'parkingSolutions', title: '', component: LayoutComponent,//Layout comes here
 
  children:
[
  
  {path: 'dashboard', title: 'Dashboard', component: DashboardComponent},
  // {path: 'customerprofile', title: 'Customer Profile', component: CustomerProfileComponent,canActivate: [AuthGuard]},
  {path: 'profile', title: 'My Profile', component: CustomerProfileComponent},
 



 //Customer

  {path: 'ParkMyVehicle', title: 'Park My Vehicle', component: CustomerHomePageComponent},
  {path: 'WhereIsParking/:id', title: 'Where Is Parking', component: ParkingWorkFlowComponent},
  {path: 'WhereIsParking', title: 'Where Is Parking', component: ParkingWorkFlowComponent},

  //Vechile Add/Edit/save
  {path: 'MyVechileManagement', title: 'MyVechileManagement', component:MyParkingManagementComponent },
  {path: 'MyVechileManagement/:id', title: 'MyVechileManagement', component:MyParkingManagementComponent },

  //House Add/Edit/save
  {path: 'MyHouseManagement', title: 'MyHouseManagement', component:MyParkingManagementComponent },
  {path: 'MyHouseManagement/:id', title: 'MyHouseManagement', component:MyParkingManagementComponent },




//HOA
  {path: 'HOAParkingManagement', title: 'My Parking Request Assignment', component: HOAHomePageComponent},
  {path: 'WhereIsParking/:id', title: 'Where Is Vehicle', component: ParkingWorkFlowComponent},

//Towing

  {path: 'MyTowingAssignment', title: 'My Towing Assignment', component: TowingCompanyHomePageComponent},
  {path: 'WhereIsParking/:id', title: 'Where Is Vehicle', component: MyParkingManagementComponent },
  
]
},

{path: '**', title: 'NotFound', component: NotFoundComponent},


];

// [ 

//   {path: '', title: 'Login', component: LoginComponent},
//   {path: 'signup', title: 'Sign Up', component: SignupComponent},
//   {path: 'otp', title: 'Enter OTP', component: OTPComponent},
//    {path: 'dashboard', title: 'Dashboard', component: DashboardComponent},
//   {path: 'customerprofile', title: 'Customer Profile', component: CustomerProfileComponent},
//   {path: 'UnAuthorized', title: 'UnAuthorized', component: UnAuthorizedComponent},
//   {path: '**', title: 'NotFound', component: NotFoundComponent}
// ]




@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
