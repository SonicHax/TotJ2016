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

class TimerExampleState
{
    public int counter = 0;
    public Timer tmr;
}

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

            TimerExampleState s = new TimerExampleState();

            // Create the delegate that invokes methods for the timer.
            TimerCallback timerDelegate = new TimerCallback(CheckStatus);

            // Create a timer that waits one second, then invokes every second.
            Timer timer = new Timer(timerDelegate, s, 1000, 1000);

            // Keep a handle to the timer, so it can be disposed.
            s.tmr = timer;

            // The main thread does nothing until the timer is disposed.
            while (s.tmr != null)
                Thread.Sleep(0);
            Console.WriteLine("Timer example done.");
        

            btnStart.Click += delegate
            {
                if(currentPlayers == RoomState.players)
                {
                    //start game
                }
            };

            btnStop.Click += delegate
            {
                if (RoomState.players == 4)
                {
                    RoomState.p3.roomID = 0;
                    if (RoomState.p3.playerID != 0)
                    {
                        CRUD.simpleRequest("UPDATE `player` SET `roomID`=[NULL] WHERE playerID =" + RoomState.p3.playerID);
                    }
                    RoomState.p2.roomID = 0;
                    if (RoomState.p2.playerID != 0)
                    {
                        CRUD.simpleRequest("UPDATE `player` SET `roomID`=[NULL] WHERE playerID =" + RoomState.p2.playerID);
                    }
                    RoomState.p4.roomID = 0;
                    if (RoomState.p2.playerID != 0)
                    {
                        CRUD.simpleRequest("UPDATE `player` SET `roomID`=[NULL] WHERE playerID =" + RoomState.p4.playerID);
                    }
                }
                if (RoomState.players == 3)
                {
                    RoomState.p3.roomID = 0;
                    if (RoomState.p3.playerID != 0)
                    {
                        CRUD.simpleRequest("UPDATE `player` SET `roomID`=[NULL] WHERE playerID =" + RoomState.p3.playerID);
                    }
                    RoomState.p2.roomID = 0;
                    if (RoomState.p2.playerID != 0)
                    {
                        CRUD.simpleRequest("UPDATE `player` SET `roomID`=[NULL] WHERE playerID =" + RoomState.p2.playerID);
                    }
                }
                if (RoomState.players == 2)
                {
                    RoomState.p2.roomID = 0;
                    if (RoomState.p2.playerID != 0)
                    {
                        CRUD.simpleRequest("UPDATE `player` SET `roomID`=[NULL] WHERE playerID =" + RoomState.p2.playerID);
                    }
                }
                RoomState.p1.roomID = 0;
                CRUD.simpleRequest("UPDATE `player` SET `roomID`=[NULL] WHERE playerID =" + RoomState.p1.playerID);
                
                CRUD.simpleRequest("DELETE FROM `totj`.`room` WHERE `room`.`roomID` = " + RoomState.roomID);
                StartActivity(typeof(Main));
            };
        }

        static void CheckStatus(Object state)
        {
            TimerExampleState s = (TimerExampleState)state;
            s.counter++;



            string currentPlayers = CRUD.simpleRequest("SELECT * FROM `player` WHERE roomID = '" + RoomState.roomID + "'");
            string[] current = currentPlayers.Split('*');
            RoomState.currentPlayers = current.Length; 
            switch (current.Length)
            {
                case 1:
                    RoomState.p1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[0]);
                    break;
                case 2:
                    RoomState.p1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[0]);
                    RoomState.p2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[1]);
                    break;
                case 3:
                    RoomState.p1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[0]);
                    RoomState.p2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[1]);
                    RoomState.p3 = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Account>(current[2]);
                    break;
            }
           /* if (s.counter == 5)
            {
                // Shorten the period. Wait 10 seconds to restart the timer.
                (s.tmr).Change(10000, 100);
                Console.WriteLine("changed...");
            }
            if (s.counter == 10)
            {
                Console.WriteLine("disposing of timer...");
                s.tmr.Dispose();
                s.tmr = null;
            }*/
        }
    }
}