using BAL.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingModel;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutController : ControllerBase
    {
        ILayoutBAL _iILayoutBAL;
        public LayoutController(ILayoutBAL layoutBAL)
        {
            _iILayoutBAL = layoutBAL;

        }


        [HttpGet]
        [Route("GetMenu/{username}")]

        public IActionResult GetMenu(string username)
        {
            try
            {
                var menu = _iILayoutBAL.GetMenu(username);
                return Ok(new { message = menu });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while Getting Menu", message = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetLoggedInUserDetails/{username}")]
        public IActionResult  GetLoggedInUserDetails(string username)
        {
            try
            {
                var userdetails = _iILayoutBAL.GetLoggedInUserDetails(username);
                return Ok(new { message = userdetails });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while Getting Menu", message = ex.Message });
            }
        }
    }
}
