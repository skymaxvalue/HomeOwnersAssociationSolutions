using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contract
{
    public interface ISignUpDAL
    {
        public string NewUserAccountCreation(SignUpModel newuser);
        public string IsUserDetailsAlreadyExists(SignUpModel newuser);
        public List<LoadValue> LoadHOAMaster();

    }
}
