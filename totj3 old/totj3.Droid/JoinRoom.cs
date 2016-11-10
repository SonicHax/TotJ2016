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
    [Activity(Label = "JoinRoom")]
    public class JoinRoom : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.JoinRoom);
            
            Button btnJoinGame = FindViewById<Button>(Resource.Id.btnJoinGame);
            Button btnJoinBack = FindViewById<Button>(Resource.Id.btnJoinBack);
            EditText eTRoomName = FindViewById<EditText>(Resource.Id.editTextRoomName);

            btnJoinBack.Click += delegate
            {
                StartActivity(typeof(Start));
            };

            btnJoinGame.Click += delegate
            {
                CRUD.ReadCheck("name", "room", "active = true AND name = '" + eTRoomName.Text + "'");
            };
        }
    }
}