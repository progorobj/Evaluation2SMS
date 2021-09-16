using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation2SMS
{
    public interface IServiceSMS
    {
        public int EnvoyerSMS(SMS unSMS);
    }
}
