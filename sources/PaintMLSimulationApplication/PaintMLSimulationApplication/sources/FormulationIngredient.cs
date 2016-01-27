using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication.sources
{
    class FormulationIngredient
    {
        public String Color;
        public float Volume;
        public int Steps;

        public FormulationIngredient(String color, int steps, float volume)
        {
            this.Color = color;
            this.Volume = volume;
            this.Steps = steps;
        }
    }
}
