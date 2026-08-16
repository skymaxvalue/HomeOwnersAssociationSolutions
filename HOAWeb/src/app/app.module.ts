import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './ParkingComponents/signup/signup.component';
import { LoginComponent } from './ParkingComponents/login/login.component';
import { CustomerProfileComponent } from './ParkingComponents/Customer/customer-profile/customer-profile.component';
import { CustomerHomePageComponent } from './ParkingComponents/Customer/customer-home-page/customer-home-page.component';
import { OTPComponent } from './ParkingComponents/otp/otp.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotFoundComponent } from './Shared/Component/not-found/not-found.component';
import { UnAuthorizedComponent } from './Shared/Component/un-authorized/un-authorized.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { DashboardComponent } from './ParkingComponents/dashboard/dashboard.component';
import { EmailValidatorPipe } from './Shared/Pipes/email-validator.pipe';
import { LayoutComponent } from './ParkingComponents/layout/layout.component';
import { AgGridAngular } from 'ag-grid-angular';
import { ParkingWorkFlowComponent } from './ParkingComponents/parking-work-flow/parking-work-flow.component';
import { MyParkingManagementComponent } from './ParkingComponents/Customer/my-parking-management/my-parking-management.component';
import { HasRoleDirective } from './Parkingdirective/HasRole/has-role.directive';
import { HOAHomePageComponent } from './ParkingComponents/HOA/hoahome-page/hoahome-page.component';
import { TowingCompanyHomePageComponent } from './ParkingComponents/TowingCompany/towing-company-home-page/towing-company-home-page.component';


@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,
    CustomerProfileComponent,
    CustomerHomePageComponent,
    OTPComponent,
    DashboardComponent,
    NotFoundComponent,
    UnAuthorizedComponent,
    EmailValidatorPipe,
    LayoutComponent,ParkingWorkFlowComponent, MyParkingManagementComponent, HasRoleDirective, HOAHomePageComponent, TowingCompanyHomePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,BrowserAnimationsModule,HttpClientModule,
    SweetAlert2Module.forRoot(),
    AgGridAngular
  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
