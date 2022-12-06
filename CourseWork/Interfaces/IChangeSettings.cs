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
        public void SetTemperature(int rooms, int temperature);
        public void SetHumidMin(int rooms, byte humidity);
        public void SetHumidMax(int rooms, byte humidity);
        public void SetCO2Level1(int rooms, int co2level1);
        public void SetCO2Level2(int rooms, int co2level2);
        public void SetGasLvel1(int rooms, int gasLvel1);
        public void SetGasLvel2(int rooms, int gasLvel2);
        public void SetSecurityOn(int rooms, byte securityOn);

    }
}
