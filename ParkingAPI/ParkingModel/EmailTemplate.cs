using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingModel
{
    public class EmailTemplate
    {
        public int NotificationTemplateId { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }
        public string Subject { get; set; }
        public string DefaultToAddress { get; set; }
        public string DefaultCCAddress { get; set; }
        public string DefaultBCCAddress { get; set; }


    }





    public class EMailInputs
    {
        public int EmailTemplateId { get; set; }
        //public string Subject { get; set; }
        //public string Headlines { get; set; }
        public List<string> Content { get; set; }
        public string ToAddress { get; set; }

    }

}
