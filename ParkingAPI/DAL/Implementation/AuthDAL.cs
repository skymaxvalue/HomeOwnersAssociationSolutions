using DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class AuthDAL : IAuthDAL
    {
        
        public bool Authenticate(string username)
        {
			try
			{
                return true;

			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
