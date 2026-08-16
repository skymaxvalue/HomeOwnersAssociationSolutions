import { Component, Renderer2, ChangeDetectorRef, ElementRef  } from '@angular/core';
import { DomSanitizer ,SafeHtml} from '@angular/platform-browser';
import { OTPModel } from 'src/app/ParkingModels/OTPModel/otpmodel';
import { LayoutService } from 'src/app/ParkingServices/Layout/layout.service';
import { HtmlHelperService } from 'src/app/Shared/Services/HtmlHelper/html-helper.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent 
{

 menus: any[] = [];
 otpModel :OTPModel=new OTPModel();   
 htmlmenu: any={};

  constructor(
    private _layutService:LayoutService,
    private _localStorageService:LocalStorageService,
    private _popUpServiceService:PopUpServiceService, 
  ) 
  
  {
    
    var menulist=this._localStorageService.getData("UserMenu");
     menulist.forEach((menutree: { menuName: any; icon: any; subMenu: any; })=> 
      {
      this.addMenu(menutree.menuName,menutree.icon,menutree.subMenu);
      });

  } 
 
ngOnInit()
{
  if(this._localStorageService.getData("LoggedInUserDetails")==undefined ||this._localStorageService.getData("LoggedInUserDetails")==null || this._localStorageService.getData("LoggedInUserDetails")=='')
  {
    this.GetLoggedInUserDetails();

  }
  
  this.SetLoggedInUserDetails()
}

LoggedInUser=
{
  userImage:'',
  firstName:'',
  userId:0,
  userRole:'',
  menuPermission:''
}

addMenu(label: string, iconClass: string, submenu: any[]) {
  this.menus.push({
    label: label,
    iconClass: iconClass,
    submenu: submenu
  });
}

 GetLoggedInUserDetails() 
  {

   
    var data=this._localStorageService.getData("UserCred");
      this._layutService.getLoggedInUserDetails(data.UserName??"").then(
        (response) => {
             
             this._localStorageService.setData("LoggedInUserDetails",response);
             this.SetLoggedInUserDetails();
        }
      ).catch(
        (error) => {
          this._popUpServiceService.Error('Get Profile Details  Failed:', error);
          // Handle the error here
        }
      );
    
  }

  SetLoggedInUserDetails()
  {
    var response=this._localStorageService.getData("LoggedInUserDetails");
    response.message.userImage='data:image/jpeg;base64,'+response.message.userImage;
    this.LoggedInUser=response.message;
  }

  LogOut()
  { 
    this._localStorageService.removeData("authorization");
    this._localStorageService.removeData("LoggedInUserDetails");
    this._localStorageService.removeData("UserCred");
    this._localStorageService.removeData("UserMenu");



   
    window.location.href='/';


  }

}
