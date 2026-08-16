using DAL.Helper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkingModel;
using System.Reflection.PortableExecutable;
using System.Web.Http.Results;

namespace ParkingAPI.Helper
{
    public class RequestAuthorizationFilter:IActionFilter
    {
        private readonly IHttpContextAccessor _ihttpContextAccessor;

        public RequestAuthorizationFilter(IHttpContextAccessor httpContextAccessor)
        {
            _ihttpContextAccessor = httpContextAccessor;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var _httpcontext = _ihttpContextAccessor;
            var request = _httpcontext.HttpContext.Request;
            var response = _httpcontext.HttpContext.Response;

            string controller = request.RouteValues.Where(x => x.Key == "controller").FirstOrDefault().Value.ToString();
            string action = request.RouteValues.Where(x => x.Key == "action").FirstOrDefault().Value.ToString();

            if ((controller == "OTP" && action == "ValidateOTP"))
            {
                if (context.Result is OkObjectResult okObjectResult)
                {
           
                    var isUsersAuthenticated = okObjectResult.Value.ToString().Contains("Success:Authenticated");
                    if (isUsersAuthenticated)
                    {
                        //response.Headers.Remove("authorization");
                        //response.Headers.Remove("authorizationTokenUser");
                        //var userkey = CryptoHelper.EncryptParkingUser();
                       
                        //response.Headers.Add("authorizationToken", userkey[0]);
                        ////response.Headers.Add("authorizationTokenUser", userkey[1]==null?"": userkey[1]);

                        //response.Headers.Add("access-control-expose-headers", "authorization");

                    }

                }

               
            }
            else
            {

                //string sessionvalue = response.Headers.TryGetValue("authorization", out var values) ? values.FirstOrDefault() : null;
                //if (sessionvalue != null)
                //{
                //    UserSessionModel userSessionModel = CryptoHelper.DecryptParkingUser(sessionvalue);
                //    TimeSpan duration = userSessionModel.Timestamp.Subtract(DateTime.Now);
                //    if (duration.Minutes > 30)
                //    {
                //        //context.Result = "";
                //    }
                //}
                //else
                //{
                //    //context.Result = "";
                //}

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var _httpcontext = _ihttpContextAccessor;
            var request = _httpcontext.HttpContext.Request;
            var response = _httpcontext.HttpContext.Response;

            string controller = request.RouteValues.Where(x => x.Key == "controller").FirstOrDefault().Value.ToString();
            string action = request.RouteValues.Where(x => x.Key == "action").FirstOrDefault().Value.ToString();

            if ((controller != "LogIn" && action != "SignIn") && (controller != "OTP" && action != "ValidateOTP"))
            {

                string token1 = request.Headers.TryGetValue("authorization", out var tV) ? tV.FirstOrDefault() : null;
                string token2 = request.Headers.TryGetValue("authorizationTokenUser", out var tv1) ? tv1.FirstOrDefault() : null;

                //var tokens = CryptoHelper.Base64StringToHashSet(token1+ "☻" + token2);
                //var isValidToken = CryptoHelper.DecryptParkingUser(tokens);


                //if (isValidToken != null)
                //{
                //        response.StatusCode = StatusCodes.Status400BadRequest;
                //        response.ContentType = "application/json";
                //        //var message = new { Ok = "User Token is Valid" };
                //        //context.Result = new JsonResult(message);

                //}
                //else
                //{

                //    response.StatusCode = StatusCodes.Status400BadRequest;
                //    response.ContentType = "application/json";
                //    var message = new { Ok = "Invalid Login" };
                //    context.Result = new JsonResult(message);
                //}


            }


        }
    }
}
