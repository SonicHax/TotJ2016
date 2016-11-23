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
using totj3.Models;

namespace totj3.Droid
{
    [Activity(Label = "BoardScan")]
    public class BoardScan : Activity
    {
        NFCController nfcController;
        Board board;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BoardScan);

            nfcController = new NFCController(this);

            board = new Board();
        }

        protected override void OnResume()
        {
            base.OnResume();
            nfcController.adapter.EnableForegroundDispatch(this, nfcController.pendingIntent, null, null);
        }

        protected override void OnPause()
        {
            base.OnPause();
            if(nfcController.adapter != null)
            {
                nfcController.adapter.DisableForegroundDispatch(this);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            string tagInfo = nfcController.getTagInfo(intent);
            board.tiles.Add(tagInfo);
            Toast.MakeText(this, tagInfo, ToastLength.Long).Show();
        }
    }
}