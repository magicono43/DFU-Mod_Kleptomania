using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game;
using DaggerfallConnect;
using DaggerfallWorkshop;
using DaggerfallConnect.Arena2;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
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
                    // Continue here tomorrow or next time I work on this I suppose.
                }
                else if (buildingType == DFLocation.BuildingTypes.Palace)
                {
                }
                else if (IsValidTownHouse(buildingType))
                {
                }
                else if (buildingType == DFLocation.BuildingTypes.Temple)
                {
                }
                else if (buildingType == DFLocation.BuildingTypes.GuildHall)
                {
                    switch (buildingData.factionID)
                    {
                        case (int)FactionFile.FactionIDs.The_Mages_Guild:
                            break;
                        case (int)FactionFile.FactionIDs.The_Fighters_Guild:
                            break;
                        case (int)FactionFile.FactionIDs.Generic_Knightly_Order: // Will have to test if this one actually works for all the knightly orders or not, will see.
                            break;
                        case (int)FactionFile.FactionIDs.The_Thieves_Guild:
                            break;
                        case (int)FactionFile.FactionIDs.The_Dark_Brotherhood:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return item;
                }
            }
            return item;
        }

        public void LettersDungeonContextLogic()
        {
            DFLocation locationData = GameManager.Instance.PlayerGPS.CurrentLocation;

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInside)
            {
                switch (locationData.MapTableData.DungeonType)
                {
                    case DFRegion.DungeonTypes.Crypt:
                        break;
                    case DFRegion.DungeonTypes.OrcStronghold:
                        break;
                    case DFRegion.DungeonTypes.HumanStronghold:
                        break;
                    case DFRegion.DungeonTypes.Prison:
                        break;
                    case DFRegion.DungeonTypes.DesecratedTemple:
                        break;
                    case DFRegion.DungeonTypes.Mine:
                        break;
                    case DFRegion.DungeonTypes.NaturalCave:
                        break;
                    case DFRegion.DungeonTypes.Coven:
                        break;
                    case DFRegion.DungeonTypes.VampireHaunt:
                        break;
                    case DFRegion.DungeonTypes.Laboratory:
                        break;
                    case DFRegion.DungeonTypes.HarpyNest:
                        break;
                    case DFRegion.DungeonTypes.RuinedCastle:
                        break;
                    case DFRegion.DungeonTypes.SpiderNest:
                        break;
                    case DFRegion.DungeonTypes.GiantStronghold:
                        break;
                    case DFRegion.DungeonTypes.DragonsDen:
                        break;
                    case DFRegion.DungeonTypes.BarbarianStronghold:
                        break;
                    case DFRegion.DungeonTypes.VolcanicCaves:
                        break;
                    case DFRegion.DungeonTypes.ScorpionNest:
                        break;
                    case DFRegion.DungeonTypes.Cemetery:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
