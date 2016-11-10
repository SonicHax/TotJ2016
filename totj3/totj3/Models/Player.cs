using System;
using System.Collections.Generic;
using System.Text;

namespace totj3.Models
{
    class Player : Model
    {
        public int playerID;
        public string location;
        public string nickName;
        public int room;
        public int vehicle;
        public int hat;

        public Player(string n, int v, int h)
        {
            this.nickName = n;
            this.vehicle = v;
            this.hat = h;
        }
        
        public Player()
        {
            this.playerID = AccountState.playerID;
            this.location = AccountState.location;
            this.nickName = AccountState.nickName;
            this.room = AccountState.room;
            this.vehicle = AccountState.vehicle;
            this.hat = AccountState.hat;
        }                                
                                                     
        public void PlayerToPlayerState()            
        {
            AccountState.playerID = this.playerID;
            AccountState.location = this.location;
            AccountState.nickName = this.nickName;
            AccountState.room = this.room;
            AccountState.vehicle = this.vehicle;
            AccountState.hat = this.hat;
        }
    }
}
