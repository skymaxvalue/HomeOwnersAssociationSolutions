using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingModel
{
    public class LoggedInUserModel
    {
        public byte[] UserImage { get; set; }
        public string FirstName { get; set; }
        public List<MenuPermisssion> MenuPermission { get; set; }
        public string UserRole { get; set; }
        public int UserRoleId { get; set; }
         


    }
}
