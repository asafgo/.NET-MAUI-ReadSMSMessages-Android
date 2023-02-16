using Android.Content;
using Android.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadSMSMessages.Platforms
{
    public class MyReadSMS : IMyReadSMS
    {
        public async Task<List<string>> getAllSms()
        {
            List<string> list = new List<string>();

            try
            {
                string INBOX = "content://sms/inbox";
                string[] reqCols = new string[] { "_id", "thread_id", "address", "person", "date", "body", "type" };
                Android.Net.Uri uri = Android.Net.Uri.Parse(INBOX);
                var cursor = Android.App.Application.Context.ContentResolver.Query(uri, reqCols, null, null, null);

                if (cursor.MoveToFirst())
                {
                    do
                    {
                        String messageId = cursor.GetString(cursor.GetColumnIndex(reqCols[0]));
                        String threadId = cursor.GetString(cursor.GetColumnIndex(reqCols[1]));
                        String address = cursor.GetString(cursor.GetColumnIndex(reqCols[2]));
                        String name = cursor.GetString(cursor.GetColumnIndex(reqCols[3]));
                        String date = cursor.GetString(cursor.GetColumnIndex(reqCols[4]));
                        String msg = cursor.GetString(cursor.GetColumnIndex(reqCols[5]));
                        String type = cursor.GetString(cursor.GetColumnIndex(reqCols[6]));
                      
                        list.Add(address);

                    } while (cursor.MoveToNext());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
            await Task.Delay(10).ConfigureAwait(false); //Just to make it Awaitable 
            return list;
        }

        public async Task<bool> RequestPermissions()
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.Sms>();
            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }
    }
}
