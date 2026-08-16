using BAL.Contract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParkingModel;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")] // Apply CORS policy to controller

    [ApiController]
    public class SignUpController : ControllerBase
    {

        ISignUpBAL _iSignUpBAL;
        public SignUpController(ISignUpBAL signUp)
        {
            _iSignUpBAL = signUp;

        }

        [HttpPost]
        [Route("NewUserAccountCreation")]

        public IActionResult NewUserAccountCreation(SignUpModel newuser)
        {
            try
            {
                var status= _iSignUpBAL.NewUserAccountCreation(newuser);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while creating the user account.", message = ex.Message });
            }
        }

        [HttpGet]
        [Route("LoadHOAMaster")]
        public IActionResult LoadHOAMaster()
        {
            try
            {
                var status = _iSignUpBAL.LoadHOAMaster();
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while loading HOA Master", message = ex.Message });
            }

        }
    }
}
