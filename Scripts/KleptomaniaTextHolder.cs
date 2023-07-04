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
            string[] names = { "Bread", "Sourdough", "Barley Bread", "Oat Bread", "Rye Bread", "Spelt Bread", "Emmer Bread", "Buckwheat Bread", "Manchet Bread", "Maslin Bread", "Honey Bread", "Hearth Bread",
                "Malt Bread", "Lard Bread", "Flatbread", "Couronne Bread", "Raisin Bread", "Raisin Rye Bread", "Raisin Sourdough", "Barley Sourdough", "Rye Sourdough" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomMilkName()
        {
            string[] names = { "Milk", "Cream", "Buttermilk", "Cow Milk", "Goat Milk", "Sheep Milk", "Yak Milk", "Camel Milk", "Llama Milk", "Alpaca Milk", "Coconut Milk" }; // May try to make some of these region specific at some point, but will see.
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomEggName()
        {
            string[] names = { "Eggs", "Chicken Eggs", "Duck Eggs", "Goose Eggs", "Turkey Eggs", "Quail Eggs", "Pheasant Eggs", "Gull Eggs", "Guinea Fowl Eggs", "Peacock Eggs" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomFatName()
        {
            string[] names = { "Butter", "Lard", "Tallow", "Schmaltz", "Ghee", "Blubber", "Suet", "Vegetable Oil", "Seed Oil" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomCheeseName()
        {
            string[] names = { "Cheese", "Cream Cheese", "Cow Cheese", "Goat Cheese", "Sheep Cheese", "Yak Cheese", "Camel Cheese", "Llama Cheese", "Alpaca Cheese", "Cheddar", "Mozzarella", "Parmesan", "Gouda",
                "Brie", "Camembert", "Blue Cheese", "Feta", "Gorgonzola", "Provolone", "Ricotta", "Cottage Cheese", "Paneer", "Halloumi", "Stilton" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomMeatName()
        {
            string[] names = { "Beef", "Pork", "Chicken", "Turkey", "Lamb", "Veal", "Mutton", "Duck", "Goose", "Rabbit", "Quail", "Venison", "Bison", "Pheasant", "Grouse", "Partridge", "Guinea Fowl",
                "Camel Meat", "Horse Meat", "Bear Meat", "Wolf Meat" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomFishName()
        {
            string[] names = { "Salmon", "Tuna", "Cod", "Trout", "Sardine", "Mackerel", "Halibut", "Snapper", "Bass", "Catfish", "Haddock", "Swordfish", "Mahi Mahi", "Grouper", "Perch", "Pike", "Flounder",
                "Tilapia", "Anchovy", "Trout", "Pollock", "Yellowtail", "Sea Bass", "Herring" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomShellfishName()
        {
            string[] names = { "Shrimp", "Lobster", "Crab", "Crayfish", "Prawn", "Mussels", "Clams", "Oysters", "Scallops", "Squid", "Octopus", "Crab", "Scampi", "Crawfish", "Lobster" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomFruitName()
        {
            string[] names = { "Apples", "Bananas", "Oranges", "Mandarins", "Grapes", "Strawberries", "Blueberries", "Raspberries", "Blackberries", "Mangos", "Pineapple", "Watermelon", "Cantaloupe", "Honeydew",
                "Kiwis", "Peaches", "Plums", "Pears", "Cherries", "Lemons", "Limes", "Grapefruits", "Pomegranate", "Coconuts", "Avocados", "Figs", "Papaya", "Apricots", "Nectarines", "Guavas", "Passion Fruits",
                "Lychees", "Cranberries", "Blackcurrants", "Raisins", "Dates", "Persimmons", "Mulberries", "Dragon Fruit", "Pawpaws", "Quinces", "Star Fruit" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomVegetableName()
        {
            string[] names = { "Carrots", "Tomatos", "Cucumber", "Lettuce", "Broccoli", "Cauliflower", "Spinach", "Cabbage", "Bell Pepper", "Zucchini", "Eggplant", "Onions", "Garlic", "Potatoes", "Sweet Potatoes",
                "Pumpkin", "Butternut Squash", "Acorn Squash", "Brussels Sprouts", "Asparagus", "Green Beans", "Peas", "Corn", "Radish", "Celery", "Mushroom", "Artichoke", "Beets", "Turnips", "Okra", "Leek",
                "Celeriac", "Jicama", "Kohlrabi", "Watercress", "Arugula", "Endive", "Rhubarb" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomNutName()
        {
            string[] names = { "Almonds", "Peanuts", "Cashews", "Walnuts", "Pistachios", "Hazelnuts", "Macadamia Nuts", "Pecans", "Chestnuts", "Pine Nuts", "Hickory Nuts", "Flaxseeds", "Sunflower Seeds" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomSpiceName()
        {
            string[] names = { "Cinnamon", "Cumin", "Turmeric", "Paprika", "Black Pepper", "Cloves", "Nutmeg", "Ginger", "Garlic Powder", "Onion Powder", "Chili Powder", "Cayenne Pepper", "Bay Leaf", "Fennel Seeds",
                "Mustard Seeds", "Dill", "Thyme", "Rosemary", "Basil", "Oregano", "Parsley", "Sage", "Saffron", "Curry Powder" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomBakingSupplyName()
        {
            string[] names = { "" };
            return names[UnityEngine.Random.Range(0, names.Length + 1)]; // Might cause "index out of range" but will see with testing.
        }

        public static List<string> GetGeneralShoppingListItems() // Continue work on filling these out tomorrow or next time.
        {
            return new List<string> { RandomBreadName(), RandomMilkName(), RandomEggName(), RandomFatName(), RandomCheeseName(), RandomMeatName(), RandomFishName(), RandomShellfishName(), RandomFruitName(), RandomVegetableName(), RandomNutName(), RandomSpiceName(), RandomBakingSupplyName(), "Tobacco" }; // Add method to select a potential random list of alcohol, drugs, etc.
        }
    }
}
