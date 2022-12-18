using CourseWork.Data;
using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class ChangeSettings
    {
        UserInterface userInterface;
        public ChangeSettings(UserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        public void RoomChangeSettings(Room? room)
        {
            if (room != null)
            {
                userInterface.MessageToUser($"{Properties.Resources.InputCO2L1} {room.Name}:");
                room.CO2Level1 = GetParameter();
                userInterface.MessageToUser($"{Properties.Resources.InputCO2L2} {room.Name}:");
                room.CO2Level1 = GetParameter();
                userInterface.MessageToUser($"{Properties.Resources.InputGasL1} {room.Name}:");
                room.GasLvel1 = GetParameter();
                userInterface.MessageToUser($"{Properties.Resources.InputGasL2} {room.Name}:");
                room.GasLvel2 = GetParameter();
                userInterface.MessageToUser($"{Properties.Resources.InputHumidMin} {room.Name}:");
                room.HumidMin = (byte)GetParameter();
                userInterface.MessageToUser($"{Properties.Resources.InputHumidMax} {room.Name}:");
                room.HumidMax = (byte)GetParameter();
                userInterface.MessageToUser($"{Properties.Resources.InputTemperature} {room.Name}:");
                room.Temperature = GetParameter();
                userInterface.MessageToUser($"{Properties.Resources.InputSecurity} {room.Name}:");
                room.SecurityOn = (byte)GetParameter();
            }
        }
        public void RoomsChangeSettings(List<Room> rooms)
        {
            if (rooms.Count!=0)
            {
                foreach (Room room in rooms)
                {
                    RoomChangeSettings(room);
                }
            } 
            
        }

        int GetParameter()
        {
            bool result;
            int res;
            do
            {
                result = int.TryParse(userInterface.InfoFomUser(), out int ouparam);
                if (result)
                {
                    res = ouparam;
                    break;
                }
                else
                {
                    userInterface.MessageToUser("Wrong data, try again.");
                }
            }
            while(true);
            return res;
        }
           
    }
}
