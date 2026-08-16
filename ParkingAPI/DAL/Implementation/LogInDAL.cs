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
    public class LogInDAL:ILogInDAL

    {
        static CustomerInformation _CustomerInformation;
        public LogInDAL()
        {
            _CustomerInformation = new CustomerInformation();
        }
        public string SignIn(LogInModel logindata)
        {
            try
            {
                CustomerInformationModel userdetails = _CustomerInformation.GetCustomerInformation(logindata.UserName);
               
                List<string> content = [logindata.UserName, "Login", OTPHelper.GenerateOTP(userdetails.UserId)];
                EMailInputs SignupSuccessEmail = new EMailInputs() { EmailTemplateId = 2, Content = content, ToAddress = userdetails.EmailId };
                EmailHelper.SendEmail(SignupSuccessEmail);
                return "Success:OTP Sent Successfully";
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string IsUserCredentialsareValid(LogInModel logindata)
    {
        try
        {
                
                string errors = "";
               
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", logindata.UserName);
                param.Add("Password", logindata.Password);

                             
                var validationResults = SQLHelper.ExecuteDataset("SP_IsValidUser", param);
                if (validationResults != null && validationResults.Tables.Count > 0 && validationResults.Tables[0].Rows.Count > 0)
                {
                    errors=validationResults.Tables[0].Rows[0][0].ToString();
                }
                return  errors ; 

            }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    }



}
