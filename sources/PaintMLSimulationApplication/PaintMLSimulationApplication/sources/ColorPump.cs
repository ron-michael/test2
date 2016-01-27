using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    class ColorPump
    {
        public int rul;
        public int rulOriginal;
        public String identifier;
        public IPumpDeteriorationLogic deteriorationLogic;

        public ColorPump(String identifier, int rul)
        {
            this.identifier = identifier;
            this.rul = rul;
            this.rulOriginal = rul;
        }


        /// <summary>
        /// Performs work for the specified number of steps and volume
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="volume"></param>
        /// <returns>True, when is achieved; Otherwise false if the pump has completely deteriorated.</returns>
        public Boolean DoWork(int steps, float volume)
        {
            bool status = deteriorationLogic.apply(this, steps, volume);
            if (status == false)
            {
                this.rul = this.rulOriginal;

                //EventLogger.Log("pump " + this.identifier + " has been replaced");
                EventLogger.Log("pump  has been replaced");
            }
            return status;
        }
    }
}
