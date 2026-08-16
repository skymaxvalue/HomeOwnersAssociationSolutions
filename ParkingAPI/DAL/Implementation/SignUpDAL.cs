using DAL.Contract;
using DAL.Helper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using ParkingModel;
using System.Data;


namespace DAL.Implementation
{

    public class SignUpDAL : ISignUpDAL
    {
        public SignUpDAL()
        {

        }

        public string NewUserAccountCreation(SignUpModel newuser)
        {

            try
            {
                string newUserCreationStatus = "Pending";
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", newuser.UserName);
                param.Add("Password", newuser.Password);
                param.Add("EmailId", newuser.EmailId);
                param.Add("MobileNumber", newuser.MobileNumber);
                param.Add("PreferedOTP", ParkingMasterEnum.GetEnumValue(newuser.PreferedOTP));
                param.Add("Iam", ParkingMasterEnum.GetEnumValue(newuser.Iam));
                param.Add("HOAId", Convert.ToInt16(newuser.HOAId));


                var userdetails = SQLHelper.ExecuteDataset("SP_CreateNewUser", param);
                if (userdetails != null && userdetails.Tables.Count > 0 && userdetails.Tables[0].Rows.Count > 0)
                {
                    List<string> content = [newuser.UserName, newuser.EmailId, newuser.Iam];
                    EMailInputs SignupSuccessEmail = new EMailInputs() { EmailTemplateId = 1, Content = content, ToAddress = newuser.EmailId };
                    EmailHelper.SendEmail(SignupSuccessEmail);
                    newUserCreationStatus = "Success:Your Account Created Successfully.Please Proceed to Login!";
                }
                else
                {
                    newUserCreationStatus = "Error:Unable to Create your Account at the moment";
                }

                return newUserCreationStatus;



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string IsUserDetailsAlreadyExists(SignUpModel newuser)
        {
            try
            {
                string errors = "";
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", newuser.UserName);
                param.Add("EmailId", newuser.EmailId);
                param.Add("MobileNumber", newuser.MobileNumber);

                var userdetails = SQLHelper.ExecuteDataset("SP_IsUserDetailsExists", param);
                if (userdetails != null && userdetails.Tables.Count > 0 && userdetails.Tables[0].Rows.Count > 0)
                {
                    errors = userdetails.Tables[0].Rows[0][0].ToString();
                }
                return errors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<LoadValue> LoadHOAMaster()
        {
            try
            {
               
                List<LoadValue> HOAmst = new List<LoadValue>();
              
                var hoa = SQLHelper.ExecuteDataset("SP_GetHOAMasterList");
                if (hoa != null && hoa.Tables.Count > 0 && hoa.Tables[0].Rows.Count > 0)
                {  
                    return hoa.Tables[0].AsEnumerable()
                        .Select(row => new LoadValue
                        {
                            Id = row.Field<int>("Id").ToString(),
                            Value = row.Field<string>("Value"),
                          

                        }).ToList();
                }
                return HOAmst;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
