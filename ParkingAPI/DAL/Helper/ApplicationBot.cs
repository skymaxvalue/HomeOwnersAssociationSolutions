
using System.Diagnostics;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


//using var cts = new CancellationTokenSource();
namespace DAL.Helper
{

    public static class ApplicationBot
    {

        static TelegramBotClient bot =new TelegramBotClient(ConfigurationHelper.GetConfig("Parkingconfig:ParkingBot"));
        static private HashSet<(long chatId, int messageId)> processedMessages = new HashSet<(long chatId, int messageId)>();
        static ApplicationBot()
        {
         
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ApplicationBotIntialise();
        }
        public static async Task ApplicationBotIntialise()
        {
            try
            {
               
                var me = await bot.GetMeAsync();
                
                //bot += OnError;
                bot.OnMessage += OnMessage;
               // bot.OnUpdate += OnUpdate;

            }
            catch (Exception ex)
            {

            }
        }

  
        static async Task OnMessage(Message msg, UpdateType type)
        {
            var promsg = new HashSet<(long chatId, int messageId)>();

            var message = msg;

            var messageId = (message.Chat.Id, message.MessageId);

            if (processedMessages!=null && processedMessages.Contains(messageId))
                return;
            promsg.Add(messageId);

            processedMessages= promsg;


            if (msg.Text == "/Start"|| msg.Text=="Hi")
            {

                await bot.SendTextMessageAsync(msg.Chat, "Welcome! Parking Solutions",
                   replyMarkup: new InlineKeyboardMarkup().AddButtons("Left", "Right"));

                await bot.SendTextMessageAsync(msg.Chat, "Hi " + msg.Chat.FirstName + " Welcome to Parking Solutions!");
                await bot.SetMyNameAsync();
                //processedMessages.Clear();
            }
        }

        static async Task OnUpdate(Update update)
        {
            if (update is { CallbackQuery: { } query })
            {
                await bot.AnswerCallbackQueryAsync(query.Id, $"You picked {query.Data}");
                await bot.SendTextMessageAsync(query.Message!.Chat, $"User {query.From} clicked on {query.Data}");
            }
        }


        public static void BotReplyandHistory(Message client, TelegramCommand parkingSolutionsResponse)
        {
            try
            {
                TelegramQueue tq = new TelegramQueue();


                TSendMsg(client.Chat.Id, parkingSolutionsResponse.AutoReply);


                tq.TelegramQueueId = 0;
                tq.ChatId = (int)client.Chat.Id;
                tq.ChatIdCcId = (int)client.Chat.Id;
                tq.Subject = "";
                tq.TemplateId = 0;
                tq.ReferenceNumber = "";
                tq.ContentBody = "";
                tq.UserMsg = client.Text.ToString();
                tq.BotReply = parkingSolutionsResponse.AutoReply;
                tq.SendAsHtml = false;
                tq.Priority = 1;
                tq.Status = 1;
                tq.SentOn = new DateTime() ;
                tq.FailedOn = null;
                tq.IsDeleted = false;
                tq.CreatedBy = 1;
                tq.CreatedDate = new DateTime();
                tq.ModifiedBy = 1;
                tq.ModifiedDate = new DateTime();

                SaveChatHistory(tq);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void TSendMsg(long chatid, string msg)
        {
            ParseMode parseMode = ParseMode.Html;
            bot.SendTextMessageAsync(chatid, msg, null,parseMode);

        }

        public static void SaveChatHistory(TelegramQueue q)
        {
            try
            {
                //Save Chat Hitsory
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static TelegramUserViewModel GetUserDetails(Message msg)
        {
            try
            {
                TelegramUserViewModel user = new TelegramUserViewModel();
                //Check if User available in DB
                // msg.Chat.Id;//input to db
                user.UserRegistrationId = 1;
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    public partial class TelegramCommand
    {
        public int TelegramCommandId { get; set; }
        public string Command { get; set; }
        public string AutoReply { get; set; }
        public string CommandGroup { get; set; }
        public Nullable<int> CommandGroupOrder { get; set; }
        public bool IsDeleted { get; set; }
    }
    public partial class TelegramQueue
    {
        public int TelegramQueueId { get; set; }
        public int ChatId { get; set; }
        public Nullable<int> ChatIdCcId { get; set; }
        public string Subject { get; set; }
        public short TemplateId { get; set; }
        public string ReferenceNumber { get; set; }
        public string ContentBody { get; set; }
        public string UserMsg { get; set; }
        public string BotReply { get; set; }
        public bool SendAsHtml { get; set; }
        public byte Priority { get; set; }
        public byte Status { get; set; }
        public Nullable<System.DateTime> SentOn { get; set; }
        public Nullable<System.DateTime> FailedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class TelegramUserViewModel
    {
        public int TelegramUserRegistrationId { get; set; }
        public int UserRegistrationId { get; set; }
        public string Telegramusername { get; set; }
        public int Chatid { get; set; }
        public string SecurityCode { get; set; }
        public Nullable<int> ConfirmationStatus { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }

        public string StaffName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateofJoined { get; set; }
        public Nullable<int> UserTypeId { get; set; }
        public Nullable<bool> IsSystemUser { get; set; }
        public Nullable<bool> IsMobileUser { get; set; }
        public Nullable<bool> IsMailSent { get; set; }
        public Nullable<System.DateTime> MailSentTime { get; set; }
        public Nullable<int> ExpiryDuration { get; set; }
        public int LoginAttempt { get; set; }


        public int Status { get; set; }
        public Nullable<bool> IsBlocked { get; set; }
        public Nullable<int> InvalidAttempts { get; set; }
        public Nullable<System.DateTime> InvalidAttemptDateTime { get; set; }
        public Nullable<System.DateTime> LoginDateTime { get; set; }
        public Nullable<System.DateTime> PasswordChangedDateTime { get; set; }
        public string MobileNumber { get; set; }
        public bool ExistingStaff { get; set; }
        public Nullable<int> UserRegisterType { get; set; }

        public string StaffEmployeeId { get; set; }
    }
}
