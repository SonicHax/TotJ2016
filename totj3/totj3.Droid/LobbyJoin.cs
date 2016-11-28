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
using System.Threading;

namespace totj3.Droid
{
    [Activity(Label = "LobbyJoin")]
    public class LobbyJoin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LobbyJoin);
            
            Button btnStop = FindViewById<Button>(Resource.Id.LobbyJoin_btn_Stop);

            TextView roomName = FindViewById<TextView>(Resource.Id.LobbyJoin_text_RoomName);
            TextView player1 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p1);
            TextView player2 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p2);
            TextView player3 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p3);
            TextView player4 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p4);

            int currentPlayers = 1;

            roomName.Text = RoomState.name + " (" + currentPlayers + " / " + RoomState.players + ")";
            RoomState.p1 = new Models.Account(true);
            player1.Text = AccountState.nickName;
            switch (RoomState.players)
            {
                case 4:
                    RoomState.p4 = new Models.Account(false);
                    RoomState.p3 = new Models.Account(false);
                    RoomState.p2 = new Models.Account(false);
                    break;
                case 3:
                    RoomState.p3 = new Models.Account(false);
                    RoomState.p2 = new Models.Account(false);
                    player4.Text = "";
                    break;
                case 2:
                    RoomState.p2 = new Models.Account(false);
                    player3.Text = "";
                    player4.Text = "";
                    break;
            }

            Thread thread = new Thread(() =>
            {
                updateLoop();
            });
            thread.Start();

            btnStop.Click += delegate
            {
                CRUD.simpleRequest("UPDATE `account` SET `roomID`= NULL WHERE accountID =" + RoomState.p1.accountID);

                RoomState.p1 = null;
                RoomState.p2 = null;
                RoomState.p3 = null;
                RoomState.p4 = null;

                StartActivity(typeof(Main));
            };

        }

        public void updateLoop()
        {
            string started = "";
            TextView roomName = FindViewById<TextView>(Resource.Id.LobbyJoin_text_RoomName);

            while (RoomState.currentPlayers != RoomState.players)
            {
                string currentPlayers = CRUD.simpleRequest("SELECT * FROM `account` WHERE roomID = '" + RoomState.roomID + "'");
                string[] current = currentPlayers.Split('*');
                RoomState.currentPlayers = current.Length;
                switch (current.Length)
                {
                    case 1:
                        RoomState.p1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[0]);
                        RoomState.p2 = new Models.Account(false);
                        RoomState.p3 = new Models.Account(false);
                        RoomState.p4 = new Models.Account(false);
                        break;
                    case 2:
                        RoomState.p1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[0]);
                        RoomState.p2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[1]);
                        RoomState.p3 = new Models.Account(false);
                        RoomState.p4 = new Models.Account(false);
                        break;
                    case 3:
                        RoomState.p1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[0]);
                        RoomState.p2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[1]);
                        RoomState.p3 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[2]);
                        RoomState.p4 = new Models.Account(false);
                        break;
                    case 4:
                        RoomState.p1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[0]);
                        RoomState.p2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[1]);
                        RoomState.p3 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[2]);
                        RoomState.p4 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[3]);
                        break;
                }

                started = CRUD.simpleRequest("SELECT started as `result` from room where roomID = " + RoomState.roomID);
                if (started == "true")
                {
                    StartActivity(typeof(Game));
                }

                RunOnUiThread(() =>
                {
                    roomName.Text = RoomState.name + " (" + RoomState.currentPlayers + " / " + RoomState.players + ")";

                    TextView player1 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p1);
                    player1.Text = RoomState.p1.nickName;
                    TextView player2 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p2);
                    player2.Text = RoomState.p2.nickName;
                    TextView player3 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p3);
                    player3.Text = RoomState.p3.nickName;
                    TextView player4 = FindViewById<TextView>(Resource.Id.LobbyJoin_text_p4);
                    player4.Text = RoomState.p4.nickName;
                });

                Thread.Sleep(2500);
            }
            if(started == "true")
            {
                this.StopLockTask();
            }
        }
    }
}