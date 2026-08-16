using DAL.Contract;
using DAL.Helper;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class LayoutDAL:ILayoutDAL
    {
        UMmenu _mymenu;
        public LayoutDAL()
        {
            _mymenu = new UMmenu();
        }

        public List<Menutree> GetMenu(string username)
        {
            try
            {

                return _mymenu.BuildMenu(username);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public LoggedInUserModel GetLoggedInUserDetails(string username)
        {

            try
            {
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", username);

                LoggedInUserModel userData = new LoggedInUserModel();

                var user = SQLHelper.ExecuteDataset("SP_GetLoggedInUserDetails", param);
                if (user != null && user.Tables.Count > 0 && user.Tables[0].Rows.Count > 0)
                {
                    userData = user.Tables[0].AsEnumerable()
                               .Select(row => new LoggedInUserModel
                               {
                                   FirstName = row.Field<string?>("FirstName"),
                                   UserImage = row.Field<byte[]?>("UserImage"),
                                   UserRole = row.Field<string?>("UserRole"),
                                   UserRoleId = row.Field<int>("UserRoleId"),
                               }).FirstOrDefault();


                }
                return userData;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
