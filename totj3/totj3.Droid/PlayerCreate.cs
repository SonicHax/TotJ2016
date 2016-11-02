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
    [Activity(Label = "PlayerCreate")]
    public class PlayerCreate : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PlayerCreate);

            Button btnSavePlayer = FindViewById<Button>(Resource.Id.button1);

            btnSavePlayer.Click += delegate
            {
                EditText editTextNickName = FindViewById<EditText>(Resource.Id.editNickname);
                EditText editTextHat = FindViewById<EditText>(Resource.Id.editTextHat);
                EditText editTextOutside= FindViewById<EditText>(Resource.Id.editTextOutside);
                EditText editTextInside = FindViewById<EditText>(Resource.Id.editTextInside);

                if (editTextNickName.Text.Length > 0 &&
                editTextHat.Text.Length > 0 &&
                editTextOutside.Text.Length > 0 &&
                editTextInside.Text.Length > 0)
                {
                    btnSavePlayer.Clickable = false;
                    string playerAddSucces = CRUD.Create("player", "nickName, outside, inside, hat", "'" + editTextNickName.Text + "'," + editTextOutside.Text + "," + editTextInside.Text + "," + editTextHat.Text);
                    int.TryParse(playerAddSucces, out AccountState.playerID);
                    if(AccountState.playerID > 0)
                    {
                        AccountState.name = editTextNickName.Text;
                        int.TryParse(editTextInside.Text, out AccountState.vehicleInside);
                        int.TryParse(editTextOutside.Text, out AccountState.vehicleOutside);
                        int.TryParse(editTextHat.Text, out AccountState.vehicleHat);
                        StartActivity(typeof(Start));
                    }
                    else
                    {
                        btnSavePlayer.Clickable = true;
                    }
                }
            };


        }
    }
}