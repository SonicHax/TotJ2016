using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace totj3.Models
{
    class LocalLibrary
    {
        public List<Item> items;
        public List<Quest> quests;
        public List<Event> events;
        public List<Tile> tiles;
        public Board board;

        public LocalLibrary()
        {
            string itemsResult = CRUD.simpleRequest("select * from item");
            string[] itemSplitResult = itemsResult.Split('*');
            foreach (string item in itemSplitResult)
            {
                items.Add(JsonConvert.DeserializeObject<Item>(item));
            }

            string questsResult = CRUD.simpleRequest("select * from quest");
            string[] questSplitResult = questsResult.Split('*');
            foreach (string quest in questSplitResult)
            {
                quests.Add(JsonConvert.DeserializeObject<Quest>(quest));
            }

            string tilesResult = CRUD.simpleRequest("select * from tile");
            string[] tileSplitResult = tilesResult.Split('*');
            foreach (string tile in tileSplitResult)
            {
                tiles.Add(JsonConvert.DeserializeObject<Tile>(tile));
            }

            string incidentsResult = CRUD.simpleRequest("select * from event");
            string[] incidentSplitResult = incidentsResult.Split('*');
            foreach (string incident in incidentSplitResult)
            {
                events.Add(JsonConvert.DeserializeObject<Event>(incident));
            }

            board = JsonConvert.DeserializeObject<Board>(CRUD.simpleRequest("select * from board where roomID = " + RoomState.roomID));
            
        }
    }
}
