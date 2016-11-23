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
    [Activity(Label = "RoomJoin")]
    public class RoomJoin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RoomJoin);

            TextView roomName = FindViewById<TextView>(Resource.Id.RoomJoin_text_roomName);
            TextView error = FindViewById<TextView>(Resource.Id.RoomJoin_text_error);
            Button join = FindViewById<Button>(Resource.Id.RoomJoin_btn_Join);
            Button back = FindViewById<Button>(Resource.Id.RoomJoin_btn_back);
            EditText roomNameInput = FindViewById<EditText>(Resource.Id.RoomJoin_et_roomName);

            back.Click += delegate
            {
                StartActivity(typeof(Main));
            };  

            join.Click += delegate
             {
                 if (roomNameInput.Text != "")
                 {
                     string room = CRUD.simpleRequest("SELECT roomID FROM `room` WHERE name = '" + roomNameInput.Text + "'and active = 'true'");
                     if(room != "TRUE")
                     {
                         string currentPlayers = CRUD.simpleRequest("SELECT playerID FROM `player` WHERE roomID = '" + room + "'");
                         string maxPlayers = CRUD.simpleRequest("SELECT players FROM `room` where roomID = '" + room + "'");
                         Console.WriteLine("current       " + currentPlayers + "               max    " + maxPlayers);
                     }
                 }
             };
        }
    }
}