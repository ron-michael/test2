using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    class Tinter
    {
        public Dictionary<String, ColorPump> pumps = new Dictionary<string, ColorPump>();

        public Tinter(uint totalPumps)
        {
            ResetPumps(totalPumps);
        }

        public void ResetPumps(uint total)
        {
            this.pumps.Clear();

            for (int i = 0; i < total; i++)
            {
                String key = i.ToString();
                pumps.Add(key, new ColorPump(key, 100));
            }
        }

        public bool DoWork(FormulationRecipe recipe)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                ColorPump pump;
                bool found = this.pumps.TryGetValue(ingredient.Color, out pump);
                if (found)
                {
                    EventLogger.PumpIdentifier = pump.identifier;
                    pump.DoWork(ingredient.Steps, ingredient.Volume);
                }
            }

            return true;
        }
    }
}
