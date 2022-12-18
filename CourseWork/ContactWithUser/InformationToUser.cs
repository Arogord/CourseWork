using CourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.ContactWithUser
{
    public class ConsoleInformationWithUser : UserInterface
    {
        public void MessageToUser(string message)
        {
            Console.WriteLine(message);
        }
        public string InfoFomUser()
        {
            string? str = Console.ReadLine();
            return str;
        }
    }
}
