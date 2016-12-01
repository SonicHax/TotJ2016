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
using Newtonsoft.Json;

namespace totj3.Droid
{
    [Activity(Label = "BoardScan")]
    public class BoardScan : Activity
    {
        NFCController nfcController;
        Board board;
        ImageView[] tiles = new ImageView[30];
        int counter = 0;
        Button btnUndo;
        Button btnNext;
        CheckBox checkPreset;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BoardScan);

            nfcController = new NFCController(this);
            board = new Board();

            btnUndo = FindViewById<Button>(Resource.Id.BoardScan_Btn_Undo);
            btnNext = FindViewById<Button>(Resource.Id.BoarScan_Btn_Next);
            checkPreset = FindViewById<CheckBox>(Resource.Id.BoardScan_Checbox_Preset);

            checkPreset.CheckedChange += delegate
            {
                if(btnNext.Enabled == false)
                {
                    btnNext.Enabled = true;
                }else
                {
                    btnNext.Enabled = false;
                }
            };

            btnUndo.Click += delegate
            {
                Undo();
            };

            btnNext.Click += delegate
            {
                onNext();
            };

            for(int i=1; i<=30; i++)
            {
                string viewID = "imageView" + i;
                int resId = Resources.GetIdentifier(viewID, "id", PackageName);
                ImageView imageView = FindViewById<ImageView>(resId);
                imageView.SetImageResource(Resource.Drawable.kitten);
            }
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
            if(counter < 30)
            {
                board.layout.Add(tagInfo);
                counter++;
                string viewID = "imageView" + counter;
                int resId = Resources.GetIdentifier(viewID, "id", PackageName);

                ImageView image = FindViewById<ImageView>(resId);
                image.SetImageResource(Resource.Drawable.Untitled1);

                if(counter == 30)
                {
                    btnNext.Enabled = true;
                }   
            }
        }

        private void Undo()
        {
            if(counter != 0)
            {
                int lastIndex = board.layout.Count - 1;
                board.layout.Remove(board.layout[lastIndex]);
                counter--;

                string viewID = "imageView" + (counter + 1);
                int resId = Resources.GetIdentifier(viewID, "id", PackageName);

                ImageView image = FindViewById<ImageView>(resId);
                image.SetImageResource(Resource.Drawable.kitten);
            }
        }

        private void onNext()
        {
            CRUD.simpleRequest("UPDATE `totj`.`room` SET `started` = 'true' WHERE `room`.`roomID` = " + RoomState.roomID);
            string jsonLayout;
            string query;

            if (checkPreset.Checked)
            {
                jsonLayout = "['1','2','3','4','5','6','7','8','9','10','11','12','13','14','15','16','17','18','19','20','21','22','23'"
                     + ",'24','25','26','27','28','29','30']";

                query = "INSERT INTO `totj`.`board` (`active`, `roomID`, `layout`) VALUES('true', 1, \"" + jsonLayout + "\")";
            }
            else
            {
                jsonLayout = JsonConvert.SerializeObject(board.layout, Formatting.None);

                query = "INSERT INTO `totj`.`board` (`active`, `roomID`, `layout`) VALUES('true', 1,'" + jsonLayout + "')";
            }


            CRUD.simpleRequest(query);

            StartActivity(typeof(Game));
        }
    }
}