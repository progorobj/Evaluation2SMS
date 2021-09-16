using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation2SMS
{
    public class CompteSMS
    {

        public IServiceSMS Service { get; set; } = new ServiceSMSTwilio();

        public List<SMS> SMSEnvoyes { get; set; } = new List<SMS>();

        public List<SMS> SMSRejetés { get; set; } = new List<SMS>();

        public CompteSMS(IServiceSMS service, List<SMS> sMSEnvoyes, List<SMS> sMSRejetés)
        {
            Service = service;
            SMSEnvoyes = sMSEnvoyes;
            SMSRejetés = sMSRejetés;
        }

        public CompteSMS()
        {
        }


        public string ajouterSMSEnvoye(SMS unsms)
        {
            string etat = "";


            if (!String.IsNullOrEmpty(unsms.Destinataire) &&  !String.IsNullOrEmpty(unsms.Message))
            {
                int resultat = Service.EnvoyerSMS(unsms);

                if (resultat == 1)
                {
                    SMSEnvoyes.Add(unsms);
                    etat = "Ajouté";
                }
                else
                {

                    SMSRejetés.Add(unsms);
                    etat = "Rejeté";
                }

            }
            else
                throw new ArgumentException("Le Destinaitaire et le Message sont requis !");



            return etat;

        }



        public override bool Equals(object obj)
        {
            return obj is CompteSMS sMS &&
                   EqualityComparer<IServiceSMS>.Default.Equals(Service, sMS.Service) &&
                   EqualityComparer<List<SMS>>.Default.Equals(SMSEnvoyes, sMS.SMSEnvoyes) &&
                   EqualityComparer<List<SMS>>.Default.Equals(SMSRejetés, sMS.SMSRejetés);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Service, SMSEnvoyes, SMSRejetés);
        }
    }
}
