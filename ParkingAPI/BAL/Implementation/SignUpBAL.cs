using BAL.Contract;
using DAL.Contract;
using ParkingModel;
using System.Net.Http.Headers;


namespace BAL.Implementation
{
  
    public class SignUpBAL: ISignUpBAL
    {
        ISignUpDAL _iSignUpDAL;
        public SignUpBAL(ISignUpDAL signupDAL)
        {
            _iSignUpDAL = signupDAL;
        }

        public string NewUserAccountCreation(SignUpModel newuser)
        {
            try
            {
                var isUserDetailsareValid = IsUserDetailsAlreadyExists(newuser);
                if (!(isUserDetailsareValid.Length > 0))
                {
                    return _iSignUpDAL.NewUserAccountCreation(newuser);
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

        public string IsUserDetailsAlreadyExists(SignUpModel newuser)
        {
            try
            {

                return _iSignUpDAL.IsUserDetailsAlreadyExists(newuser);
                

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

                return _iSignUpDAL.LoadHOAMaster();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
