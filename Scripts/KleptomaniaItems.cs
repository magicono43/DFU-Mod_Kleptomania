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

        public override int InventoryTextureArchive
        {
            get { return CurrentVariant; }
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

    public class ItemJugsJarsPots : DaggerfallUnityItem
    {
        public const int templateIndex = 4744;

        public ItemJugsJarsPots() : base(ItemGroups.UselessItems2, templateIndex)
        {
        }

        public override bool IsStackable()
        {
            return true;
        }

        public override int InventoryTextureArchive
        {
            get { return CurrentVariant; }
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
            data.className = typeof(ItemJugsJarsPots).ToString();
            return data;
        }
    }

    public class ItemSpoon : DaggerfallUnityItem
    {
        public const int templateIndex = 4745;

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
        public const int templateIndex = 4746;

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
        public const int templateIndex = 4747;

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
        public const int templateIndex = 4748;

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
        public const int templateIndex = 4749;

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
        public const int templateIndex = 4750;

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
        public const int templateIndex = 4751;

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
        public const int templateIndex = 4752;

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
        public const int templateIndex = 4753;

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
        public const int templateIndex = 4754;

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
        public const int templateIndex = 4755;

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
        public const int templateIndex = 4756;

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
        public const int templateIndex = 4757;

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
                    item.shortName = "Leather Scrap"; // work on adding the variants for the goblets, and the clay pots tomorrow.
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Leather;
                    item.weightInKg = 0.1f;
                    item.value = 1;
                    item.CurrentVariant = 0; break;
                case 1:
                    item.shortName = "Iron Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Iron;
                    item.weightInKg = 0.2f;
                    item.value = 3;
                    item.CurrentVariant = 1; break;
                case 2:
                    item.shortName = "Steel Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Steel;
                    item.weightInKg = 0.25f;
                    item.value = 6;
                    item.CurrentVariant = 2; break;
                case 3:
                    item.shortName = "Silver Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Silver;
                    item.weightInKg = 0.2f;
                    item.value = 12;
                    item.CurrentVariant = 3; break;
                case 4:
                    item.shortName = "Elven Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Elven;
                    item.weightInKg = 0.2f;
                    item.value = 24;
                    item.CurrentVariant = 4; break;
                case 5:
                    item.shortName = "Dwarven Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Dwarven;
                    item.weightInKg = 0.15f;
                    item.value = 48;
                    item.CurrentVariant = 5; break;
                case 6:
                    item.shortName = "Mithril Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Mithril;
                    item.weightInKg = 0.2f;
                    item.value = 96;
                    item.CurrentVariant = 6; break;
                case 7:
                    item.shortName = "Adamantium Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Adamantium;
                    item.weightInKg = 0.2f;
                    item.value = 192;
                    item.CurrentVariant = 7; break;
                case 8:
                    item.shortName = "Ebony Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Ebony;
                    item.weightInKg = 0.1f;
                    item.value = 384;
                    item.CurrentVariant = 8; break;
                case 9:
                    item.shortName = "Orcish Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Orcish;
                    item.weightInKg = 0.2f;
                    item.value = 768;
                    item.CurrentVariant = 9; break;
                case 10:
                    item.shortName = "Daedric Scrap";
                    item.nativeMaterialValue = (int)ArmorMaterialTypes.Daedric;
                    item.weightInKg = 0.25f;
                    item.value = 1536;
                    item.CurrentVariant = 10; break;
            }
            item.message = cupMat;

            return item;
        }
    }
}

