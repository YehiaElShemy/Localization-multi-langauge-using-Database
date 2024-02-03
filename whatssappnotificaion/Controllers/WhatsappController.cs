using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using whatssappnotificaion.Models;

namespace whatssappnotificaion.Controllers
{
    public class WhatsappController : Controller
    {
     
        public IActionResult Index<T>(string message )
        {
           // int[] x=new int[1];
            T[] std =new T[5];
            Type type = std.GetType();//method returns the Type of the current data
            Type type2 = typeof(Student);
            return Content((type2.Name));
            // get Assembly of variable t using the Assembly property
            type2.GetDefaultMembers();


            // Make sure to replace these values with your actual Twilio API key, API secret, and phone number
            string apiKey = "your_api_key";
            string apiSecret = "your_api_secret";
            string phoneNumber = "+201003259927";

            TwilioClient.Init(apiKey, apiSecret);

            // Use the Twilio.Types.PhoneNumber type for sender and target
            var sender = new PhoneNumber("whatsapp:+201064822587");
            var target = new PhoneNumber($"whatsapp:{phoneNumber}");

            // Create message options
            var options = new CreateMessageOptions(target)
            {
                From = sender,
                Body = message
            };

            // Use try-catch block to handle potential exceptions
            try
            {
                // Send the message
                var result = MessageResource.Create(options);

                // Optionally, you can log the result or perform additional actions

                return View();
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or return an error view
                return View("Error");
            }
        }
    }
}
