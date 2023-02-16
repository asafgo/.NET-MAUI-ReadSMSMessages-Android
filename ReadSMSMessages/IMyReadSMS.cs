using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadSMSMessages
{
    public interface IMyReadSMS
    {
        Task<bool> RequestPermissions();
        Task<List<string>> getAllSms();
    }
}
