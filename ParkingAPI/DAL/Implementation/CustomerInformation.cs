using DAL.Helper;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class CustomerInformation
    {
        public CustomerInformationModel GetCustomerInformation(string username)
        {
            try
            {
                
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", username);
                CustomerInformationModel cust=new CustomerInformationModel();
                var userdetails = SQLHelper.ExecuteDataset("SP_GetUserDetails", param);

                if (userdetails != null && userdetails.Tables.Count > 0 && userdetails.Tables[0].Rows.Count > 0)
                {
                    cust = userdetails.Tables[0].AsEnumerable()
                                .Select(row => new CustomerInformationModel
                                {
                                    UserId = row.Field<int>("UserId"),
                                    UserName = row.Field<string>("UserName"),
                                    Password = row.Field<string>("Password"),
                                    EmailId = row.Field<string>("EmailId"),
                                    MobileNumber = row.Field<string>("MobileNumber"),
                                    PreferedOTP = row.Field<int>("PreferedOTP"),
                                    Iam = row.Field<int>("Iam"),
                                    CreatedDate = row.Field<DateTime>("CreatedDate"),
                                    CreatedBy = row.Field<string>("CreatedBy"),
                                    ModifiedDate = row.Field<DateTime?>("ModifiedDate"),
                                    ModifiedBy = row.Field<string>("ModifiedBy"),
                                    IsDeleted = row.Field<bool>("IsDeleted"),
                                    //OTP= row.Field<string>("OTP"),
                                    //OTPSent = row.Field<DateTime?>("OTPSent"),



                                }).FirstOrDefault();

                }
               

                return cust;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
