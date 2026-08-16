using BAL.Contract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParkingModel;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")] // Apply CORS policy to controller
    [ApiController]

    public class LogInController : ControllerBase
    {
        ILoginBAL _iLoginBAL;
        public LogInController(ILoginBAL login)
        {
            _iLoginBAL = login;

        }

        [HttpPost]
        [Route("SignIn")]

        public IActionResult SignIn(LogInModel logindata)
        {
            try
            {
                var status = _iLoginBAL.SignIn(logindata);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while LogIn", message = ex.Message });
            }
        }
    }
}
