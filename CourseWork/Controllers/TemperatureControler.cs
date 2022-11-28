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
        DataSensorsStruct[] data;
        UserSettings[] settings;
        public TemperatureControler(DataSensorsStruct[] data, UserSettings[] settings)
        {
            this.data = data;
            this.settings = settings;
        }

        public override void CheckParam()
        {
            Console.WriteLine("Check Temperature");
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i].Temperature < settings[i].Temperature)
                {
                    Heating(i);
                }
                if (data[i].Temperature > (settings[i].Temperature + 4))
                {
                    Cooling();
                }
            }
        }

        public void Cooling()
        {
            Console.WriteLine("Cooling is on");
        }

        public void Heating(int i)
        {
            Console.WriteLine($"Heat is on in {(Rooms)i}");
        }
    }
}
// включение отопления в каждой комнате в отдельности
// включение/выключение общей системы кондийионирования - блокировка отопления в реальности алгоритм будет сложнее
//
//