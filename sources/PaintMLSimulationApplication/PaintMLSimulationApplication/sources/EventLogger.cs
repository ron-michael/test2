using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    static class EventLogger
    {
        static public String label;
        static public int increment;
        static public int loopNumber;

        public static void Log(String message)
        {
            System.Console.WriteLine("{0} {1} {2}", increment * loopNumber, label, message);
        }
    }
}
