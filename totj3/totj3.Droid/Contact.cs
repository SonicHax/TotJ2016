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
    [Activity(Label = "Contact")]
    public class Contact : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Contact);

            Button btnBackToStart = FindViewById<Button>(Resource.Id.contact_button_backToStart);

            btnBackToStart.Click += delegate
            {
                StartActivity(typeof(Start));
            };
        }
    }
}