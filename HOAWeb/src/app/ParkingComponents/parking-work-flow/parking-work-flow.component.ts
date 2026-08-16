import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ColDef, GridApi, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { MyParkingManagementService } from 'src/app/ParkingServices/Customer/MyParkingManagement/my-parking-management.service';
import { ParkingWorkFlowService } from 'src/app/ParkingServices/ParkingWorkFlow/parking-work-flow.service';
import { HtmlHelperService } from 'src/app/Shared/Services/HtmlHelper/html-helper.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';

@Component({
  selector: 'app-parking-work-flow',
  templateUrl: './parking-work-flow.component.html',
  styleUrls: ['./parking-work-flow.component.css']
})
export class ParkingWorkFlowComponent {
  UserCred:any;
  LoggedInUserDetails:any;

  
  constructor(private parkingService:ParkingWorkFlowService,
    private _popUpServiceService:PopUpServiceService,
    private htmlHelperService:HtmlHelperService,
    private _localStorageService:LocalStorageService,
    private myParkingManagementService:MyParkingManagementService, private route: ActivatedRoute
  ){ 
    this.UserCred=this._localStorageService.getData("UserCred");
    this.LoggedInUserDetails=this._localStorageService.getData("LoggedInUserDetails");


  }

  id: string | null = null;
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

  parkingLocation=
  {
    locationId:0,
    area:'',
    parkingPicture:'',
  }
  
  durationOfParking=
  {
    parkingTimeId:0,
    startDateTime:'',
    endDateTime:''
  }



  parkingdetails=
  {
    status:'',
    userName:'',
    ParkingDetailsID:0,
    vehicleInfo:this.vehicleInfo,
    parkingLocation:this.parkingLocation,
    durationOfParking:this.durationOfParking

  }



  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
      if(this.id!=null)
      {
        this.GetParkingRequest(this.id) ;
      }
     
    });
  }
  GetParkingRequest(id:any) {
 


    this.parkingService.GetParkingRequest(id).then(
      (response) => {
        this.AssignResponse(response);
      }
    ).catch(
      (error) => {
        this._popUpServiceService.Error('Retriving Parking Details Failed:', error);
        // Handle the error here
      }
    );
  
  }

  ParkingRequestWorkFlowUpdate(status:string) {
   
    this.parkingdetails.userName=this.UserCred.UserName;
    this.parkingdetails.status=status;
    this.parkingdetails.vehicleInfo=this.vehicleInfo;


      this.parkingService.ParkingRequestWorkFlowUpdate(this.parkingdetails).then(
        (response) => {
          this.AssignResponse(response);
        }
      ).catch(
        (error) => {
          this._popUpServiceService.Error('Profile Details Update Failed:', error);
          // Handle the error here
        }
      );
    
  }
  

  AssignResponse(response:any)
  {  this.parkingdetails=response.message;
     
    this.vehicleInfo=response.message.vehicleInfo;
    this.durationOfParking=response.message.durationOfParking;
    this.parkingLocation=response.message.parkingLocation;
    this.parkingLocation.parkingPicture=response.message.parkingLocation.parkingPictureFromDB;
    this.vehicleInfo.vehiclePicture=response.message.vehicleInfo.vehiclePictureFromDB;
 
  }




 isVisible = false;
  closePopup() {
    this.isVisible = false;
  }

ShowUserVehicleList()
{ 
  this.myParkingManagementService.GetAllMyProfileHouseOwnerVechileDetails(this.UserCred.UserName).then(
   (response) => {

     this.rowData=response.message;
     this.showPopup();
     
   }
 ).catch(
   (error) => {
     this._popUpServiceService.Error('Retriving Vehicle information Failed:', error);
     this.closePopup();
   }
 );
    
}

showPopup() 
{ 
 this.isVisible = true;
}


defaultColDef=
{
  flex:1,
  minWidth:100
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


];
gridOptions: GridOptions = {
  rowSelection: 'single', // Single row selection
  onSelectionChanged: this.onSelectionChanged.bind(this) // Bind the method to component context
};

selectedFileName=''
onSelectionChanged(event: any) {
  this.vehicleInfo = event.api.getSelectedRows()[0];
  this.vehicleInfo.userName="";
  if (event.api.getSelectedRows()[0].vehiclePictureFromDB && event.api.getSelectedRows()[0].vehiclePictureFromDB.length > 0) {
    this.selectedFileName='Vechile Picture Updated';
  } else {
    this.selectedFileName='';
  }
  
}
onVechilePhotoSelected(event: any,flag:string) 
{
  const file: File = event.target.files[0];
  if (file) {
    const reader = new FileReader();
    reader.onload = (e: any) => 
    {
      if(flag=='VechilePhoto')
      {
        this.vehicleInfo.vehiclePicture = e.target.result;
        this.selectedFileName='';
      }
      else if (flag=='ParkingArea')
      {
        this.parkingLocation.parkingPicture = e.target.result;
        this.selectedFileName='';
      }
     
    };
    reader.readAsDataURL(file);
       
    console.log('Photo selected:', file);
  }
}













SAVE()
{
  this.ParkingRequestWorkFlowUpdate('Draft');
  this._popUpServiceService.Success('Parking Request Saved Successfully','');
  this.RedirectToAssignments();
}
RequestForParking()
{
  this.ParkingRequestWorkFlowUpdate('New Parking');
  this._popUpServiceService.Success('Parking Request Placed Successfully','');
  this.RedirectToAssignments();
}
Approve()
{
  this.ParkingRequestWorkFlowUpdate('Approved');
  this._popUpServiceService.Success('Parking Request Approved','');
  this.RedirectToAssignments();
}
Reject()
{
  this.ParkingRequestWorkFlowUpdate('Rejected');
  this._popUpServiceService.Success('Parking Request Rejected','');
  this.RedirectToAssignments();
}

RequestForTowing()
{
  this.ParkingRequestWorkFlowUpdate('Towing Request Inprogress');
  this._popUpServiceService.Success('Towing Request placed Successfully','');
  this.RedirectToAssignments();
}
Tow()
{
  this.ParkingRequestWorkFlowUpdate('Towed');
  this._popUpServiceService.Success('Vehicle Towed Status updated Successfully','');
  this.RedirectToAssignments();
}
RequestForDelivery()
{
  this.ParkingRequestWorkFlowUpdate('Requested for Delivery');
  this._popUpServiceService.Success('Vehicle Requested for Delivery','');
  this.RedirectToAssignments();
}
Delivered()
{
  this.ParkingRequestWorkFlowUpdate('Delivered');
  this._popUpServiceService.Success('Vehicle Delivery Status Updated Successfully','');
  this.RedirectToAssignments();
  
}


RedirectToAssignments()
{
  var user=this.LoggedInUserDetails;
  var assignmentUrl='';
  switch(user.message.userRole)
  {
    case'HOA':{assignmentUrl='/parkingSolutions/HOAParkingManagement';break;}
    case'Customer':{assignmentUrl='/parkingSolutions/ParkMyVehicle';break;}
    case'Towing Company':{assignmentUrl='/parkingSolutions/MyTowingAssignment';break;}

  }
  setTimeout(() => {
    window.location.href=assignmentUrl;
 }, 4000); // 2000 milliseconds = 2 seconds

}


isButtonVisible(status:string,allowedStatuses: string[]): boolean {

  return allowedStatuses.includes(this.parkingdetails.status);
  allowedStatuses=[];
}







}


