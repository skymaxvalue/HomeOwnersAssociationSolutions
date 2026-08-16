using BAL.Contract;
using BAL.Implementation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingModel;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")] // Apply CORS policy to controller
    [ApiController]
    public class MyProfileController : ControllerBase
    {
        IMyProfileBAL _IProfileBAL;
        public MyProfileController(IMyProfileBAL iMyProfileBAL)
        {
            _IProfileBAL= iMyProfileBAL;
        }


        [HttpPost]
        [Route("MyProfileUpdate")]

        public IActionResult MyProfileUpdate(MyProfileUpdateModel profile)
        {
            try
            {
                var status = _IProfileBAL.MyProfileUpdate(profile);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating the profile details.", message = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetUserProfileDetails/{username}")]

        public IActionResult GetUserProfileDetails(string username)
        {
            try
            {
                var data = _IProfileBAL.GetUserProfileDetails(username);
                return Ok(new {message =  data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while getting user profile details.", message = ex.Message });
            }
        }

        [HttpPost]
        [Route("TowingCompanyDetailsUpdate")]

        public IActionResult TowingCompanyDetailsUpdate(TowingCompanyDetailsModel towingCompanyDetails)
        {
            try
            {
                var status = _IProfileBAL.TowingCompanyDetailsUpdate(towingCompanyDetails);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating the Towing Company details", message = ex.Message });
            }
        }


        [HttpPost]
        [Route("HouseOwnerDetailsUpdate")]

        public IActionResult HouseOwnerDetailsUpdate(HouseOwnerDetailsModel houseOwner)
        {
            try
            {
                var status = _IProfileBAL.HouseOwnerDetailsUpdate(houseOwner);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating the houseOwner details", message = ex.Message });
            }
        }


        [HttpPost]
        [Route("MyProfileHouseOwnerVechileDetailsSave")]

        public IActionResult MyProfileHouseOwnerVechileDetailsSave(VechileDetailsModel vechileDetail)
        {
            try
            {
                var status = _IProfileBAL.MyProfileHouseOwnerVechileDetailsSave(vechileDetail);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating the houseOwner details", message = ex.Message });
            }
        }




        [HttpGet]
        [Route("GetVehicleDetails/{vehicleId}")]

        public IActionResult GetVehicleDetails(int vehicleId)
        {
            try
            {
                var data = _IProfileBAL.GetVehicleDetails(vehicleId);
                return Ok(new { message = data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while getting Vehicle details.", message = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetAllVehicleDetails/{username}")]

        public IActionResult GetAllVehicleDetails(string username)
        {
            try
            {
                var data = _IProfileBAL.GetAllVehicleDetails(username);
                return Ok(new { message = data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while getting Vehicle details.", message = ex.Message });
            }
        }




        [HttpGet]
        [Route("DeleteVechileDetails/{vehicleId}")]

        public IActionResult DeleteVechileDetails(int vehicleId)
        {
            try
            {
                var data = _IProfileBAL.DeleteVechileDetails(vehicleId);
                return Ok(new { message = data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while .Deleting Vehicle details.", message = ex.Message });
            }
        }


        [HttpPost]
        [Route("HouseOwnerAssociationDetailsUpdate")]

        public IActionResult HouseOwnerAssociationDetailsUpdate(HouseOwnerAssociationDetailsModel hoaModel)
        {
            try
            {
                var status = _IProfileBAL.HouseOwnerAssociationDetailsUpdate(hoaModel);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating the HouseOwner Association Details", message = ex.Message });
            }
        }
    }
}
