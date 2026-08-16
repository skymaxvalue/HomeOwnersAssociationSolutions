import { Component } from '@angular/core';
import { OTPModel } from 'src/app/ParkingModels/OTPModel/otpmodel';
import { LayoutService } from 'src/app/ParkingServices/Layout/layout.service';
import { OtpService } from 'src/app/ParkingServices/otp/otp.service';

import { HtmlHelperService } from 'src/app/Shared/Services/HtmlHelper/html-helper.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';


@Component({
  selector: 'app-otp',
  templateUrl: './otp.component.html',
  styleUrls: ['./otp.component.css']
})
export class OTPComponent 
{

  


  constructor(private otp:OtpService,
    private _popUpServiceService:PopUpServiceService,
    private htmlHelperService:HtmlHelperService,
    private _localStorageService:LocalStorageService,
    private _layutService:LayoutService,
  ) {} 

  // _OTPModel :Array<OTPModel>=new Array<OTPModel>();
  SecureOTP:any='';
  otpModel :OTPModel=new OTPModel();    
  secureLogin(): void {
    

    this.otpModel=this._localStorageService.getData("UserCred");
    this.otpModel.OTP=this.SecureOTP;
    this.otp.ValidateOTP(this.otpModel).then(
      (response) => {

           if(response.message.split(':')[0]=="Success")
            {
              this.GetMenu();
            }
            else
            {
              this._popUpServiceService.HtmlErrorPopup(this.htmlHelperService.IsBusinessValidationError(response.message.split(':')[1]),"Error");
            }

      }
    ).catch(
      (error) => {
        this._popUpServiceService.Error('OTP Validation Failed:', error);
        // Handle the error here
      }
    );



    

  }

  resendOTP(): void {
    // Logic to resend OTP
  }

  cancel(): void {
    // Logic to cancel sign-up process
  }

  reset(): void {
    // Logic to cancel sign-up process
  }


  GetMenu()
  {
   
    this.otpModel=this._localStorageService.getData("UserCred");
    this._layutService.getUmMenu( this.otpModel.UserName??"").then(
      (response) => {
           this._localStorageService.setData("UserMenu",response.message);
            window.location.href='/parkingSolutions/profile'
      }
    ).catch(
      (error) => {
        this._popUpServiceService.Error('Menu loading failed:', error);
        // Handle the error here
      }
    );
  }

}
