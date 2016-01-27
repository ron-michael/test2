using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    interface IPumpDeteriorationLogic
    {

        /// <summary>
        /// Applies the operation on the specified pump doing specified
        /// number of steps and output'ng specificied volumne.
        /// </summary>
        /// <param name="pump"></param>
        /// <param name="steps"></param>
        /// <param name="volume"></param>
        /// <returns>True, when is achieved; Otherwise false if the pump has completely deteriorated</returns>
        bool apply(ColorPump pump, int steps, float volume);
    }
}
