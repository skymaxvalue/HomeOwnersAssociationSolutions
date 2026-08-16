using DAL.Contract;
using DAL.Helper;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Implementation
{
    public class MyProfileDAL:IMyProfileDAL
    {

        //Update

        public string MyProfileUpdate(MyProfileUpdateModel profileUpdate)
        {
			try
			{
                string errors = "";

                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("ProfileId", profileUpdate.ProfileId??0);
                param.Add("FirstName", profileUpdate.FirstName);
                param.Add("MiddleName", profileUpdate.MiddleName);
                param.Add("LastName", profileUpdate.LastName);
                param.Add("DOB", profileUpdate.DOB);
                param.Add("SecondryEmail", profileUpdate.SecondryEmail);
                param.Add("SecondryContact", profileUpdate.SecondryContact);
                param.Add("OfficeContact", profileUpdate.OfficeContact);
                param.Add("MailingAddress", profileUpdate.MailingAddress);
                param.Add("LoginImage", CommonHelper.FromBase64StringToByteArray(profileUpdate.photoPreviewUrl));

                var validationResults = SQLHelper.ExecuteDataset("SP_UpdateMyProfile", param);
                if (validationResults != null && validationResults.Tables.Count > 0 && validationResults.Tables[0].Rows.Count > 0)
                {
                    errors = validationResults.Tables[0].Rows[0][0].ToString();
                }
                return errors;
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }

       
        public string TowingCompanyDetailsUpdate(TowingCompanyDetailsModel towingCompanyDetails)
        {
            try
            {
                string errors = "";

                //Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                //param.Add("ProfileId", profileUpdate.ProfileId);
                //param.Add("FirstName", profileUpdate.FirstName);
                //param.Add("MiddleName", profileUpdate.MiddleName);
                //param.Add("LastName", profileUpdate.LastName);
                //param.Add("DOB", profileUpdate.DOB);
                //param.Add("SecondryEmail", profileUpdate.SecondryEmail);
                //param.Add("SecondryContact", profileUpdate.SecondryContact);
                //param.Add("OfficeContract", profileUpdate.OfficeContract);
                //param.Add("MailingAddress", profileUpdate.MailingAddress);
                //param.Add("LoginImage", profileUpdate.LoginImage);

                var validationResults = SQLHelper.ExecuteDataset("SP_UpdateTowingCompanyDetails");
                if (validationResults != null && validationResults.Tables.Count > 0 && validationResults.Tables[0].Rows.Count > 0)
                {
                    errors = validationResults.Tables[0].Rows[0][0].ToString();
                }
                return errors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string HouseOwnerAssociationDetailsUpdate(HouseOwnerAssociationDetailsModel houseOwnerAssociationDetails)
        {
            try
            {
                string errors = "";

                //Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                //param.Add("ProfileId", profileUpdate.ProfileId);
                //param.Add("FirstName", profileUpdate.FirstName);
                //param.Add("MiddleName", profileUpdate.MiddleName);
                //param.Add("LastName", profileUpdate.LastName);
                //param.Add("DOB", profileUpdate.DOB);
                //param.Add("SecondryEmail", profileUpdate.SecondryEmail);
                //param.Add("SecondryContact", profileUpdate.SecondryContact);
                //param.Add("OfficeContract", profileUpdate.OfficeContract);
                //param.Add("MailingAddress", profileUpdate.MailingAddress);
                //param.Add("LoginImage", profileUpdate.LoginImage);

                var validationResults = SQLHelper.ExecuteDataset("SP_UpdateHouseOwnerAssociationDetails");
                if (validationResults != null && validationResults.Tables.Count > 0 && validationResults.Tables[0].Rows.Count > 0)
                {
                    errors = validationResults.Tables[0].Rows[0][0].ToString();
                }
                return errors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string HouseOwnerDetailsUpdate(HouseOwnerDetailsModel houseOwnerDetails)
        {
            try
            {
                string errors = "";

                //Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                //param.Add("ProfileId", profileUpdate.ProfileId);
                //param.Add("FirstName", profileUpdate.FirstName);
                //param.Add("MiddleName", profileUpdate.MiddleName);
                //param.Add("LastName", profileUpdate.LastName);
                //param.Add("DOB", profileUpdate.DOB);
                //param.Add("SecondryEmail", profileUpdate.SecondryEmail);
                //param.Add("SecondryContact", profileUpdate.SecondryContact);
                //param.Add("OfficeContract", profileUpdate.OfficeContract);
                //param.Add("MailingAddress", profileUpdate.MailingAddress);
                //param.Add("LoginImage", profileUpdate.LoginImage);

                var validationResults = SQLHelper.ExecuteDataset("SP_UpdateHouseOwnerDetails");
                if (validationResults != null && validationResults.Tables.Count > 0 && validationResults.Tables[0].Rows.Count > 0)
                {
                    errors = validationResults.Tables[0].Rows[0][0].ToString();
                }
                return errors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //Get
        public MyProfileUpdateModel GetUserProfileDetails(string username)
        {
            try
            {
                
                string errors = "";
                MyProfileUpdateModel myprofile = new MyProfileUpdateModel();
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", username);

                var myprofiledata = SQLHelper.ExecuteDataset("SP_GetUserProfile", param);
                if (myprofiledata != null && myprofiledata.Tables.Count > 0 && myprofiledata.Tables[0].Rows.Count > 0)
                {
                    myprofile = myprofiledata.Tables[0].AsEnumerable()
                                  .Select(row => new MyProfileUpdateModel
                                  {
                                      ProfileId = row.Field<int?>("ProfileId"),
                                      FirstName = row.Field<string>("FirstName"),
                                      MiddleName = row.Field<string?>("MiddleName"),
                                      LastName = row.Field<string>("LastName"),
                                      DOB = row.Field<DateTime?>("DOB"),
                                      PrimaryEmail = row.Field<string>("PrimaryEmail"),
                                      SecondryEmail = row.Field<string?>("SecondryEmail"),
                                      PrimaryContact = row.Field<string>("PrimaryContact"),
                                      SecondryContact = row.Field<string?>("SecondryContact"),
                                      OfficeContact = row.Field<string?>("OfficeContact"),
                                      MailingAddress = row.Field<string?>("MailingAddress"),
                                      LoginImage = row.Field<byte[]?>("LoginImage")
                                  }).FirstOrDefault();


                }
                myprofile.VechileDetails = GetAllVehicleDetails(username);
                return myprofile;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


   

        public string MyProfileHouseOwnerVechileDetailsSave(VechileDetailsModel vehicle)
        {
            try
            {
                string errors = "";

                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
               param.Add("@VehicleID", vehicle.VehicleID);
               param.Add("@Make", vehicle.Make);
               param.Add("@Model", vehicle.Model);
               param.Add("@Year", vehicle.Year);
               param.Add("@Color", vehicle.Color);
               param.Add("@TagNumber", vehicle.TagNumber);
               param.Add("@VehiclePicture", CommonHelper.FromBase64StringToByteArray(vehicle.VehiclePicture??""));
               param.Add("@UserName", vehicle.UserName);

                var validationResults = SQLHelper.ExecuteDataset("SP_MyProfileHouseOwnerVechileDetailsSave", param);
                if (validationResults != null && validationResults.Tables.Count > 0 && validationResults.Tables[0].Rows.Count > 0)
                {
                    errors = validationResults.Tables[0].Rows[0][0].ToString();
                }
                return errors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VechileDetailsModel GetVehicleDetails(int vehicleId)
        {
          
            try
            {
               
                var param = new Dictionary<string, dynamic>
                {
                    { "@VehicleID", vehicleId }
                };

             
                var vehicleData = SQLHelper.ExecuteDataset("SP_GetMyProfileHouseOwnerVechileDetails", param);

                if (vehicleData != null && vehicleData.Tables.Count > 0 && vehicleData.Tables[0].Rows.Count > 0)
                {
                    // Map the result to VehicleDetailsModel
                    return vehicleData.Tables[0].AsEnumerable()
                        .Select(row => new VechileDetailsModel
                        {
                            VehicleID = row.Field<int>("VehicleID"),
                            Make = row.Field<string>("Make"),
                            Model = row.Field<string>("Model"),
                            Year = row.Field<int>("Year"),
                            Color = row.Field<string>("Color"),
                            TagNumber = row.Field<string>("TagNumber"),
                            VehiclePictureFromDB = row.Field<byte[]?>("VehiclePicture")
                          
                        }).FirstOrDefault();
                }

                return null;
            }
            catch (Exception ex)
            {
               
                throw ex; // Preserve stack trace and rethrow
            }
        }

        public List<VechileDetailsModel> GetAllVehicleDetails(string username)
        {
            try
            {
                var param = new Dictionary<string, dynamic>
                {
                    { "@Username", username }
                };
                List<VechileDetailsModel> VehicleList = new List<VechileDetailsModel>();
                var vehiclesData = SQLHelper.ExecuteDataset("SP_GetAllMyProfileHouseOwnerVechileDetails", param);

                if (vehiclesData != null && vehiclesData.Tables.Count > 0 && vehiclesData.Tables[0].Rows.Count > 0)
                {
                    // Map the results to a list of VehicleDetailsModel
                    return vehiclesData.Tables[0].AsEnumerable()
                        .Select(row => new VechileDetailsModel
                        {
                            VehicleID = row.Field<int>("VehicleID"),
                            Make = row.Field<string>("Make"),
                            Model = row.Field<string>("Model"),
                            Year = row.Field<int>("Year"),
                            Color = row.Field<string>("Color"),
                            TagNumber = row.Field<string>("TagNumber"),
                            VehiclePictureFromDB = row.Field<byte[]?>("VehiclePicture"),
                           
                        }).ToList();
                }

                return VehicleList; 
            }
            catch (Exception ex)
            {
              
            
                throw; // Preserve stack trace and rethrow
            }
        }

        public string DeleteVechileDetails(int vehicleId)
        {
            try
            {
                string error = "";
                var param = new Dictionary<string, dynamic>
                {
                    { "@VehicleID", vehicleId }
                };

                var vehicleData = SQLHelper.ExecuteDataset("SP_DeleteMyProfileHouseOwnerVechileDetails", param);

                if (vehicleData != null && vehicleData.Tables.Count > 0 && vehicleData.Tables[0].Rows.Count > 0)
                {
                
                    error=vehicleData.Tables[0].Rows[0][0].ToString();
                }

                return error;
            }
            catch (Exception ex)
            {

                throw ex; // Preserve stack trace and rethrow
            }
        }


    }
}
