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
using totj3.Droid.Resources;

namespace totj3.Droid
{
    [Activity(Label = "Start")]
    public class Start : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Start);
            // Create your application here
            
            Button btnHost = FindViewById<Button>(Resource.Id.buttonHost);
            btnHost.Click += delegate
            {
                StartActivity(typeof(BoardSetup));
            };

            Button btnJoin = FindViewById<Button>(Resource.Id.buttonJoin);
            btnJoin.Click += delegate
            {
                StartActivity(typeof(JoinRoom));
            };
            
            Button btnSettings = FindViewById<Button>(Resource.Id.buttonSettings);
            btnSettings.Click += delegate
            {
                StartActivity(typeof(Settings));
            };

            Button btnContact = FindViewById<Button>(Resource.Id.buttonContact);
            btnContact.Click += delegate
            {
                StartActivity(typeof(Contact));
            };

            Button btnCredits = FindViewById<Button>(Resource.Id.buttonCredits);
            btnCredits.Click += delegate
            {
                StartActivity(typeof(Credits));
            };

        }
    }
}