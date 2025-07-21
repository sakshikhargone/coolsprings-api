

using Microsoft.Identity.Client;

namespace MyFirstAPI.Services
{
    public interface ISmsService
    {
        bool Send(Sms sms);
    }

    public class SmsService : ISmsService
    {
        public bool Send(Sms sms)
        {
            try
            {
                var twilio = Environment.GetEnvironmentVariable("TwilioCreds");
                Console.WriteLine(twilio);
                var twilioCreds = twilio.Split(';');
                var accountSid = twilioCreds[0];
                var authToken = twilioCreds[1];
                TwilioClient.Init(accountSid, authToken);
                var messageOptions = new CreateMessageOptions(new PhoneNumber($"+91{sms.ToPhoneNumber}"));
                messageOptions.Body = sms.Content;
                messageOptions.From = twilioCreds[2];
                MessageResource.Create(messageOptions);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

    public class Sms
    {
        public string Content { get; set; }
        public string ToPhoneNumber { get; set; }
    }
}