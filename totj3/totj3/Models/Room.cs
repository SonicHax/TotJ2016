using System;
using System.Collections.Generic;
using System.Text;

namespace totj3.Models
{
    public class Room : Model
    {
        public int roomID;
        public string name;
        public string active;
        public int players;
        public int host;
        public Room[] room;

        public Room(string n, string a, int p, int h){
            this.name = n;
            this.active = a;
            this.players = p;
            this.host = h;
        }

        public Room()
        {
            this.roomID = RoomState.roomID;
            this.name = RoomState.name;
            this.active = RoomState.active;
            this.players = RoomState.players;
            this.host = RoomState.host;
        }

        public void RoomToRoomState()
        {
            RoomState.roomID = this.roomID;
            RoomState.name = this.name;
            RoomState.active = this.active;
            RoomState.players = this.players;
            RoomState.host = this.host;
        }

    }
}
