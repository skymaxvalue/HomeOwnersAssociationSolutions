import { Component,ViewChild  } from '@angular/core';
import { Router } from '@angular/router'; 
import { OTPModel } from 'src/app/ParkingModels/OTPModel/otpmodel';
import { LoginService } from 'src/app/ParkingServices/login/login.service';
import { HtmlHelperService } from 'src/app/Shared/Services/HtmlHelper/html-helper.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';
declare var $: any;
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  otpModel :OTPModel=new OTPModel();   
  userData = {
    username: '',
    password: '',
  
  };
  constructor(private router: Router,private login:LoginService,
    private _popUpServiceService:PopUpServiceService,
    private htmlHelperService:HtmlHelperService,
    private _localStorageService:LocalStorageService
  ) {} // Inject Router into the constructor

  onSubmit() {
    



    this.login.Login(this.userData).then(
      (response) => {

           if(response.message.split(':')[0]=="Success")
            {

              this.otpModel=new OTPModel();
              this.otpModel.UserId=0;
              this.otpModel.UserName=this.userData.username;
              this.otpModel.EmailId="";
              this.otpModel.MobileNumber="";
              this.otpModel.OTP="";
              this._localStorageService.setData("UserCred",this.otpModel);
              window.location.href='/otp'
            }
            else
            {
            this._popUpServiceService.HtmlErrorPopup(this.htmlHelperService.IsBusinessValidationError(response.message.split(':')[1]),"Error");

            }

      }
    ).catch(
      (error) => {
        this._popUpServiceService.Error('Login Failed:', error);
        // Handle the error here
      }
    );



  }

  onReset() {
    console.log('Login form canceled');
    // Add any cancel logic here, such as navigating away from the login page
  }

  forgotPassword() {
    console.log('Forgot Password clicked');
    // Add logic to handle forgot password functionality
  }

  forgotUsername() {
    console.log('Forgot Username clicked');
    // Add logic to handle forgot username functionality
  }

  onSignUp() {
    console.log('Sign Up clicked');
    // Navigate to the sign-up page
    // this.router.navigate(["/signup"]);
    window.location.href="/signup";
  
  }

  openModal(type: string): void {
    // if (type === 'password') {
    //   this.openModal(this.forgotPasswordModal);
    // } else if (type === 'username') {
    //   this.openModal(this.forgotUsernameModal);
    // }
  }
}
