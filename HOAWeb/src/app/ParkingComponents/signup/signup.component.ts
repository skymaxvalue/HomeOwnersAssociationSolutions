import { Component,NgZone  } from '@angular/core';
import { Router } from '@angular/router';
import { SignupService } from 'src/app/ParkingServices/signup/signup.service';
import { HtmlHelperService } from 'src/app/Shared/Services/HtmlHelper/html-helper.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';
import { EmailValidatorPipe } from 'src/app/Shared/Pipes/email-validator.pipe';
//Dumy push
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  constructor(
    private _signUp:SignupService,
    private _popUpServiceService:PopUpServiceService,
    private router: Router,private ngZone: NgZone,private htmlHelperService:HtmlHelperService) { 
    }
  
  ErrorList=[];
  HOAMstList=[];
  userData = {
    UserName: '',
    Password: '',
    ConfirmPassword: '',
    EmailId: '',
    MobileNumber: '',
    PreferedOTP: '',
    Iam: '',
    HOAId:"0",
  };
  HOAoptions=[{id:"0",value:'Select HOA'}];
  SelectedHOA="0";

  ngOnInit(): void 
  {
   this.LoadHOAMaster();
  }

 
  // onChangeHOA(event: any) {
  //   const target = event.target as HTMLSelectElement;
  //   const value = +target.value; // Convert to number if needed
  //   console.log('Selected value from event:', value);
  //   this.SelectedHOA = value;
  // }

  LoadHOAMaster()
  {
    this._signUp.LoadHOAMaster().then(
      (response) => {
        
        this.HOAoptions=response.message;
        
      }
    ).catch(
      (error) => {
        this._popUpServiceService.Error('SignUp Failed:', error);
        // Handle the error here
      }
    );
  }

  Reset()
  {
    

  }
  onSubmit() {

  
   
    this._signUp.SignUp(this.userData).then(
      (response) => {

           if(response.message.split(':')[0]=="Success")
            {
              this._popUpServiceService.Success("Done",response.message.split(':')[1]);
              setTimeout(() => {
                window.location.href="/"
              
                 this.ngZone.run(() => {
                 
               });
             }, 2000); // 2000ms = 2 seconds
            }
            else
            {
            this._popUpServiceService.HtmlErrorPopup(this.htmlHelperService.IsBusinessValidationError(response.message.split(':')[1]),"Error");

            }

       
        
      }
    ).catch(
      (error) => {
        this._popUpServiceService.Error('SignUp Failed:', error);
        // Handle the error here
      }
    );

  }
  
  IsPasswordSame():boolean
  {
    return (this.isValidPassword(this.userData.Password) ===
     this.isValidPassword(this.userData.ConfirmPassword)) ;
  }

  isFieldsareValid(): boolean {
    // Perform your validation logic here
    // For example, check if required fields are filled
    return this.userData.UserName.trim() !== '' &&
           this.userData.Password.trim() !== '' &&
           this.userData.ConfirmPassword.trim() !== '' &&
           this.userData.EmailId.trim() !== '' &&
           this.userData.MobileNumber.trim() !== '' &&
           this.userData.PreferedOTP.trim() !== '' &&
           this.userData.Iam.trim() !== '';
  }
  
  static isValidMobile(value: string): boolean {
    // Mobile number should contain only digits and have a length of 10
    const mobileRegex = /^[0-9]{10}$/;
    return mobileRegex.test(value);
  }



  isValidPassword(value: string): boolean {

      // At least 8 characters long
  // Contains at least one lowercase letter
  // Contains at least one uppercase letter
  // Contains at least one number
  // Contains at least one special character
    // Regular expression for password pattern validation
    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return passwordRegex.test(value);
  }

  isMatchesLengthCriteria(): boolean {
    return this.isMinLength(this.userData.UserName, 3) &&
    this.isMaxLength(this.userData.UserName, 20) && // Example: Max length for username is 20 characters
    this.isMinLength(this.userData.EmailId,20) &&
    this.isMaxLength(this.userData.EmailId,30) &&
           this.isMinLength(this.userData.MobileNumber, 10) && // Example: Mobile number should be at least 10 digits
           this.isMaxLength(this.userData.MobileNumber, 12) 
  }

 
   isMinLength(value: string, minLength: number): boolean {
    return value.trim().length >= minLength;
  }

   isMaxLength(value: string, maxLength: number): boolean {
    return value.trim().length <= maxLength;
  }
  BacktoLogin()
  {
    window.location.href="/";
  }
  

}
