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
        public static DaggerfallUnityItem CreateCNCItems(int itemType = -1)
        {
            int rationsTI = 531;
            int appleTI = 532;
            int orangeTI = 533;
            int breadTI = 534;
            int rawFishTI = 535;
            int cookedFishTI = 536;
            int meatTI = 537;
            int rawMeatTI = 538;
            int skilletTI = 540;

            DaggerfallUnityItem item = null;
            bool usesCondition = true;
            float conditionMod = (float)UnityEngine.Random.Range(15, 90 + 1) / 100f;
            if (ClimatesAndCaloriesCheck)
            {
                if (itemType == 0)
                {
                    usesCondition = false;
                    item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, rationsTI);
                    if (item != null) { item.stackCount = UnityEngine.Random.Range(1, 4); }
                }
                else if (itemType == 1) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, appleTI); }
                else if (itemType == 2) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, orangeTI); }
                else if (itemType == 3) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, breadTI); }
                else if (itemType == 4) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, rawFishTI); }
                else if (itemType == 5) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, cookedFishTI); }
                else if (itemType == 6) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, meatTI); }
                else if (itemType == 7) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, rawMeatTI); }
                else if (itemType == 8) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, skilletTI); }

                if (item != null && usesCondition) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            }
            return item;
        }

        public static DaggerfallUnityItem CreateRandomBookItems(bool multiple = false)
        {
            int basicSkillBook = 551;
            int advSkillBook = 552;
            int tomesofArcaneKnowledge = 553;
            int tabletofArcaneKnowledge = 554;

            DaggerfallUnityItem item = null;
            if (SkillBooksCheck)
            {
                if (Dice100.SuccessRoll(80)) // Create a vanilla book most of the time.
                {
                    item = ItemBuilder.CreateRandomBook();
                }
                else
                {
                    int roll = UnityEngine.Random.Range(0, 101);
                    if (roll > 95) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, tabletofArcaneKnowledge); }
                    else if (roll > 85) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, tomesofArcaneKnowledge); }
                    else if (roll > 60) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, advSkillBook); }
                    else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, basicSkillBook); }
                }
            }
            else
            {
                item = ItemBuilder.CreateRandomBook();
            }

            float conditionMod = (float)UnityEngine.Random.Range(20, 75 + 1) / 100f;
            if (multiple == true) { conditionMod /= 4; }
            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }

            return item;
        }

        public static DaggerfallUnityItem CreateRandomGemStoneItems()
        {
            DaggerfallUnityItem item = null;
            if (JewelryAdditionsCheck)
            {
                if (Dice100.SuccessRoll(60)) // Create a vanilla gemstone most of the time.
                {
                    item = ItemBuilder.CreateRandomGem();
                }
                else
                {
                    int gemTI = 4708 + UnityEngine.Random.Range(0, 7);
                    item = ItemBuilder.CreateItem(ItemGroups.Gems, gemTI);
                }
            }
            else
            {
                item = ItemBuilder.CreateRandomGem();
            }
            return item;
        }

        public static DaggerfallUnityItem CreateRealisticWagonItems(int itemType = -1)
        {
            int wagonPartsTI = 542;

            DaggerfallUnityItem item = null;
            float conditionMod = (float)UnityEngine.Random.Range(10, 55 + 1) / 100f;
            if (RealisticWagonCheck)
            {
                if (itemType == 0) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, wagonPartsTI); }

                if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            }
            return item;
        }

        public static DaggerfallUnityItem CreateRepairToolsItems(int itemType = -1)
        {
            int armorersHammerTI = 802;

            DaggerfallUnityItem item = null;
            float conditionMod = (float)UnityEngine.Random.Range(15, 90 + 1) / 100f;
            if (RepairToolsCheck)
            {
                if (itemType == 0) { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, armorersHammerTI); }

                if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            }
            return item;
        }
    }
}
