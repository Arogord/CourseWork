using CourseWork.Data;
using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    public class GasController : Controller, IMessageToUser, IVentilation
    {
        List<DataSensors> data;
        List<UserSettings> user_settings;
        public event Action<string>? Message;
        public GasController(List<DataSensors> data, List<UserSettings> user_settings)
        {
            this.data = data;
            this.user_settings = user_settings;
        }

        public override void CheckParam()
        {
            SendMessage("Check Gas");
            for(int i = 0; i < data.Capacity; i++)
            {
                if (data[i].CO2 > user_settings[i].CO2Level1)
                {
                    SendMessage($"CO2 levels are more then normal in {i} room");
                    SetMotorSpeed(100);
                }
                if (data[i].Gas > user_settings[i].GasLvel1)
                {
                    SendMessage($"Gas levels are more then normal in {i} room");
                    SetMotorSpeed(100);
                }

                if (data[i].CO2> user_settings[i].CO2Level2)
                {
                    SendMessage($"CO2 levels are critical in {i} room");
                    SetAngleValve(0);
                }
                if (data[i].Gas > user_settings[i].GasLvel2)
                {
                    SendMessage($"Gas levels are critical in {i} room");
                    SetAngleValve(0);
                }
                
            }
        }
       
        public void SendMessage(string mes)
        {
            Message?.Invoke(mes);
        }

        public void SetAngleValve(int angleValve)
        {
            SendMessage($"Angle Valve is {angleValve}");
        }

        public void SetMotorSpeed(int MotorSpeed)
        {
            SendMessage($"Motor Speed is {MotorSpeed}%");
        }
    }
}
//при 1 пороге усиление вентиляции в помещении
//при 2 пороге оповещение хозяина, прекращение вентиляции в помещении - закрытие задвижек
