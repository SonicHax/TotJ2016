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

namespace totj3.Droid.Resources
{
    [Activity(Label = "Lobby")]
    public class Lobby : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Lobby);

            Button btnPlay = FindViewById<Button>(Resource.Id.buttonPlay);

            if(AccountState.playerID == RoomState.host)
            {
                btnPlay.Clickable = true;
            }
            else
            {
                btnPlay.Clickable = false;
            }
            btnPlay.Click += delegate
            {

                StartActivity(typeof(Game));
            };
        }
    }
}