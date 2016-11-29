using System;
using System.Collections.Generic;
using System.Text;

namespace totj3.Models
{
    class Treasure
    {
        int found;
        Location location;

        public Treasure()
        {
            found = 0;
            location = new Location();
        }
    }
}
