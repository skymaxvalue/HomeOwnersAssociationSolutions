using BAL.Contract;
using DAL.Contract;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Implementation
{
    public class ProfileBAL : IMyProfileBAL
    {
        IMyProfileDAL _IMyProfileDAL;
        public ProfileBAL(IMyProfileDAL iMyProfileDAL)
        {
            _IMyProfileDAL= iMyProfileDAL;
        }

        public List<VechileDetailsModel> GetAllVehicleDetails(string username)
        {
            try
            {
                return _IMyProfileDAL.GetAllVehicleDetails(username);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MyProfileUpdateModel GetUserProfileDetails(string username)
        {
            try
            {
                return _IMyProfileDAL.GetUserProfileDetails(username);
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
                return _IMyProfileDAL.GetVehicleDetails(vehicleId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        public string DeleteVechileDetails(int vehicleId)
        {
            try
            {
                return _IMyProfileDAL.DeleteVechileDetails(vehicleId);
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
                return _IMyProfileDAL.HouseOwnerAssociationDetailsUpdate(houseOwnerAssociationDetails);
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
                return _IMyProfileDAL.HouseOwnerDetailsUpdate(houseOwnerDetails); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string MyProfileHouseOwnerVechileDetailsSave(VechileDetailsModel vechileDetail)
        {
            try
            {
                return _IMyProfileDAL.MyProfileHouseOwnerVechileDetailsSave(vechileDetail);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string MyProfileUpdate(MyProfileUpdateModel myProfile)
        {
            try
            {
                return _IMyProfileDAL.MyProfileUpdate(myProfile);
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
                return _IMyProfileDAL.TowingCompanyDetailsUpdate(towingCompanyDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





    }
}
