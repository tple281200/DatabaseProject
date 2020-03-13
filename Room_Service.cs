using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();
        public List<Room> GetRooms()
        {
            try
            {
                List<Room> room = room_db.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception)
            {
                // make some fake rooms when the program is not able to connect to the database
                List<Room> room = new List<Room>();
                Room a = new Room();
                a.Number = 2;
                a.Capacity = 4;
                a.Type = false;
                room.Add(a);

                Room b = new Room();
                b.Number = 2;
                b.Capacity = 4;
                b.Type = true;
                room.Add(b);

                return room;
                throw new Exception("Someren couldn't connect");
            }
        }
    }
}
