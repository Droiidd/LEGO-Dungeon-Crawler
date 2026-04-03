using ConsoleApp1.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    class ClassTypeHelper
    {
        public static int GetStartingCpFromClass(ClassType classType)
        {
            if (classType.Equals(ClassType.Rogue))
            {
                return 16;
            }
            else
            {
                return 20;
            }
        }
    }
}
