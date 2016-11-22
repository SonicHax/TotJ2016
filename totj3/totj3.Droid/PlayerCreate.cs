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
    [Activity(Label = "PlayerCreate")]
    public class PlayerCreate : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Player);

            Button btnNext = FindViewById<Button>(Resource.Id.Player_btn_Next);

            string nickName;
            int vehicle = 1;
            int hat = 1;
            
            btnNext.Click += delegate
            {
                nickName = FindViewById<EditText>(Resource.Id.Player_et_Nickname).Text;

                Player player = new Player(nickName, vehicle, hat);

                CRUD.Insert("player", "?nickname='" + nickName + "'&hat=1&vehicle=1");
                player.playerID = CRUD.getMaxID("player", "playerID");

                player.PlayerToPlayerState();

                StartActivity(typeof(RoomHost));

            };

            RadioButton radioHat1 = FindViewById<RadioButton>(Resource.Id.Player_radio_hat1);
            radioHat1.Click += delegate { hat = 1; };
            RadioButton radioHat2 = FindViewById<RadioButton>(Resource.Id.Player_radio_hat2);
            radioHat2.Click += delegate { hat = 2; };
            RadioButton radioHat3 = FindViewById<RadioButton>(Resource.Id.Player_radio_hat3);
            radioHat3.Click += delegate { hat = 3; };

            RadioButton radioVehicle1 = FindViewById<RadioButton>(Resource.Id.Player_radio_vehicle1);
            radioVehicle1.Click += delegate { hat = 1; };
            RadioButton radioVehicle2 = FindViewById<RadioButton>(Resource.Id.Player_radio_vehicle2);
            radioVehicle2.Click += delegate { hat = 2; };
            RadioButton radioVehicle3 = FindViewById<RadioButton>(Resource.Id.Player_radio_vehicle3);
            radioVehicle3.Click += delegate { hat = 3; };
        }
    }
}