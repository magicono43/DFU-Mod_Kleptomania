using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game;
using DaggerfallConnect;
using DaggerfallWorkshop;
using DaggerfallConnect.Arena2;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
        public static DaggerfallUnityItem GetLetterItemDungeonOrInterior()
        {
            DaggerfallUnityItem item = null;
            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeon) { item = LettersDungeonContextLogic(); }
            else { item = LettersBuildingInteriorContextLogic(); }
            return item;
        }

        public static DaggerfallUnityItem LettersBuildingInteriorContextLogic()
        {
            DaggerfallUnityItem item = null;
            DFLocation.BuildingTypes buildingType = GameManager.Instance.PlayerEnterExit.BuildingDiscoveryData.buildingType;
            PlayerGPS.DiscoveredBuilding buildingData = GameManager.Instance.PlayerEnterExit.BuildingDiscoveryData;
            int roll = UnityEngine.Random.Range(0, 101);

            if (DaggerfallWorkshop.Game.Banking.DaggerfallBankManager.IsHouseOwned(buildingData.buildingKey))
                return item;

            if (buildingType == DFLocation.BuildingTypes.Ship && DaggerfallWorkshop.Game.Banking.DaggerfallBankManager.OwnsShip)
                return item;

            /*
             * Blank piece of parchment
             * Flavor text note/letter related to location it was found in, some of these may give a "quest" of sorts if the player wishes to accept it.
             * Potion recipe
             * Dungeon map
             * Letter of credit
            */

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInside)
            {
                if (IsValidShop(buildingType))
                {
                    switch (buildingType)
                    {
                        case DFLocation.BuildingTypes.Alchemist:
                            if (roll >= 65 && ObjTexRecord <= 96) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                            else if (roll >= 97 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(750, 1500); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.Armorer:
                        case DFLocation.BuildingTypes.WeaponSmith:
                            if (roll >= 91 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1500, 3500); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.GeneralStore:
                            if (roll >= 72 && ObjTexRecord <= 94) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 95 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1250, 2750); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.PawnShop:
                            if (roll >= 35 && ObjTexRecord <= 60) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                            else if (roll >= 61 && ObjTexRecord <= 95) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 96 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1000, 2250); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.GemStore:
                            if (roll >= 91 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1500, 3000); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.ClothingStore:
                            if (roll >= 93 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(850, 1850); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.Bookseller:
                        case DFLocation.BuildingTypes.Library:
                            if (roll >= 40 && ObjTexRecord <= 65) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                            else if (roll >= 66 && ObjTexRecord <= 97) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 98 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(500, 1000); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.Bank:
                            if (roll >= 76 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(3000, 7000); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        default:
                            item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment);
                            break;
                    }
                }
                else if (buildingType == DFLocation.BuildingTypes.Tavern)
                {
                    if (roll >= 45 && ObjTexRecord <= 64) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                    else if (roll >= 65 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                    else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(600, 2000); }
                    else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                }
                else if (buildingType == DFLocation.BuildingTypes.Palace)
                {
                    if (roll >= 65 && ObjTexRecord <= 84) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                    else if (roll >= 85 && ObjTexRecord <= 92) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                    else if (roll >= 93 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(2000, 5500); }
                    else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                }
                else if (IsValidTownHouse(buildingType))
                {
                    if (roll >= 55 && ObjTexRecord <= 74) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                    else if (roll >= 75 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                    else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(600, 2000); }
                    else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                }
                else if (buildingType == DFLocation.BuildingTypes.Temple)
                {
                    if (roll >= 60 && ObjTexRecord <= 91) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                    else if (roll >= 92 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                    else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(550, 1300); }
                    else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                }
                else if (buildingType == DFLocation.BuildingTypes.GuildHall)
                {
                    switch (buildingData.factionID)
                    {
                        case (int)FactionFile.FactionIDs.The_Mages_Guild:
                            if (roll >= 65 && ObjTexRecord <= 79) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                            else if (roll >= 80 && ObjTexRecord <= 95) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 96 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(750, 1650); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case (int)FactionFile.FactionIDs.The_Fighters_Guild:
                            if (roll >= 65 && ObjTexRecord <= 96) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 97 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(800, 1750); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case (int)FactionFile.FactionIDs.Generic_Knightly_Order: // Will have to test if this one actually works for all the knightly orders or not, will see.
                            if (roll >= 62 && ObjTexRecord <= 98) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 99 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(700, 1500); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case (int)FactionFile.FactionIDs.The_Thieves_Guild:
                            if (roll >= 75 && ObjTexRecord <= 92) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 93 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1000, 2250); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case (int)FactionFile.FactionIDs.The_Dark_Brotherhood:
                            if (roll >= 55 && ObjTexRecord <= 82) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                            else if (roll >= 83 && ObjTexRecord <= 98) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                            else if (roll >= 93 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1000, 3000); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        default:
                            item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment);
                            break;
                    }
                }
                else
                {
                    item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment);
                }
            }
            return item;
        }

        public static DaggerfallUnityItem LettersDungeonContextLogic()
        {
            DaggerfallUnityItem item = null;
            DFLocation locationData = GameManager.Instance.PlayerGPS.CurrentLocation;
            int roll = UnityEngine.Random.Range(0, 101);

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInside)
            {
                switch (locationData.MapTableData.DungeonType)
                {
                    case DFRegion.DungeonTypes.Crypt:
                    case DFRegion.DungeonTypes.VampireHaunt:
                        if (roll >= 55 && ObjTexRecord <= 74) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 75 && ObjTexRecord <= 97) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll >= 98 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1000, 5000); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.OrcStronghold:
                        if (roll >= 55 && ObjTexRecord <= 74) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 75 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(600, 2500); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.HumanStronghold:
                        if (roll >= 55 && ObjTexRecord <= 74) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 75 && ObjTexRecord <= 97) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll >= 98 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(750, 4000); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.Prison:
                        if (roll >= 85 && ObjTexRecord <= 98) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll >= 99 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(400, 1500); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.DesecratedTemple:
                    case DFRegion.DungeonTypes.Coven:
                    case DFRegion.DungeonTypes.Laboratory:
                    case DFRegion.DungeonTypes.HarpyNest:
                        if (roll >= 55 && ObjTexRecord <= 90) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 91 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(700, 4000); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.Mine:
                        if (roll >= 70 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(500, 2250); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.NaturalCave:
                    case DFRegion.DungeonTypes.SpiderNest:
                    case DFRegion.DungeonTypes.ScorpionNest:
                    case DFRegion.DungeonTypes.VolcanicCaves:
                        if (roll >= 70 && ObjTexRecord <= 84) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 85 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(400, 2000); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.RuinedCastle:
                        if (roll >= 55 && ObjTexRecord <= 69) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 70 && ObjTexRecord <= 97) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll >= 98 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1250, 6000); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.GiantStronghold:
                    case DFRegion.DungeonTypes.BarbarianStronghold:
                        if (roll >= 70 && ObjTexRecord <= 99) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll == 100) { item = KMItemBuilder.CreateRandomLetterofCredit(500, 1500); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.DragonsDen:
                        if (roll >= 45 && ObjTexRecord <= 59) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 60 && ObjTexRecord <= 98) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll >= 99 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(1500, 6500); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    case DFRegion.DungeonTypes.Cemetery:
                        if (roll >= 60 && ObjTexRecord <= 72) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                        else if (roll >= 73 && ObjTexRecord <= 98) { item = KMItemBuilder.CreateRandomDungeonMap(); }
                        else if (roll >= 99 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(500, 1750); }
                        else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                        break;
                    default:
                        item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment);
                        break;
                }
            }
            else
            {
                item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment);
            }
            return item;
        }
    }
}
