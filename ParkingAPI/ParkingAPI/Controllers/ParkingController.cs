using BAL.Contract;
using BAL.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingModel;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        IParkingBAL _IParkingBAL;
        public ParkingController(IParkingBAL iParkingBAL)
        {
            _IParkingBAL = iParkingBAL;
        }


        [HttpPost]
        [Route("ParkingRequestWorkFlowUpdate")]

        public IActionResult ParkingRequestWorkFlowUpdate(ParkingRequestModel parkingRequest)
        {
            try
            {
                var status = _IParkingBAL.ParkingRequestWorkFlowUpdate(parkingRequest);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating the Parking Request details", message = ex.Message });
            }
        }




        [HttpGet]
        [Route("GetParkingRequest/{ParkingRequestId}")]

        public IActionResult ParkingRequestGet(int ParkingRequestId)
        {
            try
            {
                var data = _IParkingBAL.GetParkingRequest(ParkingRequestId);
                return Ok(new { message = data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while getting Parking details.", message = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetAllParkingRequest/{username}")]

        public IActionResult ParkingRequestGetAll(string username)
        {
            try
            {
                var data = _IParkingBAL.GetAllParkingRequest(username);
                return Ok(new { message = data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while getting Parking details.", message = ex.Message });
            }
        }




        [HttpGet]
        [Route("GetAllTowingCompanyAssignments/{username}")]

        public IActionResult GetAllTowingCompanyAssignments(string username)
        {
            try
            {
                var data = _IParkingBAL.GetAllTowingCompanyAssignments(username);
                return Ok(new { message = data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while getting Parking details.", message = ex.Message });
            }
        }



        [HttpGet]
        [Route("GetAllHOAAssignments/{username}")]

        public IActionResult GetAllHOAAssignments(string username)
        {
            try
            {
                var data = _IParkingBAL.GetAllHOAAssignments(username);
                return Ok(new { message = data });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while getting Parking details.", message = ex.Message });
            }
        }

    }
}
