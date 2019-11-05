using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMathMathConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Add Method");
            Console.WriteLine("Under 256");
            Console.WriteLine("101 + 99 = {0}", MyMath1.Add((byte)101, (byte)99)); //under 256
            Console.WriteLine("Over 256");
            Console.WriteLine("200 + 200 = {0}", MyMath1.Add((byte)200, (byte)200)); //over 256
            Console.WriteLine();

            Console.WriteLine("Testing Add Method with checked");
            Console.WriteLine("Under 256");
            Console.WriteLine("101 + 99 = {0}", MyMath2.Add((byte)101, (byte)99)); //under 256
            Console.WriteLine("Over 256 causes error");
            Console.WriteLine("200 + 200 = {0}", MyMath2.Add((byte)200, (byte)200)); //over 256
        }
    }
}
