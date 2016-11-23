using Android.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace totj3.Models
{
    public class Board : Model
    {
        public List<string> tiles;

        public Board()
        {
            tiles = new List<string>();
        }

    }
}
