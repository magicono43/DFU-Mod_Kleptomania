using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.Utility;
using System;
using DaggerfallWorkshop.Game.Entity;
using System.Collections.Generic;
using System.Linq;
using DaggerfallWorkshop.Game;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
        public static string RandomBreadName()
        {
            string[] names = { "Bread", "Sourdough", "Barley Bread", "Oat Bread", "Rye Bread", "Spelt Bread", "Emmer Bread", "Buckwheat Bread", "Manchet Bread", "Maslin Bread", "Honey Bread", "Hearth Bread", "Malt Bread", "Lard Bread", "Flatbread", "Couronne Bread", "Raisin Bread", "Raisin Rye Bread", "Raisin Sourdough", "Barley Sourdough", "Rye Sourdough" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static List<string> GetGeneralShoppingListItems() // Continue work on filling these out tomorrow or next time.
        {
            return new List<string> { RandomBreadName(), "Eggs", "Milk", "Tobacco", "Butter" }; // Add method to select a potential random list of alcohol, meats, drugs, cheese, etc.
        }
    }
}
