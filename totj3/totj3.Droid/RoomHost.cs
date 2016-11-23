using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using totj3.Models;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace totj3.Droid
{
    [Activity(Label = "RoomHost")]
    public class RoomHost : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RoomHost);

            int selectedPlayers = 2;
            RadioButton radio1 = FindViewById<RadioButton>(Resource.Id.RoomHost_radio2);
            RadioButton radio2 = FindViewById<RadioButton>(Resource.Id.RoomHost_radio3);
            RadioButton radio3 = FindViewById<RadioButton>(Resource.Id.RoomHost_radio4);

            radio1.Click += delegate
            {
                selectedPlayers = 2;
            };
            radio2.Click += delegate
            {
                selectedPlayers = 3;
            };
            radio3.Click += delegate
            {
                selectedPlayers = 4;
            };

            Button btnNext = FindViewById<Button>(Resource.Id.RoomHost_btn_Next);
            EditText nickName = FindViewById<EditText>(Resource.Id.RoomHost_et_RoomName);
            TextView error = FindViewById<TextView>(Resource.Id.RoomHost_text_error);

            btnNext.Click += delegate
            {
                string roomName = CRUD.simpleRequest("select roomID from room where name = '" + nickName.Text + "' and active = 'true'");
                if (roomName != "TRUE")
                {
                    error.Text = "Deze kamernaam is al ingebruik";
                } else {
                    Room room = new Room(nickName.Text, "true", selectedPlayers, AccountState.playerID);
                    CRUD.simpleRequest("INSERT INTO `totj`.`room` (`roomID`, `name`, `active`, `players`, `host`) VALUES (NULL, '" + nickName.Text + "', 'true', '" + selectedPlayers + "', '" + AccountState.playerID + "');");

                    room.roomID = Int32.Parse(CRUD.simpleRequest("select max(roomID) as `result` from room"));
                    room.RoomToRoomState();
                    CRUD.simpleRequest("UPDATE `player` SET `roomID`=['" + room.roomID + "'] WHERE playerID =" + AccountState.playerID + ")");
                    StartActivity(typeof(LobbyHost));
                }
            };
        }
    }
}