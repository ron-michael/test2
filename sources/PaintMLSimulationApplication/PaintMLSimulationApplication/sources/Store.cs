using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    class Store
    {
        public List<Tinter> Tinters = new List<Tinter>();

        public Store(uint totalTinters)
        {
            ResetTinters(totalTinters);
        }

        public void ResetTinters(uint total)
        {
            this.Tinters.Clear();

            for (int i = 0; i < total; i++)
            {
                Tinters.Add(new Tinter(16));
            }
        }

        public void DoWork(FormulationRecipe recipe)
        {
            Random random = new Random();
            int index = random.Next(0, this.Tinters.Count);

            EventLogger.TinterIdentifier = index.ToString();
            this.Tinters.ElementAt(index).DoWork(recipe);
        }
    }
}
