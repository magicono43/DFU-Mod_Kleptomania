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
        const int CNCRationsTI = 531;
        const int CNCAppleTI = 532;
        const int CNCOrangeTI = 533;
        const int CNCBreadTI = 534;
        const int CNCRawFishTI = 535;
        const int CNCCookedFishTI = 536;
        const int CNCMeatTI = 537;
        const int CNCRawMeatTI = 538;
        const int CNCSkilletTI = 540;

        public static DaggerfallUnityItem CreateCNCRations()
        {
            DaggerfallUnityItem item = null;
            if (ClimatesAndCaloriesCheck)
            {
                item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, CNCRationsTI);
                if (item != null)
                {
                    item.stackCount = UnityEngine.Random.Range(1, 4);
                    return item;
                }
            }
            return item;
        }

        public static DaggerfallUnityItem CreateCNCBread() // Will probably condense these into a single method tomorrow. Continue working on these modded items next time.
        {
            DaggerfallUnityItem item = null;
            float conditionMod = (float)UnityEngine.Random.Range(15, 90 + 1) / 100f;
            if (ClimatesAndCaloriesCheck)
            {
                item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, CNCBreadTI);
                if (item != null)
                {
                    item.currentCondition = (int)(item.maxCondition * conditionMod);
                    return item;
                }
            }
            return item;
        }

        public static void CreateRealisticWagonWheel() // Don't have the templateIndex for the wagon wheel item atm, so forget this one until I get that value.
        {
            // WIP
        }
    }
}
