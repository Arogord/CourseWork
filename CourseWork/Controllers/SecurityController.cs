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
        List<UserSettings> settings;
        public SecurityController(List<DataSensors> data, List<UserSettings> settings)
        {
            this.data = data;
            this.settings = settings;
        }
        public override void CheckParam()
        {
            SendMessage("Check Security");
            for(int i = 0; i < data.Capacity; i++)
            {
                if (data[i].Motion == 1 && settings[i].SecurityOn ==1)
                {
                    SendMessage($"Detected motion in {i} room");
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