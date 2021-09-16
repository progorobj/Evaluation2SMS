using System;
using System.Collections.Generic; 
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types; 

namespace Evaluation2SMS
{
    class Program
    {
        static void Main(string[] args)
        {
            /* // Find your Account SID and Auth Token at twilio.com/console
             // and set the environment variables. See http://twil.io/secure
             string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
             string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

             //TwilioClient.Init("AC38fb9015966fcd28e3f91dc8b3fb64db", "b9f5dd44406762926e00ae0b892abfed");
             TwilioClient.Init(accountSid, authToken);
             var message = MessageResource.Create(
                 body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                 from: new Twilio.Types.PhoneNumber("+18057386717"),
                 to: new Twilio.Types.PhoneNumber("+15149996039")
             );

             Console.WriteLine(message.Sid);*/

            SMS unsms = new SMS();
            unsms.Destinataire = "+15149996039";
            unsms.Message = "Bonjour Mr ZIED HAJJI";
            ServiceSMSTwilio unservice = new ServiceSMSTwilio("AC38fb9015966fcd28e3f91dc8b3fb64db", "b9f5dd44406762926e00ae0b892abfed", "+18057386717");

            CompteSMS unCompte = new CompteSMS();

            unCompte.Service = unservice;
            unCompte.ajouterSMSEnvoye(unsms);
            foreach (SMS item in unCompte.SMSEnvoyes)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine(unservice.EnvoyerSMS(unsms));
            Console.WriteLine(unsms.ToString());
        }
    }
}
