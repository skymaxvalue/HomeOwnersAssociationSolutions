using DAL.Contract;
using DAL.Helper;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class OTPDAL: IOTPDAL
    {
        public string ValidateOTP(OTPModel otpModel)
        {
            try
            {

                string errors = "";
                
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", otpModel.UserName);
                param.Add("EmailId", otpModel.EmailId);
                param.Add("MobileNumber", otpModel.MobileNumber);
                param.Add("OTP", otpModel.OTP);

                var validationResults = SQLHelper.ExecuteDataset("SP_ValidateOTP", param);
                if (validationResults != null && validationResults.Tables.Count > 0 && validationResults.Tables[0].Rows.Count > 0)
                {
                    errors = validationResults.Tables[0].Rows[0][0].ToString();
                }
                return errors;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
