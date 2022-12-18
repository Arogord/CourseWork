using CourseWork.Data;
using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    internal class TemperatureControler : Controller, IHeat, Icooling
    {
        List<DataSensors> data;
        List<Room> rooms;
        public event Action<string>? Message;
        public TemperatureControler(List<DataSensors> data, List<Room> rooms)
        {
            this.data = data;
            this.rooms = rooms;
        }

        public override void CheckParam()
        {
            SendMessage("Check Temperature");
            for(int i = 0; i < data.Capacity; i++)
            {
                if (data[i].Temperature < rooms[i].Temperature)
                {
                    Heating(i);
                }
                if (data[i].Temperature > (rooms[i].Temperature + 4))
                {
                    Cooling();
                }
            }
        }

        public void Cooling()
        {
            SendMessage("Cooling is on");
        }

        public void Heating(int i)
        {
            SendMessage($"Heat is on in {rooms[i].Name}");
        }
        public void SendMessage(string mes)
        {
            Message?.Invoke(mes);
        }
    }
}
// включение отопления в каждой комнате в отдельности
// включение/выключение общей системы кондийионирования - блокировка отопления в реальности алгоритм будет сложнее
//
//