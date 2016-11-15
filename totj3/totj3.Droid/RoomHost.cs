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
                Room rooms = (Room) CRUD.List("room");
                // Check if name already exists in rooms
                foreach (Room room in rooms.room)
                {
                    if (room.name == nickName.Text && room.active == true)
                    {
                        error.Text = "Deze kamernaam is al ingebruik";
                    } else
                    {
                        CRUD.Insert("room", new Room(nickName.Text, true, selectedPlayers, AccountState.playerID));
                        room.RoomToRoomState();
                    }
                    if(room.active == false)
                    {
                        CRUD.Delete("room", room.roomID);
                    }
                    
                }
                
            };


        }
    }
}