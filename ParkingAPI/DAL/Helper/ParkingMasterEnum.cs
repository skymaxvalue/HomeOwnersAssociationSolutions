using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    static class ParkingMasterEnum
    {
        public enum ParkingMstEnum
        {
            Customer = 1,
            HOA = 2,
            TowingCompany = 3,

            Email=1,
            SMS=2

        }

        public static int GetEnumValue(string enumstring)
        {
            ParkingMstEnum pMst;
            if (!Enum.TryParse(enumstring, out pMst))
            {
                return 0;
            }

            // Get numeric value of the enum
            int enumNumber = (int)pMst;
            return enumNumber;

        }
    }
}
