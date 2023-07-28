using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.Utility;

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

        public static DaggerfallUnityItem ChooseRandomWeapon(int weaponGroup, int templateIndex = -1, bool multiple = false)
        {
            int RPRIArchAxeTI = 513;
            int RPRILigFlailTI = 514;

            int randomValue = 0;
            DaggerfallUnityItem item = null;
            float conditionMod = (float)UnityEngine.Random.Range(5, 35 + 1) / 100f;

            if (templateIndex == -1)
            {
                if (weaponGroup == 0)
                {
                    randomValue = UnityEngine.Random.Range(0, 4);
                    if (randomValue == 0) { templateIndex = (int)Weapons.Broadsword; }
                    else if (randomValue == 1) { templateIndex = (int)Weapons.Saber; }
                    else if (randomValue == 2) { templateIndex = (int)Weapons.Longsword; }
                    else { templateIndex = (int)Weapons.Katana; }
                }
                else if (weaponGroup == 1)
                {
                    randomValue = UnityEngine.Random.Range(0, 4);
                    if (randomValue == 0) { templateIndex = (int)Weapons.Dagger; }
                    else if (randomValue == 1) { templateIndex = (int)Weapons.Tanto; }
                    else if (randomValue == 2) { templateIndex = (int)Weapons.Shortsword; }
                    else { templateIndex = (int)Weapons.Wakazashi; }
                }
                else if (weaponGroup == 2)
                {
                    if (RolePlayRealismNewWeaponCheck && CoinFlip())
                    {
                        item = ItemBuilder.CreateItem(ItemGroups.Weapons, RPRIArchAxeTI);
                        ItemBuilder.ApplyWeaponMaterial(item, (WeaponMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial());
                        if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
                        return item;
                    }
                    else { templateIndex = (int)Weapons.Battle_Axe; }
                }
                else if (weaponGroup == 3)
                {
                    if (RolePlayRealismNewWeaponCheck && CoinFlip())
                    {
                        item = ItemBuilder.CreateItem(ItemGroups.Weapons, RPRILigFlailTI);
                        ItemBuilder.ApplyWeaponMaterial(item, (WeaponMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial());
                        if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
                        return item;
                    }
                    else { templateIndex = (int)Weapons.Mace; }
                }
                else if (weaponGroup == 4)
                {
                    templateIndex = (int)Weapons.Staff;
                }
                else if (weaponGroup == 5)
                {
                    randomValue = UnityEngine.Random.Range(0, 2);
                    if (randomValue == 0) { templateIndex = (int)Weapons.Short_Bow; }
                    else { templateIndex = (int)Weapons.Long_Bow; }
                }
                else if (weaponGroup == 6)
                {
                    randomValue = UnityEngine.Random.Range(0, 2);
                    if (randomValue == 0) { templateIndex = (int)Weapons.Claymore; }
                    else { templateIndex = (int)Weapons.Dai_Katana; }
                }
                else { return null; }
            }

            if (multiple)
            {
                conditionMod = (float)UnityEngine.Random.Range(5, 20 + 1) / 100f;
                item = ItemBuilder.CreateWeapon((Weapons)templateIndex, (WeaponMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(true, false, true));
                if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            }

            item = ItemBuilder.CreateWeapon((Weapons)templateIndex, (WeaponMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial());
            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            return item;
        }

        public static DaggerfallUnityItem ChooseRandomArmor(int armorGroup, int templateIndex = -1)
        {
            int randomValue = 0;
            DaggerfallUnityItem item = null;
            Genders gender = GameManager.Instance.PlayerEntity.Gender;
            Races race = GameManager.Instance.PlayerEntity.Race;
            float conditionMod = (float)UnityEngine.Random.Range(10, 40 + 1) / 100f;

            if (templateIndex == -1)
            {
                if (armorGroup == 0)
                {
                    templateIndex = (int)Armor.Tower_Shield;
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false, true));
                }
                else if (armorGroup == 1)
                {
                    randomValue = UnityEngine.Random.Range(0, 3);
                    if (randomValue == 0) { templateIndex = (int)Armor.Buckler; }
                    else if (randomValue == 1) { templateIndex = (int)Armor.Round_Shield; }
                    else { templateIndex = (int)Armor.Kite_Shield; }
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false, true));
                }
                else if (armorGroup == 2)
                {
                    templateIndex = (int)Armor.Cuirass;
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false));
                }
                else if (armorGroup == 3)
                {
                    templateIndex = (int)Armor.Helm;
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false));
                }
                else { return null; }
            }

            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
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

        public static DaggerfallUnityItem CreateRandomCrownItems() // For now, Jewelry Additions can't have other mods specify what "type" of crown they want, so just random for now atleast, will fix eventually.
        {
            int jewelryAddCrownTI = 4705;

            DaggerfallUnityItem item = null;
            if (JewelryAdditionsCheck)
            {
                item = ItemBuilder.CreateItem(ItemGroups.Jewellery, jewelryAddCrownTI);
            }

            float conditionMod = (float)UnityEngine.Random.Range(15, 65 + 1) / 100f;
            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }

            return item;
        }

        public static DaggerfallUnityItem CreateRandomTiaraItems() // For now, Jewelry Additions can't have other mods specify what "type" of tiara they want, so just random for now atleast, will fix eventually.
        {
            int jewelryAddTiaraTI = 4704;

            DaggerfallUnityItem item = null;
            if (JewelryAdditionsCheck)
            {
                item = ItemBuilder.CreateItem(ItemGroups.Jewellery, jewelryAddTiaraTI);
            }

            float conditionMod = (float)UnityEngine.Random.Range(15, 65 + 1) / 100f;
            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }

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

        public static DaggerfallUnityItem CreateRandomPotionItems()
        {
            DaggerfallUnityItem item = null;
            if (Dice100.SuccessRoll(70))
            {
                if (Dice100.SuccessRoll(60)) { item = ItemBuilder.CreatePotion(221871); } // Potion of Stamina recipe key
                else { item = ItemBuilder.CreatePotion(4975678); } // Potion of Healing recipe key
            }
            else
            {
                item = ItemBuilder.CreateRandomPotion();
            }
            return item;
        }
    }
}
