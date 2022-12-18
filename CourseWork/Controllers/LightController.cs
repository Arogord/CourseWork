﻿using CourseWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    internal class LightController : Controller
    {
        List<DataSensors> data;
        List<Room> rooms;
        public event Action<string>? Message;
        public LightController(List<DataSensors> data, List<Room> rooms)
        {
            this.data = data;
            this.rooms = rooms;
        }
        public override void CheckParam()
        {
            SendMessage("Check Light");
        }
        public void SendMessage(string mes)
        {
            Message?.Invoke(mes);
        }
    }
}
// автоматизация по сценариям пока не предусмотрена
// получение информации из дачиков тока о состоянии освещения - свет может быть включен выключателем и программно
// управление светом через контроллер - через веб либо панель управления
//
//