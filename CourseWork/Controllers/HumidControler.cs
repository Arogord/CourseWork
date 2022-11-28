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
        DataSensorsStruct[] data;
        UserSettings[] settings;
        public HumidControler(DataSensorsStruct[] data, UserSettings[] settings)
        {
            this.data = data;
            this.settings = settings;
        }
        public override void CheckParam()
        {
            Console.WriteLine("Check Humid");
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Humid < settings[i].HumidMin)
                {
                    SetHumidTime(i,10);
                }
                if (data[i].Humid > settings[i].HumidMax)
                {
                    SetAngleValve(80);
                    SetMotorSpeed(100);
                    SetHumidTime(i, 0);
                }
            }
        }
        public void SetAngleValve(int angleValve)
        {
            Console.WriteLine($"Angle Valve is {angleValve}");
        }

        public void SetHumidTime(int room, int Time)
        {
            Console.WriteLine($"Switching on humidity for {Time} minutes in {(Rooms)room}");
        }

        public void SetMotorSpeed(int MotorSpeed)
        {
            Console.WriteLine($"Motor Speed is {MotorSpeed}%");
        }
    }
}
// при превышении влажности усиление вытяжки в конкретном помещении - увеличение оборотов двигателя вентиляциия на время х или до приведения влажности в норму
// при недостаточной влажности                                      - включение увлажнителя в общем канале
// при использовании целлюлозного или мембранного рекуператора влажность будет распределяться из влажных помещений в сухие - пометка для себя
//
