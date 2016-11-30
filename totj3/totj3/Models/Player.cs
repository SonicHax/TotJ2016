using System;
using System.Collections.Generic;
using System.Text;

namespace totj3.Models
{
    public class Player
    {
        public int accountID;
        public Location location;
        public string nickName;
        public int roomID;
        public int vehicle;
        public int hat;
        public int money;
        public int energy;
        public int treasureX;
        public int treasureY;
        public int codeRed;
        public int codeYellow;
        public int codeGreen;
        public int codeBlue;

        public Player()
        {
            accountID = AccountState.accountID;
            location = new Location();
            nickName = AccountState.nickName;
            roomID = RoomState.roomID;
            vehicle = AccountState.vehicle;
            hat = AccountState.hat;
            money = 5;
            energy = 10;
            treasureX = 0 ;
            treasureY = 0;
            codeRed = 0;
            codeYellow = 0;
            codeGreen = 0;
            codeBlue = 0;
        }
    }
}