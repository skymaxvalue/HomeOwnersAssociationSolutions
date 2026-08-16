using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contract
{
    public interface IMyProfileDAL
    {
        public string MyProfileUpdate(MyProfileUpdateModel myProfile);
        public string TowingCompanyDetailsUpdate(TowingCompanyDetailsModel towingCompanyDetails);
        public string HouseOwnerAssociationDetailsUpdate(HouseOwnerAssociationDetailsModel houseOwnerAssociationDetails);
        public string HouseOwnerDetailsUpdate(HouseOwnerDetailsModel houseOwnerDetails);
        public MyProfileUpdateModel GetUserProfileDetails(string username);
        public string MyProfileHouseOwnerVechileDetailsSave(VechileDetailsModel vechileDetail);
        public List<VechileDetailsModel> GetAllVehicleDetails(string username);
        public VechileDetailsModel GetVehicleDetails(int vehicleId);
        public string DeleteVechileDetails(int vehicleId);

    }
}
