using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingModel
{
    public class ParkingRequestModel
    {
        public int ParkingDetailsID { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }

        public VechileDetailsModel VehicleInfo { get; set; }
        public ParkingLocation ParkingLocation { get; set; }
        public DurationOfParking DurationOfParking { get; set; }

    }

    // Model for parking location
    public class ParkingLocation
    {
        public int LocationId { get; set; }
        public string Area { get; set; }
        public string ParkingPicture { get; set; }
        public byte[]? ParkingPictureFromDB { get; set; }


    }

    // Model for duration of parking
    public class DurationOfParking
    {
        public int ParkingTimeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }


    public class ParkingRequestGetAllModel
    {
        public int ParkingDetailsID { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string DocNo { get; set; }
        public byte[]? ParkingPictureFromDB { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string TagNumber { get; set; }
        public byte[]? VehiclePictureFromDB { get; set; }
    }

    public class ParkingRequestGetAllHOAAssignmentsModel
    {
        public int ParkingDetailsID { get; set; }
        public string Status { get; set; }
        public string DocNo { get; set; }

        public string Area { get; set; }

        public byte[]? ParkingPictureFromDB { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string TagNumber { get; set; }
        public byte[]? VehiclePictureFromDB { get; set; }
    }

    public class ParkingRequestGetAllTowingCompanyAssignmentsModel
    {
        public int ParkingDetailsID { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string DocNo { get; set; }
        public byte[]? ParkingPictureFromDB { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string TagNumber { get; set; }
        public byte[]? VehiclePictureFromDB { get; set; }
    }
}

