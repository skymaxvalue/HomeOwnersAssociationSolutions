using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingModel
{
    public class MyProfileUpdateModel
    {
        public int? ProfileId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }

        public string PrimaryEmail { get; set; }
        public string? SecondryEmail { get; set; }
        public string PrimaryContact { get; set; }

        public string? SecondryContact { get; set; }
        public string? OfficeContact { get; set; }
        public string? MailingAddress { get; set; }
        public byte[]? LoginImage { get; set; }

        public string? photoPreviewUrl { get; set; }


        public List<VechileDetailsModel> VechileDetails { get; set; }

    }
}
