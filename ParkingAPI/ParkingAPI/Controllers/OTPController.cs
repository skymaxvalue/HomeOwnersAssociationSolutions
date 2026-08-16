using BAL.Contract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParkingModel;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        IOTPBAL _iOTPBAL;
        public OTPController(IOTPBAL otp)
        {
            _iOTPBAL = otp;

        }

        [HttpPost]
        [Route("ValidateOTP")]

        public IActionResult ValidateOTP(OTPModel otpdata)
        {
            try
            {
                var status = _iOTPBAL.ValidateOTP(otpdata);
                return Ok(new { message = status });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while generating OTP", message = ex.Message });
            }
        }
    }


}
