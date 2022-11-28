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
        DataSensorsStruct[] data;
        UserSettings[] settings;
        public SecurityController(DataSensorsStruct[] data, UserSettings[] settings)
        {
            this.data = data;
            this.settings = settings;
        }
        public override void CheckParam()
        {
            Console.WriteLine("Check Security");
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i].Motion == 1 && settings[i].SecurityOn ==1)
                {
                    SendMessage($"Detected motion in {(Rooms)i}");
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