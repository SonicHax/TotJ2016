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
    [Activity(Label = "LobbyHost")]
    public class LobbyHost : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LobbyHost);

            Button btnStart = FindViewById<Button>(Resource.Id.LobbyHost_btn_Start);
            Button btnStop = FindViewById<Button>(Resource.Id.LobbyHost_btn_Stop);

            TextView roomName = FindViewById<TextView>(Resource.Id.LobbyHost_text_RoomName);
            TextView player1 = FindViewById<TextView>(Resource.Id.LobbyHost_text_p1);
            TextView player2 = FindViewById<TextView>(Resource.Id.LobbyHost_text_p2);
            TextView player3 = FindViewById<TextView>(Resource.Id.LobbyHost_text_p3);
            TextView player4 = FindViewById<TextView>(Resource.Id.LobbyHost_text_p4);

            int currentPlayers = 1;

            roomName.Text = RoomState.name + " (" + currentPlayers + " / " + RoomState.players + ")";
            player1.Text = AccountState.nickName;
            if(RoomState.players < 4)
            {
                player4.Text = "";
            }
            if(RoomState.players < 3)
            {
                player3.Text = "";
            }

            btnStart.Click += delegate
            {
                if(currentPlayers == RoomState.players)
                {
                    //start game
                }
            };

            btnStop.Click += delegate
            {
                /*RoomState.p1.room = 0;
                RoomState.p2.room = 0;
                RoomState.p3.room = 0;
                RoomState.p4.room = 0;

                CRUD.Delete("room", RoomState.roomID);

                CRUD.Update("player", RoomState.p1.playerID, RoomState.p1);
                CRUD.Update("player", RoomState.p2.playerID, RoomState.p2);
                CRUD.Update("player", RoomState.p3.playerID, RoomState.p3);
                CRUD.Update("player", RoomState.p4.playerID, RoomState.p4);

                StartActivity(typeof(Main));*/
            };
        }
        
    }
}