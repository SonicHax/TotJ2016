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

namespace totj3.Droid
{
    [Activity(Label = "Main")]
    public class Main : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Create your application here

            Button btnHost = FindViewById<Button>(Resource.Id.Main_Btn_Host);
            Button btnBoardScan = FindViewById<Button>(Resource.Id.Main_Btn_BoardScan);
            Button btnJoin = FindViewById<Button>(Resource.Id.Main_btn_join);

            btnHost.Click += delegate
            {
                if(AccountState.playerID != 0)
                {
                    StartActivity(typeof(RoomHost));
                }
                else
                {
                    AccountState.host = true;
                    StartActivity(typeof(PlayerCreate));
                }
            };

            btnBoardScan.Click += delegate
            {
                StartActivity(typeof(BoardScan));
            };

            btnJoin.Click += delegate
            {
                if (AccountState.playerID != 0)
                {
                    StartActivity(typeof(RoomJoin));
                }
                else
                {
                    AccountState.host = false;
                    StartActivity(typeof(PlayerCreate));
                }
            };
        }
    }
}