using CourseWork.Data;
using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    internal class SecurityController : Controller, IMessageToUser
    {
        public event Action<string>? Message;
        List<DataSensors> data;
        List<Room> rooms;
        public SecurityController(List<DataSensors> data, List<Room> rooms)
        {
            this.data = data;
            this.rooms = rooms;
        }
        public override void CheckParam()
        {
            SendMessage("Check Security");
            for(int i = 0; i < data.Capacity; i++)
            {
                if (data[i].Motion == 1 && rooms[i].SecurityOn!=0)
                {
                    SendMessage($"Detected motion in {rooms[i].Name}");
                }
            }
        }

        public void SendMessage(string message)
        {
            Message?.Invoke(message);
        }
    }

}
// в режиме охраны оповещение хозяина
// 
//
//
//