using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.Utility;
using System;
using DaggerfallWorkshop.Game.Entity;
using System.Collections.Generic;
using System.Linq;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop;
using DaggerfallConnect.Arena2;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
        public static string RandomBreadName()
        {
            string[] names = { "Bread", "Sourdough", "Barley Bread", "Oat Bread", "Rye Bread", "Spelt Bread", "Emmer Bread", "Buckwheat Bread", "Manchet Bread", "Maslin Bread", "Honey Bread", "Hearth Bread",
                "Malt Bread", "Lard Bread", "Flatbread", "Couronne Bread", "Raisin Bread", "Raisin Rye Bread", "Raisin Sourdough", "Barley Sourdough", "Rye Sourdough" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomMilkName()
        {
            string[] names = { "Milk", "Cream", "Buttermilk", "Cow Milk", "Goat Milk", "Sheep Milk", "Yak Milk", "Camel Milk", "Llama Milk", "Alpaca Milk", "Coconut Milk" }; // May try to make some of these region specific at some point, but will see.
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomEggName()
        {
            string[] names = { "Eggs", "Chicken Eggs", "Duck Eggs", "Goose Eggs", "Turkey Eggs", "Quail Eggs", "Pheasant Eggs", "Gull Eggs", "Guinea Fowl Eggs", "Peacock Eggs" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomFatName()
        {
            string[] names = { "Butter", "Lard", "Tallow", "Schmaltz", "Ghee", "Blubber", "Suet", "Vegetable Oil", "Seed Oil" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomCheeseName()
        {
            string[] names = { "Cheese", "Cream Cheese", "Cow Cheese", "Goat Cheese", "Sheep Cheese", "Yak Cheese", "Camel Cheese", "Llama Cheese", "Alpaca Cheese", "Cheddar", "Mozzarella", "Parmesan", "Gouda",
                "Brie", "Camembert", "Blue Cheese", "Feta", "Gorgonzola", "Provolone", "Ricotta", "Cottage Cheese", "Paneer", "Halloumi", "Stilton" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomMeatName()
        {
            string[] names = { "Beef", "Pork", "Chicken", "Turkey", "Lamb", "Veal", "Mutton", "Duck", "Goose", "Rabbit", "Quail", "Venison", "Bison", "Pheasant", "Grouse", "Partridge", "Guinea Fowl",
                "Camel Meat", "Horse Meat", "Bear Meat", "Wolf Meat" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomFishName()
        {
            string[] names = { "Salmon", "Tuna", "Cod", "Trout", "Sardine", "Mackerel", "Halibut", "Snapper", "Bass", "Catfish", "Haddock", "Swordfish", "Mahi Mahi", "Grouper", "Perch", "Pike", "Flounder",
                "Tilapia", "Anchovy", "Trout", "Pollock", "Yellowtail", "Sea Bass", "Herring" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomShellfishName()
        {
            string[] names = { "Shrimp", "Lobster", "Crab", "Crayfish", "Prawn", "Mussels", "Clams", "Oysters", "Scallops", "Squid", "Octopus", "Crab", "Scampi", "Crawfish", "Lobster" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomFruitName()
        {
            string[] names = { "Apples", "Bananas", "Oranges", "Mandarins", "Grapes", "Strawberries", "Blueberries", "Raspberries", "Blackberries", "Mangos", "Pineapple", "Watermelon", "Cantaloupe", "Honeydew",
                "Kiwis", "Peaches", "Plums", "Pears", "Cherries", "Lemons", "Limes", "Grapefruits", "Pomegranate", "Coconuts", "Avocados", "Figs", "Papaya", "Apricots", "Nectarines", "Guavas", "Passion Fruits",
                "Lychees", "Cranberries", "Blackcurrants", "Raisins", "Dates", "Persimmons", "Mulberries", "Dragon Fruit", "Pawpaws", "Quinces", "Star Fruit" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomVegetableName()
        {
            string[] names = { "Carrots", "Tomatos", "Cucumber", "Lettuce", "Broccoli", "Cauliflower", "Spinach", "Cabbage", "Bell Pepper", "Zucchini", "Eggplant", "Onions", "Garlic", "Potatoes", "Sweet Potatoes",
                "Pumpkin", "Butternut Squash", "Acorn Squash", "Brussels Sprouts", "Asparagus", "Green Beans", "Peas", "Corn", "Radish", "Celery", "Mushroom", "Artichoke", "Beets", "Turnips", "Okra", "Leek",
                "Celeriac", "Jicama", "Kohlrabi", "Watercress", "Arugula", "Endive", "Rhubarb" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomNutName()
        {
            string[] names = { "Almonds", "Peanuts", "Cashews", "Walnuts", "Pistachios", "Hazelnuts", "Macadamia Nuts", "Pecans", "Chestnuts", "Pine Nuts", "Hickory Nuts", "Flaxseeds", "Sunflower Seeds" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomSpiceName()
        {
            string[] names = { "Salt", "Cinnamon", "Cumin", "Turmeric", "Paprika", "Black Pepper", "Cloves", "Nutmeg", "Ginger", "Garlic Powder", "Onion Powder", "Chili Powder", "Cayenne Pepper", "Bay Leaf",
                "Fennel Seeds", "Mustard Seeds", "Dill", "Thyme", "Rosemary", "Basil", "Oregano", "Parsley", "Sage", "Saffron", "Curry Powder" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomBakingSupplyName()
        {
            string[] names = { "Flour", "Sugar", "Baking Powder", "Baking Soda", "Vanilla Extract", "Yeast", "Cocoa Powder", "Honey", "Cornstarch", "Cream of Tartar", "Powdered Sugar", "Chocolate", "Oats",
                "Corn Syrup", "Maple Syrup" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomDrinkName()
        {
            string[] names = { "Coffee", "Black Tea", "Green Tea", "White Tea", "Herbal Tea", "Chamomile Tea", "Peppermint Tea", "Jasmine Tea", "Hibiscus Tea", "Lavender Tea", "Ginseng Tea", "Mint Tea",
                "Nettle Tea", "Fennel Tea", "Dandelion Tea" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomAlcoholName()
        {
            string[] names = { "Beer", "Mead", "Ale", "Lager", "Stout", "Moonshine", "Cider", "Liqueur", "Tonic", "Champagne", "Spirits", "Port", "Vodka", "Gin", "Rum", "Tequila", "Whiskey", "Bourbon",
                "Scotch", "Brandy", "Red Wine", "White Wine", "Sake", "Mazte", "Greef", "Jagga", "Klef", "Sujamma", "Flin", "Shein", "Theilul" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static string RandomDrugName()
        {
            string[] names = { "Skooma", "Moon Sugar", "Tobacco", "Snuff", "Incense of Mara", "Indulcet", "Sursum", "Quaesto Vil", "Aegrotat" };
            return names[UnityEngine.Random.Range(0, names.Length)]; // Might cause "index out of range" but will see with testing.
        }

        public static TextFile.Token[] TextTokenFromRawStringHeads(string header, List<string> body, string footer)
        {
            // So tomorrow or next time I work on this. I want to try and test this in-game to see if it is actually working as I'm sort of expecting, but will just have to see.

            var listOfCompLines = new List<string>();
            int partLength = 80;
            string[] headerWords = header.Split(' ');
            string[] footerWords = footer.Split(' ');
            var parts = new Dictionary<int, string>();
            string part = string.Empty;
            int partCounter = 0;

            if (header != "")
            {
                foreach (var word in headerWords)
                {
                    if (part.Length + word.Length < partLength)
                    {
                        part += string.IsNullOrEmpty(part) ? word : " " + word;
                    }
                    else
                    {
                        parts.Add(partCounter, part);
                        part = word;
                        partCounter++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 0; i++)
                {
                    parts.Add(partCounter, "");
                    partCounter++;
                }
            }
            parts.Add(partCounter, part);
            partCounter++;
            part = string.Empty;

            if (body.Count > 0)
            {
                foreach (var word in body)
                {
                    parts.Add(partCounter, part);
                    part = word;
                    partCounter++;
                }
            }
            else
            {
                for (int i = 0; i < 0; i++)
                {
                    parts.Add(partCounter, "");
                    partCounter++;
                }
            }
            parts.Add(partCounter, part);
            partCounter++;
            part = string.Empty;

            if (footer != "")
            {
                foreach (var word in footerWords)
                {
                    if (part.Length + word.Length < partLength)
                    {
                        part += string.IsNullOrEmpty(part) ? word : " " + word;
                    }
                    else
                    {
                        parts.Add(partCounter, part);
                        part = word;
                        partCounter++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 0; i++)
                {
                    parts.Add(partCounter, "");
                    partCounter++;
                }
            }

            foreach (var item in parts)
            {
                listOfCompLines.Add(item.Value);
            }

            return DaggerfallUnity.Instance.TextProvider.CreateTokens(TextFile.Formatting.JustifyLeft, listOfCompLines.ToArray());
        }

        public static TextFile.Token[] TextTokenFromRawString(string rawString) // Start work on this tomorrow, that being setting up the actual "letter" part read by the player. In this case for the shopping lists, likely have a "header" in some cases, then the main-body of the list afterward under that, then maybe a "footer" below that similar to the header in some cases. Will see tomorrow how exactly I plan on doing that.
        {
            var listOfCompLines = new List<string>();
            int partLength = 115;
            if (!DaggerfallUnity.Settings.SDFFontRendering)
                partLength = 65;
            string sentence = rawString;
            string[] words = sentence.Split(' ');
            var parts = new Dictionary<int, string>();
            string part = string.Empty;
            int partCounter = 0;
            foreach (var word in words)
            {
                if (part.Length + word.Length < partLength)
                {
                    part += string.IsNullOrEmpty(part) ? word : " " + word;
                }
                else
                {
                    parts.Add(partCounter, part);
                    part = word;
                    partCounter++;
                }
            }
            parts.Add(partCounter, part);

            foreach (var item in parts)
            {
                listOfCompLines.Add(item.Value);
            }

            return DaggerfallUnity.Instance.TextProvider.CreateTokens(TextFile.Formatting.JustifyCenter, listOfCompLines.ToArray());
        }

        public static string GetShopListHeader()
        {
            if (CoinFlip()) { return ""; }
            else
            {
                return "What I Need from the Store";
            }
        }

        public static string GetShopListFooter()
        {
            if (CoinFlip()) { return ""; }
            else
            {
                return "Don't Forget The Stuff Again This Week";
            }
        }

        public static List<string> GetGeneralShoppingListItems()
        {
            int listSize = UnityEngine.Random.Range(3, 14);
            List<int> groupsPicked = new List<int>();
            List<string> listItems = new List<string>();

            for (int i = 0; i < listSize; i++)
            {
                int retries = 0;
                bool nextLoop = false;
                int randGroup = 0;
                string itemName = "";

                do
                {
                    randGroup = UnityEngine.Random.Range(1, 17);
                    retries++;

                    if (retries > 10) { nextLoop = true; break; }
                } while (CountGroupRepeats(groupsPicked, randGroup) > 1);

                if (nextLoop) { continue; }
                retries = 0;

                do
                {
                    itemName = GetRandomWordFromGroup(randGroup);
                    retries++;

                    if (retries > 10) { nextLoop = true; break; }
                } while (CheckWordRepeats(listItems, itemName));

                if (nextLoop) { continue; }
                if (itemName == "") { continue; }

                groupsPicked.Add(randGroup);
                listItems.Add(itemName);
            }
            return listItems;
        }

        public static int CountGroupRepeats(List<int> numbers, int number)
        {
            int count = 0;
            foreach (int num in numbers)
            {
                if (num == number)
                {
                    count++;
                }
            }
            return count;
        }

        public static bool CheckWordRepeats(List<string> words, string word)
        {
            foreach (string wrd in words)
            {
                if (wrd == word)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetRandomWordFromGroup(int groupNum)
        {
            switch (groupNum)
            {
                case 1: return RandomBreadName();
                case 2: return RandomMilkName();
                case 3: return RandomEggName();
                case 4: return RandomFatName();
                case 5: return RandomCheeseName();
                case 6: return RandomMeatName();
                case 7: return RandomFishName();
                case 8: return RandomShellfishName();
                case 9: return RandomFruitName();
                case 10: return RandomVegetableName();
                case 11: return RandomNutName();
                case 12: return RandomSpiceName();
                case 13: return RandomBakingSupplyName();
                case 14: return RandomDrinkName();
                case 15: return RandomAlcoholName();
                case 16: return RandomDrugName();
                default: return "";
            }
        }
    }
}
