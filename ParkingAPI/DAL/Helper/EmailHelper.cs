using ParkingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Helper.EmailHelper;

namespace DAL.Helper
{
    internal class EmailHelper
    {
        public static async Task<bool> SendEmail(EMailInputs template)
        {
            try
            {
                    var emailNotificationTemplate = GetEmailTemplate(template.EmailTemplateId);
                    var body = constants.FormatBodyContent(template.Content, emailNotificationTemplate.Definition);
                    SMTPHelper.SendEmail(template.ToAddress+","+emailNotificationTemplate.DefaultToAddress,
                        emailNotificationTemplate.DefaultCCAddress, emailNotificationTemplate.DefaultBCCAddress,
                        "", emailNotificationTemplate.Subject, body, 0, null, true);
                    return true;
              
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }


    

        public static class constants
        {
            public static string TEMPLATE_VAR_SEPARATOR = "|~$~|";

            public static string FormatBodyContent(List<string> Content, string Definition)
            {
                string[] beforeFormat = { };
                var templateVariable = string.Join(constants.TEMPLATE_VAR_SEPARATOR, Content);
                if (!string.IsNullOrEmpty(templateVariable))
                {
                    beforeFormat = templateVariable.Split(new string[] { constants.TEMPLATE_VAR_SEPARATOR }, StringSplitOptions.None);
                }
                var template = beforeFormat != null && beforeFormat.Length > 0 ? 
                    string.Format(Definition, beforeFormat) 
                    : string.Empty;
                return template;
            }
        }


        public static EmailTemplate GetEmailTemplate(int templateid)
        {
            try
            {
                var emailTemplate = new EmailTemplate();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
                parameters.Add("NotificationTemplateId", templateid);
                var emaildt= SQLHelper.ExecuteDataset("SP_GetNotificationTemplate", parameters);
                if (emaildt!=null && emaildt.Tables.Count>0&& emaildt.Tables[0].Rows.Count>0)
                {


                    emailTemplate = emaildt.Tables[0].AsEnumerable()
                                  .Select(row => new EmailTemplate
                                  {
                                      NotificationTemplateId = row.Field<int>("NotificationTemplateId"),
                                      Name = row.Field<string>("Name"),
                                      Subject= row.Field<string>("Subject"),
                                      Definition = row.Field<string>("Definition"),
                                      DefaultToAddress = row.Field<string>("DefaultToAddress"),
                                      DefaultCCAddress = row.Field<string>("DefaultCCAddress"),
                                      DefaultBCCAddress = row.Field<string>("DefaultBCCAddress"),


                                  }).FirstOrDefault();
                                    

                }

                return emailTemplate;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
