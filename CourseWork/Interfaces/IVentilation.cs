using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Interfaces
{
    internal interface IVentilation
    {
        public void SetAngleValve(int angleValve);
        
        public void SetMotorSpeed(int MotorSpeed);
    }
}
