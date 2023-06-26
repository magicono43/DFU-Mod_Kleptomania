using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.Serialization;
using System;

namespace Kleptomania
{
    public class ItemGoldBar : DaggerfallUnityItem
    {
        public const int templateIndex = 4733;

        public ItemGoldBar() : base(ItemGroups.Jewellery, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemGoldBar).ToString();
            return data;
        }
    }

    public class ItemGobletCup : DaggerfallUnityItem
    {
        public const int templateIndex = 4734;

        public ItemGobletCup() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override int InventoryTextureRecord
        {
            get { return CurrentVariant; }
        }

        public override string ItemName
        {
            get { return shortName; }
        }

        public override string LongName
        {
            get { return shortName; }
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemGobletCup).ToString();
            return data;
        }
    }

    public class ItemCandelabra : DaggerfallUnityItem
    {
        public const int templateIndex = 4735;

        public ItemCandelabra() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemCandelabra).ToString();
            return data;
        }
    }

    public class ItemGlobe : DaggerfallUnityItem
    {
        public const int templateIndex = 4736;

        public ItemGlobe() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemGlobe).ToString();
            return data;
        }
    }

    public class ItemTelescope : DaggerfallUnityItem
    {
        public const int templateIndex = 4737;

        public ItemTelescope() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemTelescope).ToString();
            return data;
        }
    }

    public class ItemWeightScale : DaggerfallUnityItem
    {
        public const int templateIndex = 4738;

        public ItemWeightScale() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemWeightScale).ToString();
            return data;
        }
    }

    public class ItemHourglass : DaggerfallUnityItem
    {
        public const int templateIndex = 4739;

        public ItemHourglass() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemHourglass).ToString();
            return data;
        }
    }

    public class ItemMagnifyingGlass : DaggerfallUnityItem
    {
        public const int templateIndex = 4740;

        public ItemMagnifyingGlass() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemMagnifyingGlass).ToString();
            return data;
        }
    }

    public class ItemHandMirror : DaggerfallUnityItem
    {
        public const int templateIndex = 4741;

        public ItemHandMirror() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemHandMirror).ToString();
            return data;
        }
    }

    public class ItemInkwell : DaggerfallUnityItem
    {
        public const int templateIndex = 4742;

        public ItemInkwell() : base(ItemGroups.ReligiousItems, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemInkwell).ToString();
            return data;
        }
    }

    public class ItemSmokingPipe : DaggerfallUnityItem
    {
        public const int templateIndex = 4743;

        public ItemSmokingPipe() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemSmokingPipe).ToString();
            return data;
        }
    }

    public class ItemClayPot : DaggerfallUnityItem
    {
        public const int templateIndex = 4744;

        public ItemClayPot() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override int InventoryTextureRecord
        {
            get { return CurrentVariant; }
        }

        public override string ItemName
        {
            get { return shortName; }
        }

        public override string LongName
        {
            get { return shortName; }
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemClayPot).ToString();
            return data;
        }
    }

    public class ItemUrn : DaggerfallUnityItem
    {
        public const int templateIndex = 4745;

        public ItemUrn() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemUrn).ToString();
            return data;
        }
    }

    public class ItemVase : DaggerfallUnityItem
    {
        public const int templateIndex = 4746;

        public ItemVase() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemVase).ToString();
            return data;
        }
    }

    public class ItemSpoon : DaggerfallUnityItem
    {
        public const int templateIndex = 4747;

        public ItemSpoon() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemSpoon).ToString();
            return data;
        }
    }

    public class ItemScoop : DaggerfallUnityItem
    {
        public const int templateIndex = 4748;

        public ItemScoop() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemScoop).ToString();
            return data;
        }
    }

    public class ItemShovel : DaggerfallUnityItem
    {
        public const int templateIndex = 4749;

        public ItemShovel() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemShovel).ToString();
            return data;
        }
    }

    public class ItemButterChurn : DaggerfallUnityItem
    {
        public const int templateIndex = 4750;

        public ItemButterChurn() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemButterChurn).ToString();
            return data;
        }
    }

    public class ItemPickaxe : DaggerfallUnityItem
    {
        public const int templateIndex = 4751;

        public ItemPickaxe() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemPickaxe).ToString();
            return data;
        }
    }

    public class ItemScythe : DaggerfallUnityItem
    {
        public const int templateIndex = 4752;

        public ItemScythe() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemScythe).ToString();
            return data;
        }
    }

    public class ItemRope : DaggerfallUnityItem
    {
        public const int templateIndex = 4753;

        public ItemRope() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemRope).ToString();
            return data;
        }
    }

    public class ItemBellows : DaggerfallUnityItem
    {
        public const int templateIndex = 4754;

        public ItemBellows() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemBellows).ToString();
            return data;
        }
    }

    public class ItemBroom : DaggerfallUnityItem
    {
        public const int templateIndex = 4755;

        public ItemBroom() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemBroom).ToString();
            return data;
        }
    }

    public class ItemBrush : DaggerfallUnityItem
    {
        public const int templateIndex = 4756;

        public ItemBrush() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemBrush).ToString();
            return data;
        }
    }

    public class ItemTongs : DaggerfallUnityItem
    {
        public const int templateIndex = 4757;

        public ItemTongs() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemTongs).ToString();
            return data;
        }
    }

    public class ItemShears : DaggerfallUnityItem
    {
        public const int templateIndex = 4758;

        public ItemShears() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemShears).ToString();
            return data;
        }
    }

    public class ItemTrowel : DaggerfallUnityItem
    {
        public const int templateIndex = 4759;

        public ItemTrowel() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(ItemTrowel).ToString();
            return data;
        }
    }

    public static class KMItemBuilder
    {
        public static DaggerfallUnityItem CreateGobletCupVariant(int cupMat = 0)
        {
            DaggerfallUnityItem item = ItemBuilder.CreateItem(ItemGroups.ReligiousItems, ItemGobletCup.templateIndex);
            switch (cupMat)
            {
                default:
                case 0:
                    item.shortName = "Wooden Cup";
                    item.weightInKg = 0.15f;
                    item.value = 1;
                    item.CurrentVariant = 6; break;
                case 1:
                    item.shortName = "Silver Goblet";
                    item.weightInKg = 0.2f;
                    item.value = 10;
                    item.CurrentVariant = 0; break;
                case 2:
                    item.shortName = "Gold Goblet";
                    item.weightInKg = 0.25f;
                    item.value = 20;
                    item.CurrentVariant = 1; break;
                case 3:
                    item.shortName = "Studded Silver Goblet";
                    item.weightInKg = 0.2f;
                    item.value = 25;
                    item.CurrentVariant = 4; break;
                case 4:
                    item.shortName = "Studded Gold Goblet";
                    item.weightInKg = 0.25f;
                    item.value = 55;
                    item.CurrentVariant = 5; break;
            }
            item.message = cupMat;

            return item;
        }

        public static DaggerfallUnityItem CreateClayPotVariant(int potMat = 0)
        {
            DaggerfallUnityItem item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemClayPot.templateIndex);
            switch (potMat)
            {
                default:
                case 0:
                    item.shortName = "Brown Pot";
                    item.weightInKg = 1.5f;
                    item.value = 5;
                    item.CurrentVariant = 2; break;
                case 1:
                    item.shortName = "Gray Pot";
                    item.weightInKg = 1.5f;
                    item.value = 5;
                    item.CurrentVariant = 1; break;
                case 2:
                    item.shortName = "Green Pot";
                    item.weightInKg = 1.5f;
                    item.value = 5;
                    item.CurrentVariant = 3; break;
                case 3:
                    item.shortName = "Engraved Brown Pot";
                    item.weightInKg = 1.5f;
                    item.value = 10;
                    item.CurrentVariant = 0; break;
            }
            item.message = potMat;

            return item;
        }

        public static DaggerfallUnityItem ChooseRandomWeapon(int weaponGroup, int templateIndex = -1, bool multiple = false)
        {
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
                    templateIndex = (int)Weapons.Battle_Axe;
                }
                else if (weaponGroup == 3)
                {
                    templateIndex = (int)Weapons.Mace;
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
                item = ItemBuilder.CreateWeapon((Weapons)templateIndex, (WeaponMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(true, false, true)); // Will need to test to see if casting "templateIndex" to Weapons will work.
                if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            }

            item = ItemBuilder.CreateWeapon((Weapons)templateIndex, (WeaponMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial()); // Will need to test to see if casting "templateIndex" to Weapons will work.
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
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false, true)); // Will need to test to see if casting "templateIndex" to Armor will work.
                }
                else if (armorGroup == 1)
                {
                    randomValue = UnityEngine.Random.Range(0, 3);
                    if (randomValue == 0) { templateIndex = (int)Armor.Buckler; }
                    else if (randomValue == 1) { templateIndex = (int)Armor.Round_Shield; }
                    else { templateIndex = (int)Armor.Kite_Shield; }
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false, true)); // Will need to test to see if casting "templateIndex" to Armor will work.
                }
                else if (armorGroup == 2)
                {
                    templateIndex = (int)Armor.Cuirass;
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false)); // Will need to test to see if casting "templateIndex" to Armor will work.
                }
                else if (armorGroup == 3)
                {
                    templateIndex = (int)Armor.Helm;
                    item = ItemBuilder.CreateArmor(gender, race, (Armor)templateIndex, (ArmorMaterialTypes)KleptomaniaMain.RollWeaponOrArmorMaterial(false)); // Will need to test to see if casting "templateIndex" to Armor will work.
                }
                else { return null; }
            }

            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            return item;
        }

        public static DaggerfallUnityItem ChooseRandomClothingPiece()
        {
            Array enumArray;
            int enumIndex = -1;
            DaggerfallUnityItem item = null;
            Genders gender = GameManager.Instance.PlayerEntity.Gender;
            Races race = GameManager.Instance.PlayerEntity.Race;
            float conditionMod = (float)UnityEngine.Random.Range(15, 65 + 1) / 100f;

            if (gender == Genders.Female)
            {
                enumArray = Enum.GetValues(typeof(WomensClothing));
                enumIndex = UnityEngine.Random.Range(0, enumArray.Length);
                item = ItemBuilder.CreateWomensClothing((DaggerfallWorkshop.Game.Items.WomensClothing)enumArray.GetValue(enumIndex), race, -1, ItemBuilder.RandomClothingDye());
            }
            else
            {
                enumArray = Enum.GetValues(typeof(MensClothing));
                enumIndex = UnityEngine.Random.Range(0, enumArray.Length);
                item = ItemBuilder.CreateMensClothing((DaggerfallWorkshop.Game.Items.MensClothing)enumArray.GetValue(enumIndex), race, -1, ItemBuilder.RandomClothingDye());
            }
            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            return item;
        }

        public static DaggerfallUnityItem ChooseRandomFootwear()
        {
            DaggerfallUnityItem item = null;
            Genders gender = GameManager.Instance.PlayerEntity.Gender;
            Races race = GameManager.Instance.PlayerEntity.Race;
            float conditionMod = (float)UnityEngine.Random.Range(15, 65 + 1) / 100f;
            int piece = UnityEngine.Random.Range(0, 4);

            if (gender == Genders.Female)
            {
                if (piece == 0) { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Shoes); }
                else if (piece == 1) { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Sandals); }
                else if (piece == 2) { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Boots); }
                else { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Tall_boots); }
            }
            else
            {
                if (piece == 0) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Shoes); }
                else if (piece == 1) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Sandals); }
                else if (piece == 2) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Boots); }
                else { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Tall_Boots); }
            }

            if (item != null)
            {
                int variant = UnityEngine.Random.Range(0, item.ItemTemplate.variants);
                ItemBuilder.SetRace(item, race);
                ItemBuilder.SetVariant(item, variant);
                item.dyeColor = ItemBuilder.RandomClothingDye();
                item.currentCondition = (int)(item.maxCondition * conditionMod);
            }
            return item;
        }

        public static DaggerfallUnityItem ChooseRandomStraps()
        {
            DaggerfallUnityItem item = null;
            Genders gender = GameManager.Instance.PlayerEntity.Gender;
            Races race = GameManager.Instance.PlayerEntity.Race;
            float conditionMod = (float)UnityEngine.Random.Range(15, 65 + 1) / 100f;

            if (gender == Genders.Female)
            {
                int piece = UnityEngine.Random.Range(0, 4);
                if (piece == 0) { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Loincloth); }
                else if (piece == 1) { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Formal_brassier); }
                else if (piece == 2) { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Wrap); }
                else { item = ItemBuilder.CreateItem(ItemGroups.WomensClothing, (int)WomensClothing.Brassier); }
            }
            else
            {
                int piece = UnityEngine.Random.Range(0, 7);
                if (piece == 0) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Loincloth); }
                else if (piece == 1) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Toga); }
                else if (piece == 2) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Wrap); }
                else if (piece == 3) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Challenger_Straps); }
                else if (piece == 4) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Champion_straps); }
                else if (piece == 5) { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Sash); }
                else { item = ItemBuilder.CreateItem(ItemGroups.MensClothing, (int)MensClothing.Straps); }
            }

            if (item != null)
            {
                int variant = UnityEngine.Random.Range(0, item.ItemTemplate.variants);
                ItemBuilder.SetRace(item, race);
                ItemBuilder.SetVariant(item, variant);
                item.dyeColor = ItemBuilder.RandomClothingDye();
                item.currentCondition = (int)(item.maxCondition * conditionMod);
            }
            return item;
        }

        public static DaggerfallUnityItem CreatePouchDrops() // May add more possible items later, but for now just gold pieces.
        {
            DaggerfallUnityItem item = null;
            int amount = UnityEngine.Random.Range(10, 120 + 1);

            item = ItemBuilder.CreateGoldPieces(amount);
            return item;
        }

        public static DaggerfallUnityItem CreateRandomPainting()
        {
            DaggerfallUnityItem item = null;
            float conditionMod = (float)UnityEngine.Random.Range(10, 70 + 1) / 100f;

            item = ItemBuilder.CreateItem(ItemGroups.Paintings, (int)Paintings.Painting);

            if (item != null) { item.currentCondition = (int)(item.maxCondition * conditionMod); }
            return item;
        }

        public static DaggerfallUnityItem CreateRandomAnimalTooth()
        {
            DaggerfallUnityItem item = null;
            int size = UnityEngine.Random.Range(0, 3);

            if (size == 0) { item = ItemBuilder.CreateItem(ItemGroups.MiscellaneousIngredients1, (int)MiscellaneousIngredients1.Small_tooth); }
            else if (size == 1) { item = ItemBuilder.CreateItem(ItemGroups.MiscellaneousIngredients1, (int)MiscellaneousIngredients1.Medium_tooth); }
            else if (size == 2) { item = ItemBuilder.CreateItem(ItemGroups.MiscellaneousIngredients1, (int)MiscellaneousIngredients1.Big_tooth); }

            return item;
        }
    }
}

