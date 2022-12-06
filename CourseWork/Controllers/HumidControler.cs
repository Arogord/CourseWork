using CourseWork.Data;
using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    internal class HumidControler : Controller, IHumid,IVentilation
    {
        List<DataSensors> data;
        List<UserSettings> user_settings;
        public event Action<string>? Message;
        public HumidControler(List<DataSensors> data, List<UserSettings> user_settings)
        {
            this.data = data;
            this.user_settings = user_settings;
        }
        public override void CheckParam()
        {
            SendMessage("Check Humid");
            for (int i = 0; i < data.Capacity; i++)
            {
                if (data[i].Humid < user_settings[i].HumidMin)
                {
                    SetHumidTime(i,10);
                }
                if (data[i].Humid > user_settings[i].HumidMax)
                {
                    SetAngleValve(80);
                    SetMotorSpeed(100);
                    SetHumidTime(i, 0);
                }
            }
        }
        public void SetAngleValve(int angleValve)
        {
            SendMessage($"Angle Valve is {angleValve}");
        }

        public void SetHumidTime(int room, int Time)
        {
            SendMessage($"Switching on humidity for {Time} minutes in {room} room");
        }

        public void SetMotorSpeed(int MotorSpeed)
        {
            SendMessage($"Motor Speed is {MotorSpeed}%");
        }
        public void SendMessage(string message)
        {
            Message?.Invoke(message);
        }
    }
}
// при превышении влажности усиление вытяжки в конкретном помещении - увеличение оборотов двигателя вентиляциия на время х или до приведения влажности в норму
// при недостаточной влажности                                      - включение увлажнителя в общем канале
// при использовании целлюлозного или мембранного рекуператора влажность будет распределяться из влажных помещений в сухие - пометка для себя
//
