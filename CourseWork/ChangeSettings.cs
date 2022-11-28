using CourseWork.Data;
using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class ChangeSettings : IChangeSettings
    {
        UserSettings[] user_settings;
        public ChangeSettings(UserSettings[] user_settings)
        {
            this.user_settings = user_settings;
        }

        public void SetCO2Level1(Rooms rooms, int co2level1)
        {
            user_settings[(int)rooms].CO2Level1 = co2level1;
        }

        public void SetCO2Level2(Rooms rooms, int co2level2)
        {
            user_settings[(int)rooms].CO2Level2 = co2level2;
        }

        public void SetGasLvel1(Rooms rooms, int gasLevel1)
        {
            user_settings[(int)rooms].GasLvel1 = gasLevel1;
        }

        public void SetGasLvel2(Rooms rooms, int gasLevel2)
        {
            user_settings[(int)rooms].GasLvel2 = gasLevel2;
        }

        public void SetHumidMax(Rooms rooms, byte humidity)
        {
            user_settings[(int)rooms].HumidMax = humidity;
        }

        public void SetHumidMin(Rooms rooms, byte humidity)
        {
            user_settings[(int)rooms].HumidMin = humidity;
        }

        public void SetSecurityOn(Rooms rooms, byte securityOn)
        {
            user_settings[(int)rooms].SecurityOn = securityOn;
        }

        public void SetTemperature(Rooms rooms, int temperature)
        {
            user_settings[(int)rooms].Temperature = temperature;
        }
    }
}
