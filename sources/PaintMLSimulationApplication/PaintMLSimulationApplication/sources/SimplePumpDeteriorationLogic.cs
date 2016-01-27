using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    class PumpDeterioriationLogic: IPumpDeteriorationLogic
    {
        public bool apply(ColorPump pump, int steps, float volume)
        {
            pump.rul -= steps;
            return (pump.rul > 0);
        }
    }
}
