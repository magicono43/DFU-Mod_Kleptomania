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
                            if (roll >= 30 && ObjTexRecord <= 69) { item = KMItemBuilder.CreateRandomPotionRecipe(); }
                            else if (roll >= 70 && ObjTexRecord <= 96) { } // Flavor text note/letter or quest thing.
                            else if (roll >= 97 && ObjTexRecord <= 100) { item = KMItemBuilder.CreateRandomLetterofCredit(750, 1500); }
                            else { item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Parchment); }
                            break;
                        case DFLocation.BuildingTypes.Armorer:
                            break;
                        case DFLocation.BuildingTypes.WeaponSmith:
                            break;
                        case DFLocation.BuildingTypes.GeneralStore:
                            break;
                        case DFLocation.BuildingTypes.PawnShop:
                            break;
                        case DFLocation.BuildingTypes.GemStore:
                            break;
                        case DFLocation.BuildingTypes.ClothingStore:
                            break;
                        case DFLocation.BuildingTypes.Bookseller:
                        case DFLocation.BuildingTypes.Library:
                            break;
                        case DFLocation.BuildingTypes.Bank:
                            break;
                        default:
                            break;
                    }
                }
                else if (buildingType == DFLocation.BuildingTypes.Tavern)
                {
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
