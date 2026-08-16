using DAL.Helper;
using Microsoft.Extensions.Primitives;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Implementation
{
    public class UMmenu
    {

        public List<Menutree> BuildMenu(string username)
        {
			try
			{
                

                StringBuilder menuString=new StringBuilder();
				List<UMmenuModel> usermenu = GetMenuFromDB( username);
                var parentmenu = usermenu.Where(x => x.URL == "").ToList();
                List< Menutree > mainmenus = new List< Menutree >();
               

                foreach (var pmenu in parentmenu)
                {
                    Menutree mainmenu = new Menutree();
                    List<SubMenu> submenus = new List<SubMenu>();
                    var usermenulist = usermenu.Where(x => x.ParentMenuID == pmenu.MenuID).ToList();
                    mainmenu.MenuName= pmenu.MenuItemName;
                    mainmenu.Icon = pmenu.MenuItemIcon;

                    foreach (var umenu in usermenulist)
                    {
                        SubMenu subMenu = new SubMenu();

                        subMenu.SubMenuName=umenu.MenuItemName;
                        subMenu.URL = umenu.URL;
                        submenus.Add(subMenu);
                    }
                    mainmenu.SubMenu =submenus;
                    mainmenus.Add(mainmenu);

                }

                return mainmenus;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

		public List<UMmenuModel> GetMenuFromDB(string username) {

            try
            {
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>();
                param.Add("UserName", username);
              
                List<UMmenuModel> menulist = new List<UMmenuModel>();

                var menudata = SQLHelper.ExecuteDataset("SP_GetUserMenu", param);
                if (menudata != null && menudata.Tables.Count > 0 && menudata.Tables[0].Rows.Count > 0)
                {
                    menulist = menudata.Tables[0].AsEnumerable()
                               .Select(row => new UMmenuModel
                               {

                                   MenuID = row.Field<int>("MenuID"),
                                   ParentMenuID = row.Field<int>("ParentMenuID"),
                                   URL = row.Field<string>("URL"),
                                   MenuItemName = row.Field<string>("MenuItemName"),
                                   MenuItemDescription = row.Field<string>("MenuItemDescription"),
                                   MenuItemIcon= row.Field<string>("MenuItemIcon"),

                               }).ToList();

                }
                return menulist;
            }
            catch (Exception)
            {

                throw;
            }
		}

        
    }
}
