using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading;

namespace totj3.Models
{
    class GameState
    {
        public int currentTurn;
        public Player[] players;
        public Treasure treasure;
        public Event[] events;

        public GameState(bool t)
        {
            currentTurn = 1;

            // Host
            if (t)
            {

            }
            // Join
            else
            {

            }           
        }

        public void submitGameState()
        {
            CRUD.simpleRequest("UPDATE `totj`.`game` SET `Gamestate` = '" + JsonConvert.SerializeObject(this) + "' where roomID = " + RoomState.roomID);
        }

        public GameState getGameState()
        {
            return JsonConvert.DeserializeObject<GameState>(CRUD.simpleRequest("select Gamestate from game where roomID = " + RoomState.roomID));
        }
    }
}
