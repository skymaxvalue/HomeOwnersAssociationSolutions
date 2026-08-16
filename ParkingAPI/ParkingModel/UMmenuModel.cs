using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ParkingModel
{
    public class UMmenuModel
    {
        public int MenuID { get; set; }
        public string URL { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public string MenuItemIcon { get; set; }
        public int? ParentMenuID { get; set; }
    }


    public class Menutree
    {
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public List<SubMenu> SubMenu { get; set; }

    }


    public class SubMenu
    {
        public string SubMenuName { get; set; }
        public string URL { get; set; }

    }


    public class MenuPermisssion
    {
        
    }

}
