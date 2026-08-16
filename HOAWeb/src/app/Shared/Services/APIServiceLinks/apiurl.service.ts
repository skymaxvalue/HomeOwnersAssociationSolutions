import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})

export class APIUrlService {

  constructor() { }


 public SignupUrl=environment.baseApiUrl+'SignUp/NewUserAccountCreation';
 public LoadHOAMaster=environment.baseApiUrl+'SignUp/LoadHOAMaster';

 public login=environment.baseApiUrl+'LogIn/SignIn';
 public otp=environment.baseApiUrl+'OTP/ValidateOTP';
 public dashboard=environment.baseApiUrl+'';
 public Layout=environment.baseApiUrl+'Layout/GetMenu';
 public LoggedInUserDetails=environment.baseApiUrl+'Layout/GetLoggedInUserDetails';
 public Auth=environment.baseApiUrl+'AuthService/Authenticate';

 public MyProfileUpdate=environment.baseApiUrl+'MyProfile/MyProfileUpdate';

 public MyProfileHouseOwnerAssociationDetailsUpdate=environment.baseApiUrl+'MyProfile/HouseOwnerAssociationDetailsUpdate';
 public MyProfileHouseOwnerVechileDetailsSave=environment.baseApiUrl+'MyProfile/MyProfileHouseOwnerVechileDetailsSave';
 public GetAllMyProfileHouseOwnerVechileDetails=environment.baseApiUrl+'MyProfile/GetAllVehicleDetails';
 public GetMyProfileHouseOwnerVechileDetails=environment.baseApiUrl+'MyProfile/GetVehicleDetails';
 public MyProfileHouseOwnerDeleteVechileDetails=environment.baseApiUrl+'MyProfile/DeleteVechileDetails';

 public MyProfileTowingCompanyDetailsUpdate=environment.baseApiUrl+'MyProfile/TowingCompanyDetailsUpdate';
 public MyProfileGetUserProfileDetails=environment.baseApiUrl+'MyProfile/GetUserProfileDetails';



 public ParkingWorkFlowUpdate=environment.baseApiUrl+'Parking/ParkingRequestWorkFlowUpdate';
 public GetParkingRequest=environment.baseApiUrl+'Parking/GetParkingRequest';
 public GetAllParkingRequest=environment.baseApiUrl+'Parking/GetAllParkingRequest';
 public GetAllTowingCompanyAssignments=environment.baseApiUrl+'Parking/GetAllTowingCompanyAssignments';
 public GetAllHOAAssignments=environment.baseApiUrl+'Parking/GetAllHOAAssignments';




}


