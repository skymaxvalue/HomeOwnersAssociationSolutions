using BAL.Contract;
using DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Implementation
{
    public class AuthBAL: IAuthBAL
    {
        IAuthDAL  _iauthDAL;
        public AuthBAL(IAuthDAL authDAL)
        {
            _iauthDAL=authDAL;
        }

       public  bool Authenticate(string username)
        {
            try
            {
                return _iauthDAL.Authenticate(username);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
