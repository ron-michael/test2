using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    static class EventLogger
    {
        static public String Unit;
        static public int Increment;
        static public int LoopNumber;
        static public String RecipeIdentifier;
        static public String StoreIdentifier = "";
        static public String TinterIdentifier = "";
        static public String PumpIdentifier = "";

        public static void Log(String message)
        {
            System.Console.WriteLine("{0} {1} : {2}-{3}-{4} {5} -- {6}", Increment * LoopNumber, Unit, StoreIdentifier, TinterIdentifier, PumpIdentifier, message, RecipeIdentifier);
        }
    }
}
