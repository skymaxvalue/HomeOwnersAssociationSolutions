using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Contract
{
    public interface ISignUpBAL
    {
        public string NewUserAccountCreation(SignUpModel newuser);
        public List<LoadValue> LoadHOAMaster();
    }
}
