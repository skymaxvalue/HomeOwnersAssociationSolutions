import { Component } from '@angular/core';
import { ColDef, GridApi, GridReadyEvent } from 'ag-grid-community'; // Column Definition Type Interface
import { ParkingWorkFlowService } from 'src/app/ParkingServices/ParkingWorkFlow/parking-work-flow.service';
import { LocalStorageService } from 'src/app/Shared/Services/LocalStorage/local-storage.service';
import { PopUpServiceService } from 'src/app/Shared/Services/PopUpService/pop-up-service.service';

@Component({
  selector: 'app-hoahome-page',
  templateUrl: './hoahome-page.component.html',
  styleUrls: ['./hoahome-page.component.css']
})
export class HOAHomePageComponent {
  userdata:any;
  constructor(private parkingService:ParkingWorkFlowService,
    private _popUpServiceService:PopUpServiceService,
    private _localStorageService:LocalStorageService,
  ){ this.userdata=this._localStorageService.getData("UserCred");}

 private gridApi!:GridApi<any>;
 ngOnInit(): void {
  this.GetAllHOAAssignments();
  }

  
onGridReady(event:GridReadyEvent<any>){this.gridApi=event.api;}
rowData = [];
colDefs: ColDef[] = [
  { field: "docNo",headerName:"DocumentNumber" ,filter:'agTextColumnFilter'},
  { field: "tagNumber",headerName:"TagNumber" ,filter:'agTextColumnFilter'},
  { field: "status" ,headerName:"Status",filter:'agTextColumnFilter'},
  { field: "area" ,headerName:"Area",filter:'agTextColumnFilter'},
  { field: "startDateTime" ,headerName:"StartDateTime",filter:'agTextColumnFilter'},
  { field: "endDateTime" ,headerName:"EndDateTime",filter:'agTextColumnFilter'},
  { field: "vehiclePictureFromDB" ,headerName:"Vehicle",cellRenderer:(item:any)=> {
    let newLink = 
    ` <img src="data:image/jpeg;base64,${item.value}" style="width:60px; height:60px; border:none; margin:0; padding:0"/>`;
    return newLink;
},

},
{ field: "parkingPictureFromDB" ,headerName:"ParkingLocation",cellRenderer:(item:any)=> {
  let newLink = 
  ` <img src="data:image/jpeg;base64,${item.value}" style="width:60px; height:60px; border:none; margin:0; padding:0"/>`;
  return newLink;
},

},
  { field: "parkingDetailsID" ,headerName:"Action",cellRenderer:(item:any)=> {
      let newLink = 
    `<a href= parkingSolutions/WhereIsParking/${item.value}><i style="color:Grey" class="ti ti-pencil"></i> </a>
      `;
    return newLink;
}},


];

defaultColDef=
{
  flex:1,
  minWidth:100
}



AddTowingParking()
{
  window.location.href='/parkingSolutions/WhereIsParking'
}
GetAllHOAAssignments() {
 


    this.parkingService.GetAllHOAAssignments(this.userdata.UserName).then(
      (response) => {

        this.rowData=response.message;

      }
    ).catch(
      (error) => {
        this._popUpServiceService.Error('Retriving All Parking Details Failed:', error);
        // Handle the error here
      }
    );
  
}



}