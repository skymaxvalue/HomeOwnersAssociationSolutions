using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class CommonHelper
    {
        public static Byte[] FromBase64StringToByteArray(string base64String)
        {
            // Remove the data URL scheme prefix
            string base64Data = base64String.Substring(base64String.IndexOf(',') + 1);

            // Convert Base64 string to byte array
            byte[] imageData = Convert.FromBase64String(base64Data);


            return imageData;
        }
    }
}
