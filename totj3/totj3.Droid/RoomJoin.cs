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
                    //string room = CRUD.simpleRequest("SELECT roomID as `result` FROM `room` WHERE name = '" + roomNameInput.Text + "'and active = 'true'");
                    string resultRoom = CRUD.simpleRequest("SELECT * FROM `room` WHERE name = '" + roomNameInput.Text + "'and active = 'true'");
                    if (resultRoom != "TRUE")
                    {
                        Models.Room room = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Room>(resultRoom);

                        if (room.name != null)
                        {
                            string currentPlayers = CRUD.simpleRequest("SELECT * FROM `player` WHERE roomID = '" + room.roomID + "'");
                            string[] current = currentPlayers.Split('*');
                            if (current.Length < room.players)
                            {
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
                                CRUD.simpleRequest("UPDATE `player` SET `roomID`= " + room.roomID + " WHERE playerID = '" + AccountState.playerID + "'");
                                StartActivity(typeof(LobbyJoin));
                            }
                        }
                    }
                    else
                    {
                        error.Text = "Deze kamer bestaat niet.";
                    }
                }
                else
                {
                    error.Text = "Vul een kamernaam in!";
                }
            };
        }
    }
}