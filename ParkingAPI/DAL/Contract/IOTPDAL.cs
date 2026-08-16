using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contract
{
    public interface IOTPDAL
    {
        public string ValidateOTP(OTPModel logindata);
    }
}
