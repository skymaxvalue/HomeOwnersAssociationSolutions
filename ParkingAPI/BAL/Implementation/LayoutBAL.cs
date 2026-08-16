using BAL.Contract;
using DAL.Contract;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Implementation
{
    public class LayoutBAL:ILayoutBAL
    {


        ILayoutDAL _iLayoutDAL;

        public LayoutBAL(ILayoutDAL layoutDAL)
        {
            _iLayoutDAL = layoutDAL;
        }

        public LoggedInUserModel GetLoggedInUserDetails(string username)
        {
            try
            {

                return _iLayoutDAL.GetLoggedInUserDetails(username);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Menutree> GetMenu(string username)
        {
            try
            {
                
                    return _iLayoutDAL.GetMenu(username);
                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
