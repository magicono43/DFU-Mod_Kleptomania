using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.Serialization;

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

    public static class KleptomaniaItemBuilder
    {
        public static DaggerfallUnityItem CreateGobletCupVariant()
        {
            int cupMat = 0;

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

        public static DaggerfallUnityItem CreateClayPotVariant()
        {
            int potMat = 0;

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
    }
}
