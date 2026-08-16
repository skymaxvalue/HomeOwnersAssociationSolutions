using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    internal static class OTPHelper
    {
        public static string GenerateOTP(int userId)
        {
            string numbers = "0123456789";
            Random random = new Random();
            char[] otp = new char[5];

            for (int i = 0; i < 5; i++)
            {
                otp[i] = numbers[random.Next(numbers.Length)];
            }
            UpdateOTP(userId, new string(otp));
            return new string(otp);
        }


        public static void UpdateOTP(int userId,string otp)
        {
            try
            {
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserId", userId);
                param.Add("OTP", otp);
                var userdetails = SQLHelper.ExecuteDataset("SP_UpdateOTP", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
