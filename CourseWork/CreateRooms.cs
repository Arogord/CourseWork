using CourseWork.ContactWithUser;
using CourseWork.Data;
using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class CreateRooms
    {
        List<Room> rooms;
        UserInterface userInterface;
        public CreateRooms(UserInterface userInterface, List<Room> rooms)
        {
            this.rooms = rooms;
            this.userInterface = userInterface;
        }
        public void AddRoom()
        {
            userInterface.MessageToUser("Please enter a name for the new room:");
            string name = userInterface.InfoFomUser();
            rooms.Add(new Room(name));
        }
        
    }
}
