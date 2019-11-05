using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMathMathConsoleApp
{
    class MyMath2
    {
        public static byte Add(byte x, byte y)
        {
            checked
            {
                byte sum = (byte)(x + y);
                return sum;

            }


      


        }
    }
}
