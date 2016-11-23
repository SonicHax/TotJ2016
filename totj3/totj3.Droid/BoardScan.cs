using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Nfc;

namespace totj3.Droid
{
    [Activity(Label = "BoardScan")]
    public class BoardScan : Activity
    {
        NfcAdapter adapter;
        PendingIntent pendingIntent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BoardScan);

            adapter = NfcAdapter.GetDefaultAdapter(this);
            if(adapter == null)
            {
                //nfc not supported
                return;
            }

            pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, this.GetType()).AddFlags(ActivityFlags.SingleTop), 0);
        }

        protected override void OnResume()
        {
            base.OnResume();
            adapter.EnableForegroundDispatch(this, pendingIntent, null, null);
        }

        protected override void OnPause()
        {
            base.OnPause();
            if(adapter != null)
            {
                adapter.DisableForegroundDispatch(this);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            getTagInfo(intent);
        }

        private void getTagInfo(Intent intent)
        {
            Tag tag = intent.GetParcelableExtra(NfcAdapter.ExtraTag) as Tag;
            Toast.MakeText(this, tag.ToString(), ToastLength.Long);
        }
    }
}