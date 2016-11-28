using Android.Content;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace totj3.Models
{
    public class Board : Model
    {
        public List<string> layout;

        public Board()
        {
            layout = new List<string>();
        }

        public void setBoard()
        {
            string jsonLayout = JsonConvert.SerializeObject(layout, Formatting.None);
            string query = "INSERT INTO `totj`.`board` (`boardID`, `active`, `roomID`, `layout`) VALUES(NULL, 'true', '1', '"+ jsonLayout + "')";

            CRUD.simpleRequest(query);
        }
    }
}
