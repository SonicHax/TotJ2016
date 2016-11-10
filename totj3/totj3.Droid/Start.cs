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
    [Activity(Label = "Start")]
    public class Start : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Start);

            Button btnPlay = FindViewById<Button>(Resource.Id.Start_btn_Play);

            btnPlay.Click += delegate
            {
                StartActivity(typeof(Main));
            };
        }
    }
}