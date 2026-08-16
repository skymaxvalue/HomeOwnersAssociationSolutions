import { Component, ElementRef, ViewChild } from '@angular/core';
import { CustomerProfileService } from 'src/app/ParkingServices/Customer/CustomerProfile/customer-profile.service';

import { HtmlHelperService } from 'src/app/Shared/Services/HtmlHelper/html-helper.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';
import { ColDef, GridApi, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Router } from '@angular/router';
import { MyParkingManagementService } from 'src/app/ParkingServices/Customer/MyParkingManagement/my-parking-management.service';
@Component({
  selector: 'app-customer-profile',
  templateUrl: './customer-profile.component.html',
  styleUrls: ['./customer-profile.component.css']
})
export class CustomerProfileComponent 
{
 constructor (private customerProfileService:CustomerProfileService,
    private _popUpServiceService:PopUpServiceService,
    private htmlHelperService:HtmlHelperService,
    private _localStorageService:LocalStorageService,
    private _MyParkingManagementService:MyParkingManagementService,

    private router: Router
  ){}

  isCollapsed = false;
  isTowingCollapsed = false;
  isHOACollapsed = false;
  isVCollapsed = false;
  isHOCollapsed = false;

  customer = {
    profileId:0,
    firstName: '',
    middleName: '',
    lastName: '',
    dob: '',
    primaryEmail: '',
    secondryEmail: '',
    primaryContact: '',
    secondryContact: '',
    officeContact: '',
    mailingAddress: '',
    photoPreviewUrl:''

  };

  selectedPhoto: File | null = null;
  PreviewUrl:  ArrayBuffer  |string|null=null;

  ngOnInit()
   {
    this.GetUserProfile();
   }




  GetUserProfile() 
  {

   
    var data=this._localStorageService.getData("UserCred");
      this.customerProfileService.GetUserProfileDetails(data.UserName??"").then(
        (response) => {
             this.customer=response.message;
             this.PreviewUrl='data:image/jpeg;base64,'+response.message.loginImage;
             this.customer.dob=response.message.dob.split('T')[0];
                
             this.rowData=response.message.vechileDetails;
          
             
        }
      ).catch(
        (error) => {
          this._popUpServiceService.Error('Get Profile Details  Failed:', error);
          // Handle the error here
        }
      );
    
  }

  saveProfile(form: any) {
    // if (form.valid) {
    //   console.log('Form Submitted!', this.customer);
    // }
 
      if (this.PreviewUrl === null) {
           this.customer.photoPreviewUrl = '';
      } 
      else if (this.PreviewUrl instanceof ArrayBuffer) 
      {
           this.customer.photoPreviewUrl = '';
      }
     else {
        this.customer.photoPreviewUrl = this.PreviewUrl;
      }
      
     
      this.customerProfileService.ProfileUpdate(this.customer).then(
        (response) => {
  
             if(response.message.split(':')[0]=="Success")
              {
               this._popUpServiceService.Success("Done","Profile Details Update Successfully");
               this.GetUserProfile();
              }
              else
              {
                this._popUpServiceService.HtmlErrorPopup(this.htmlHelperService.IsBusinessValidationError(response.message.split(':')[1]),"Error");
              }
  
        }
      ).catch(
        (error) => {
          this._popUpServiceService.Error('Profile Details Update Failed:', error);
          // Handle the error here
        }
      );
    
  }

   arrayBufferToBase64(buffer:any) {
    const bytes = new Uint8Array(buffer);
    let binaryString = '';
    const len = bytes.byteLength;
    for (let i = 0; i < len; i++) {
        binaryString += String.fromCharCode(bytes[i]);
    }
    return btoa(binaryString);
}


  onCancel() {
    // Logic to handle form cancel
    console.log('Form Cancelled');
  }


  onPhotoSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.selectedPhoto = file;

      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.PreviewUrl = e.target.result;
      
      };
      reader.readAsDataURL(file);
         
      console.log('Photo selected:', file);
    }
  }

  triggerFileInput() {
    const fileInput = document.getElementById('photo') as HTMLInputElement;
    if (fileInput) {
      fileInput.click();
    }
  }







  toggleHOCollapse() {
    this.isHOCollapsed = !this.isHOCollapsed;
  }


  AddNewVehicle()
  {
    window.location.href='/parkingSolutions/MyVechileManagement'
  }

  AddNewHouse()
  {
    window.location.href='/parkingSolutions/MyHouseManagement'
  }


private gridApi!:GridApi<any>;
 onGridReady(event:GridReadyEvent<any>) {this.gridApi=event.api; }
 rowData = [];
 colDefs: ColDef[] = [
  { field: "make",headerName:"Make" ,filter:'agTextColumnFilter'},
  { field: "model" ,headerName:"Model",filter:'agTextColumnFilter'},
  { field: "color" ,headerName:"Color",filter:'agTextColumnFilter'},
  { field: "tagNumber" ,headerName:"Tag",filter:'agTextColumnFilter'},
  { field: "vehiclePictureFromDB" ,headerName:"Image",cellRenderer:(item:any)=> {
    let newLink = 
    ` <img src="data:image/jpeg;base64,${item.value}" style="width:60px; height:60px; border:none; margin:0; padding:0"/>`;

    return newLink;
}
},
  { field: "vehicleID" ,headerName:"Edit",cellRenderer:(item:any)=> {
      let newLink = 
    `<a href= parkingSolutions/MyVechileManagement/${item.value}><i style="color:Grey; cursor: pointer;" class="ti ti-pencil"></i> </a>
      &nbsp;
    `;
    return newLink;
}},
{ field: "vehicleID" ,headerName:"Delete",cellRenderer:(item:any)=> {
  let newLink = 
` <i  style="color:red; cursor: pointer;" class="ti ti-trash"${item.value}></i> 
`;
return newLink;
}},

];

gridOptions: GridOptions = {
  rowSelection: 'single', // Single row selection
  
  onCellClicked: this.onCellClicked.bind(this) 
};

onCellClicked(event: any) {
if(event.column.colId=="vehicleID_1")  
{
  this.DeleteVechileDetails(event.value);
  
}
}

defaultColDef=
{
  flex:1,
  minWidth:100
}

DeleteVechileDetails(VechileId:any) {
   
  this._MyParkingManagementService.DeleteVechileDetails(VechileId).then(
    (response) => {
      if(response.message=="Success")
      {
        this._popUpServiceService.Success("Vehicle Details Deleted Successfully",'');
        this.GetUserProfile();
      }
      else{
        this._popUpServiceService.Warning(response.message,'');
      }
      
    }
  ).catch(
    (error) => {
      this._popUpServiceService.Error('Vechile Delete Failed:', error);
      // Handle the error here
    }
  );



}

}
