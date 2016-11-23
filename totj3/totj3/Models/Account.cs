using System;
using System.Collections.Generic;
using System.Text;

namespace totj3.Models
{
    public class Account : Model
    {
        public int playerID;
        public string location;
        public string nickName;
        public int roomID;
        public int vehicle;
        public int hat;

        public Account(string n, int v, int h)
        {
            this.nickName = n;
            this.vehicle = v;
            this.hat = h;
        }

        public Account() { }

        public Account(bool b)
        {
            if (b)
            {
                this.playerID = AccountState.playerID;
                this.location = AccountState.location;
                this.nickName = AccountState.nickName;
                this.roomID = AccountState.room;
                this.vehicle = AccountState.vehicle;
                this.hat = AccountState.hat;
            }
            else
            {
                playerID = 0;
            }
        }                                
                                                     
        public void PlayerToPlayerState()            
        {
            AccountState.playerID = this.playerID;
            AccountState.location = this.location;
            AccountState.nickName = this.nickName;
            AccountState.room = this.roomID;
            AccountState.vehicle = this.vehicle;
            AccountState.hat = this.hat;
        }

    }
}
