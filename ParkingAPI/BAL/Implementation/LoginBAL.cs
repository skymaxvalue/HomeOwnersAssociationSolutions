using BAL.Contract;
using DAL.Contract;
using DAL.Implementation;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Implementation
{
   
    public class LoginBAL:ILoginBAL
    {
        ILogInDAL _iLogInDAL;

        public LoginBAL(ILogInDAL loginDAL)
        {
            _iLogInDAL = loginDAL;
        }

        public string SignIn(LogInModel loginData)
        {
            try
            {
                var isUserDetailsareValid = IsUserCredentialsareValid(loginData);
                if (!(isUserDetailsareValid.Length > 0))
                {
                    return _iLogInDAL.SignIn(loginData);
                }
                else
                {
                    return "Error:" + isUserDetailsareValid;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string IsUserCredentialsareValid(LogInModel loginData)
        {
            try
            {

                return _iLogInDAL.IsUserCredentialsareValid(loginData);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
