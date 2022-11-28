using CourseWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Interfaces
{
    public interface IChangeSettings
    {
        public void SetTemperature(Rooms rooms, int temperature);
        public void SetHumidMin(Rooms rooms, byte humidity);
        public void SetHumidMax(Rooms rooms, byte humidity);
        public void SetCO2Level1(Rooms rooms, int co2level1);
        public void SetCO2Level2(Rooms rooms, int co2level2);
        public void SetGasLvel1(Rooms rooms, int gasLvel1);
        public void SetGasLvel2(Rooms rooms, int gasLvel2);
        public void SetSecurityOn(Rooms rooms, byte securityOn);

    }
}
