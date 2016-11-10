using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace totj3.Droid.Resources
{
    [Activity(Label = "BoardSetup")]
    public class BoardSetup : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.BoardSetup);

            Button btnFinishSetup = FindViewById<Button>(Resource.Id.buttonFinishSetup);
            btnFinishSetup.Click += delegate
            {
                string eTRoomName = FindViewById<EditText>(Resource.Id.BoardSetup_editText_roomName).Text;
                string eTPlayers = FindViewById<EditText>(Resource.Id.BoardSetup_EditText_playerAmount).Text;

                btnFinishSetup.Clickable = false;
                string checkResult = CRUD.ReadCheck("name", "room", "active = true AND name = '" + eTRoomName + "'");
                btnFinishSetup.Text = checkResult;
                if(checkResult == "[]")
                {
                    int.TryParse(CRUD.Create("room", "name, active, players, host", "'" + eTRoomName + "',1, " + eTPlayers + ", " + AccountState.playerID),out RoomState.roomID);
                    RoomState.name = eTRoomName;
                    int.TryParse(eTPlayers, out RoomState.players);
                    RoomState.host = AccountState.playerID;

                    CRUD.Update("player", "roomID=" + RoomState.roomID, "playerID = " + AccountState.playerID);
                    StartActivity(typeof(Lobby));
                }
                btnFinishSetup.Clickable = true;
            };
        }
    }
}