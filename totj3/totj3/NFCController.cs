using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Text;

namespace totj3
{
    public class NFCController
    {
        public NfcAdapter adapter;
        public PendingIntent pendingIntent;
        Activity currentActivity;

        public NFCController(Activity current)
        {
            currentActivity = current;
            adapter = NfcAdapter.GetDefaultAdapter(currentActivity);
            pendingIntent = PendingIntent.GetActivity(currentActivity, 0, new Intent(currentActivity, currentActivity.GetType()).AddFlags(ActivityFlags.SingleTop), 0);
        }

        public string getTagInfo(Intent intent)
        {
            IParcelable[] rawMsgs = intent.GetParcelableArrayExtra(NfcAdapter.ExtraNdefMessages);
            NdefRecord record = ((NdefMessage)rawMsgs[0]).GetRecords()[0];

            string result = System.Text.Encoding.UTF8.GetString(record.GetPayload());

            return result;
        }
    }
}
