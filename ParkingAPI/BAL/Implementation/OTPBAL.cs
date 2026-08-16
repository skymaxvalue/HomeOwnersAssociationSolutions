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
    public class OTPBAL:IOTPBAL
    {
        IOTPDAL _iOTPDAL;
        public OTPBAL(IOTPDAL otpDAL)
        {
            _iOTPDAL = otpDAL;
        }

        public string ValidateOTP(OTPModel loginDetail)
        {
            try
            {
                
                    return _iOTPDAL.ValidateOTP(loginDetail);
 

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
