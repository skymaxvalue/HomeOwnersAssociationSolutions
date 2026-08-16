using BAL.Contract;
using DAL.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthServiceController : ControllerBase
    {
        IAuthBAL _iauthBAL;
        private readonly IHttpContextAccessor _ihttpContextAccessor;
        public AuthServiceController(IAuthBAL iauthBAL, IHttpContextAccessor httpContextAccessor)
        {
            _iauthBAL = iauthBAL;
            _ihttpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("Authenticate")]

        public IActionResult Authenticate()
        {
            try
            {
                //var result = _iauthBAL.Authenticate(username);
                return Ok(new { message = "Success" });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while Getting Menu", message = ex.Message });
            }
        }

    }
}
