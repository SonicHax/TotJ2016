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

            btnNext.Click += delegate
            {
                List<Model> list = CRUD.List("room", "?filter=name,eq," + nickName.Text);
                Room room = (Room) list[0];
                Console.WriteLine(room.name);

                //?filter=name,eq,abc,
                //CRUD.Select("room", new Room(nickName, true, selectedPlayers, AccountState.playerID));
                //Room room = new Room();

            };


        }
    }
}