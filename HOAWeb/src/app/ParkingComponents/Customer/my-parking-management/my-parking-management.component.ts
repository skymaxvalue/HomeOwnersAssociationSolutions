import { Component } from '@angular/core';
import { MyParkingManagementService } from 'src/app/ParkingServices/Customer/MyParkingManagement/my-parking-management.service';
import { HtmlHelperService } from 'src/app/Shared/Services/HtmlHelper/html-helper.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-my-parking-management',
  templateUrl: './my-parking-management.component.html',
  styleUrls: ['./my-parking-management.component.css']
})

export class MyParkingManagementComponent {
   userdata:any;
  constructor (private myParkingManagementService:MyParkingManagementService,
    private _popUpServiceService:PopUpServiceService,
    private htmlHelperService:HtmlHelperService,
    private _localStorageService:LocalStorageService,
    private route: ActivatedRoute
  ){ 
    
    this.userdata=this._localStorageService.getData("UserCred");
  
  }

  id: string | null = null;
  CurrentUrlRequest :string="";
  vehicleInfo=
  {
    vehicleID:0,
    userName:'',
    make:'',
    model:'',
    color:'',
    tagNumber:'',
    vehiclePicture:'',
  }

  HouseDetails=
  {
    HouseId:0,
    OwnerName:'',
    SelectedCommunity:'',
    Addresss:'',
    City:'',
    State:'',
    Zip:'',
    Phone:'',
    Email:'',
    Notification:0,
    HousePicture:''
  }




  ngOnInit(): void {

    this.CurrentUrlRequest=this.route.snapshot.url[0].path;
    this.route.paramMap.subscribe(params => 
      {
         var pra=params;
         this.id = params.get('id');
                
       });


       if(this.CurrentUrlRequest=='MyHouseManagement' && this.id!=null)
        {
         
        }
        else if(this.CurrentUrlRequest=='MyVechileManagement' && this.id!=null)
        {
          setTimeout(() => {
            this.GetMyProfileHouseOwnerVechileDetails(this.id) ;
          }, 1000);
         
          
    
        }

     }
   
    



//House Block








//Vehcile block

  MyProfileHouseOwnerVechileDetailsSave() {
    // if (form.valid) {
    //   console.log('Form Submitted!', this.customer);
    // }
 

      this.vehicleInfo.userName=this.userdata.UserName;
      this.myParkingManagementService.MyProfileHouseOwnerVechileDetailsSave(this.vehicleInfo).then(
        (response) => {
  
             if(response.message.split(':')[0]=="Success")
              {
               this._popUpServiceService.Success("Vechile Details Saved Successfully","You will be Re-Directing to MyProfile");
               setTimeout(() => {
                 window.location.href='/parkingSolutions/profile'
              }, 4000); // 2000 milliseconds = 2 seconds
            
             
              }
              else
              {
                this._popUpServiceService.HtmlErrorPopup(this.htmlHelperService.IsBusinessValidationError(response.message.split(':')[1]),"Error");
              }
  
        }
      ).catch(
        (error) => {
          this._popUpServiceService.Error('Vechile Details Save Failed:', error);
          // Handle the error here
        }
      );
    





  }
  GetMyProfileHouseOwnerVechileDetails(VechileId:any) {

      this.vehicleInfo.userName=this.userdata.UserName;
     
      this.myParkingManagementService.GetMyProfileHouseOwnerVechileDetails(VechileId).then(
        (response) => {
  
          this.vehicleInfo=response.message;
          this.vehicleInfo.vehiclePicture=response.message.vehiclePictureFromDB;
        }
      ).catch(
        (error) => {
          this._popUpServiceService.Error('Vechile Details Save Failed:', error);
          // Handle the error here
        }
      );
    





  }
  
  onVechilePhotoSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.vehicleInfo.vehiclePicture = e.target.result;
      };
      reader.readAsDataURL(file);
         
      console.log('Photo selected:', file);
    }
  }


  // this.myParkingManagementService.MyProfileHouseOwnerVechileDetailsUpdate(this.vehicleInfo).then(
  //   (response) => {

  //        if(response.message.split(':')[0]=="Success")
  //         {
  //          this._popUpServiceService.Success("Done","Vechile Details Updated Successfully");
  //         }
  //         else
  //         {
  //           this._popUpServiceService.HtmlErrorPopup(this.htmlHelperService.IsBusinessValidationError(response.message.split(':')[1]),"Error");
  //         }

  //   }
  // ).catch(
  //   (error) => {
  //     this._popUpServiceService.Error('Profile Details Update Failed:', error);
  //     // Handle the error here
  //   }
  // );


}
