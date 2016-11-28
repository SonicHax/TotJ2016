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
            this.AddTile(tagInfo);              
        }

        private void AddTile(string tagInfo)
        {
            if(board.layout.Count < 3)
            {
                board.layout.Add(tagInfo);
                TextView mainText = FindViewById<TextView>(Resource.Id.BoardScan_text_main);
                mainText.Append(tagInfo + "\n");
            }else if(board.layout.Count == 3)
            {
                board.layout.Add(tagInfo);
                TextView mainText = FindViewById<TextView>(Resource.Id.BoardScan_text_main);
                mainText.Append(tagInfo + "\n");
                board.setBoard();
                Toast.MakeText(this, "HET WERKT", ToastLength.Long).Show();
            }

        }
    }
}