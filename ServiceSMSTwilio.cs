using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Evaluation2SMS
{
    public class ServiceSMSTwilio : IServiceSMS
    {

        public string SID { get; set; }
        public string Token { get; set; }
        public string Telephone { get; set; }

        public ServiceSMSTwilio(string sID, string token, string telephone)
        {
            SID = sID;
            Token = token;
            Telephone = telephone;
        }

        public ServiceSMSTwilio()
        {
        }

        public int EnvoyerSMS(SMS unSMS)
        {

            //TwilioClient.Init("AC38fb9015966fcd28e3f91dc8b3fb64db", "b9f5dd44406762926e00ae0b892abfed");

            try {
                
            TwilioClient.Init(SID, Token);
           

            var message = MessageResource.Create(
                body: unSMS.Message,
                from: new Twilio.Types.PhoneNumber(Telephone),
                to: new Twilio.Types.PhoneNumber(unSMS.Destinataire)
            );
            unSMS.Expediteur = Telephone;

            Console.WriteLine(message.Sid);
            }
            catch
            {
                return -1;
            }


            return 1;
        }
    }
}
