using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingModel
{
    public class VechileDetailsModel
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string TagNumber { get; set; }
        public string? VehiclePicture { get; set; } 
        public byte[]? VehiclePictureFromDB { get; set; }

        public string UserName { get; set; }

    }
}
