using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using totj3.Models;

namespace totj3.Droid
{
    [Activity(Label = "Game")]
    public class Game : Activity
    {
        public bool started = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Game);

            //TODO: Host: bord inscannen
            //TODO: Rest moet wachten

            // Game start:
            Thread thread = new Thread(() =>
            {
                updateLoop();
            });
            thread.Start();
            LocalLibrary localGameState = new LocalLibrary();
        }

        public void updateLoop()
        {
            if (!started)
            {
                Board check = Newtonsoft.Json.JsonConvert.DeserializeObject<Board>(CRUD.simpleRequest("Select * from board where roomID = " + RoomState.roomID));
                LocalLibrary localGameState = new LocalLibrary();
            }
            else
            {
                Board check = Newtonsoft.Json.JsonConvert.DeserializeObject<Board>(CRUD.simpleRequest("Select * from board where roomID = " + RoomState.roomID));
                if()
            }
            if (check != "TRUE")
            {

            }

        }
    }
}