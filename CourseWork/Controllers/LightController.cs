using CourseWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    internal class LightController : Controller
    {
        DataSensorsStruct[] data;
        public LightController(DataSensorsStruct[] data)
        {
            this.data = data;
        }
        public override void CheckParam()
        {
            Console.WriteLine("Check Light");
        }
    }
}
// автоматизация по сценариям пока не предусмотрена
// получение информации из дачиков тока о состоянии освещения - свет может быть включен выключателем и программно
// управление светом через контроллер - через веб либо панель управления
//
//