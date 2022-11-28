using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Data
{
    public class UserSettings
    {
        public int Temperature { get; set; } = 22;
        public int CO2Level1 { get; set; } = 200;
        public int CO2Level2 { get; set; } = 300;
        public int GasLvel1 { get; set; } = 180;
        public int GasLvel2 { get; set; } = 250;
        public byte HumidMin { get; set; } = 40;
        public byte HumidMax { get; set; } = 60;
        public byte SecurityOn { get; set; } = 0;
    }
}
