using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation2SMS
{
    public class SMS
    {
        public string Expediteur { get; set; }
        public string Destinataire { get; set; }
        public string Message { get; set; }

        public SMS(string expediteur, string destinataire, string message)
        {
            Expediteur = expediteur;
            Destinataire = destinataire;
            Message = message;
        }

        public SMS()
        {
        }

       

        public override bool Equals(object obj)
        {
            return obj is SMS sMS &&
                   Expediteur == sMS.Expediteur &&
                   Destinataire == sMS.Destinataire &&
                   Message == sMS.Message;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Expediteur, Destinataire, Message);
        }

        public override string ToString()
        {
            return String.Format($"Le Message : {Message} est envoyé par {Expediteur} au " +
                $"Destinaire :{Destinataire}");
        }
    }
}
