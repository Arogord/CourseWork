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
        List<UserSettings> user_settings;
        public ChangeSettings(List<UserSettings> settings)
        {
            if (settings.Count == 0) 
            { 
                for (int i = 0; i < settings.Capacity; i++)
                {
                    settings.Add(new UserSettings());
                }
            }
            this.user_settings = settings;
        }
        
        public void SetCO2Level1(int rooms, int co2level1)
        {
            user_settings[rooms].CO2Level1 = co2level1;
        }

        public void SetCO2Level2(int rooms, int co2level2)
        {
            user_settings[rooms].CO2Level2 = co2level2;
        }

        public void SetGasLvel1(int rooms, int gasLevel1)
        {
            user_settings[rooms].GasLvel1 = gasLevel1;
        }

        public void SetGasLvel2(int rooms, int gasLevel2)
        {
            user_settings[rooms].GasLvel2 = gasLevel2;
        }

        public void SetHumidMax(int rooms, byte humidity)
        {
            user_settings[rooms].HumidMax = humidity;
        }

        public void SetHumidMin(int rooms, byte humidity)
        {
            user_settings[rooms].HumidMin = humidity;
        }

        public void SetSecurityOn(int rooms, byte securityOn)
        {
            user_settings[rooms].SecurityOn = securityOn;
        }

        public void SetTemperature(int rooms, int temperature)
        {
            user_settings[rooms].Temperature = temperature;
        }

    }
}
