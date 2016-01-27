using PaintMLSimulationApplication.sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintMLSimulationApplication
{
    class Program
    {
        public List<Store> Setup()
        {
            List<Store> stores = new List<Store>();

            stores.Add(new Store(1));
            stores.Add(new Store(1));
            stores.Add(new Store(1));

            stores.Add(new Store(2));
            stores.Add(new Store(2));
            stores.Add(new Store(2));

            stores.Add(new Store(3));
            stores.Add(new Store(3));
            stores.Add(new Store(3));
            stores.Add(new Store(3));


            //-- Set Logic to all pumps --//

            IPumpDeteriorationLogic logic = new PumpDeterioriationLogic();

            foreach (var store in stores)
            {
                foreach (var tinter in store.Tinters)
                {
                    foreach (KeyValuePair<string, ColorPump> entry in tinter.pumps)
                    {
                        entry.Value.deteriorationLogic = logic;
                    }

                }
            }

            return stores;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="increment"></param>
        /// <param name="loops"></param>
        /// <param name="nonDispenseChance">Likelihood store wont dispense. The closer to 0 
        /// the better; Passing 0 means store will always dispense</param>
        public void Start(String unit, int increment, int loops, int nonDispenseChance,
            Dictionary<String, FormulationRecipe> recipes)
        {
            List<Store> stores = Setup();
            Random random = new Random();
            List<FormulationRecipe> recipeList = Enumerable.ToList(recipes.Values);

            EventLogger.label = unit;
            EventLogger.increment = increment;

            for (int i = 0; i < loops; i++)
            {
                EventLogger.loopNumber = i;

                int chance = random.Next(1, nonDispenseChance + 2);

                if (chance == 1)
                {
                    foreach (var store in stores)
                    {
                        int index = random.Next(recipeList.Count);
                        FormulationRecipe recipe = recipeList.ElementAt(index);
                        store.DoWork(recipe);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                System.Console.WriteLine("prams: <increment unit> <increment value> <number of loops> <chance of non-dispense>");
                return;
            }

            int increment;
            int loops;
            int chance;
            string unit = args[0];

            bool test;

            test = int.TryParse(args[1], out increment);
            if (test == false)
            {
                System.Console.WriteLine("increment value should be a number");
                return;
            }

            test = int.TryParse(args[2], out loops);
            if (test == false)
            {
                System.Console.WriteLine("loops should be a number");
                return;
            }

            test = int.TryParse(args[3], out chance);
            if (test == false)
            {
                System.Console.WriteLine("chance should be a number");
                return;
            }

            Dictionary<String, FormulationRecipe> recipes = new Dictionary<String, FormulationRecipe>();
            FormulationRecipe recipe;

            recipe = new FormulationRecipe();
            recipe.Ingredients.Add(new FormulationIngredient("1", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("2", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("3", 1, 10.0f));
            recipes.Add("BARELY PINK", recipe);

            recipe.Ingredients.Add(new FormulationIngredient("1", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("5", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("17", 1, 10.0f));
            recipes.Add("LION MANE", recipe);

            recipe.Ingredients.Add(new FormulationIngredient("10", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("8", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("9", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("6", 1, 10.0f));
            recipes.Add("BOMBAY GOLD (OKCC)", recipe);

            recipe.Ingredients.Add(new FormulationIngredient("11", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("4", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("6", 1, 10.0f));
            recipe.Ingredients.Add(new FormulationIngredient("2", 1, 10.0f));
            recipes.Add("EASTERN PROMISE (OKCC)", recipe);

            Program p = new Program();
            p.Start(unit, increment, loops, chance, recipes);
        }
    }
}
