using UnityEngine;
using DaggerfallConnect;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Items;
using System.Collections.Generic;
using DaggerfallWorkshop.Game.Utility;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Guilds;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop.Utility;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
        public static int Stren { get { return Player.Stats.LiveStrength - 50; } }
        public static int Intel { get { return Player.Stats.LiveIntelligence - 50; } }
        public static int Willp { get { return Player.Stats.LiveWillpower - 50; } }
        public static int Agili { get { return Player.Stats.LiveAgility - 50; } }
        public static int Endur { get { return Player.Stats.LiveEndurance - 50; } }
        public static int Speed { get { return Player.Stats.LiveSpeed - 50; } }
        public static int Luck { get { return Player.Stats.LiveLuck - 50; } }
        public static int LockP { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Lockpicking); } }
        public static int PickP { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Pickpocket); } }
        public static int Sneak { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Stealth); } }
        public static int Alter { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Alteration); } }
        public static int Destr { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Destruction); } }
        public static int Illus { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Illusion); } }
        public static int Mysti { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Mysticism); } }
        public static int Thaum { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Thaumaturgy); } }

        public static bool DoesThisEncumberPlayer(DaggerfallUnityItem item)
        {
            if (item == null) { return false; }
            return (Player.CarriedWeight + item.weightInKg) > Player.MaxEncumbrance;
        }

        public static void IsThisACrime() // Later will likely have the weight of the item be a factor in the odds of being detected or not, will see later on.
        {
            if (IsValidCrimeLocation())
            {
                PlayerGPS.DiscoveredBuilding buildingData = GameManager.Instance.PlayerEnterExit.BuildingDiscoveryData;
                DFLocation.BuildingTypes buildingType = GameManager.Instance.PlayerEnterExit.BuildingDiscoveryData.buildingType;

                GameManager.Instance.PlayerEntity.TallyCrimeGuildRequirements(true, 1);
                if (TheftDetectionCheck(buildingData, buildingType))
                    RegisterDetectedPunishment(buildingData, buildingType);
            }
        }

        public static bool TheftDetectionCheck(PlayerGPS.DiscoveredBuilding buildingData, DFLocation.BuildingTypes buildingType)
        {
            int detectionChance = (30 + (buildingData.quality * 3)) * -1;
            int closedMod = BuildingOpenCheck(buildingData, buildingType) ? 0 : 40;
            int sneakChance = Mathf.RoundToInt(Sneak * 0.7f) + Mathf.RoundToInt(PickP * 0.5f) + Mathf.RoundToInt(Agili * 0.6f) + Mathf.RoundToInt(Luck * 0.4f) + closedMod;

            Player.TallySkill(DFCareer.Skills.Stealth, 1);
            Player.TallySkill(DFCareer.Skills.Pickpocket, 1);

            if (Dice100.SuccessRoll(Mathf.RoundToInt(Mathf.Clamp(detectionChance + sneakChance, 7f, 93f))))
                return false;
            else
                return true;
        }

        public static void RegisterDetectedPunishment(PlayerGPS.DiscoveredBuilding buildingData, DFLocation.BuildingTypes bT)
        {
            PlayerEntity playerEntity = GameManager.Instance.PlayerEntity;

            if (playerEntity != null)
            {
                if (IsValidShop(bT) || bT == DFLocation.BuildingTypes.Tavern || IsValidTownHouse(bT) || bT == DFLocation.BuildingTypes.Palace)
                {
                    DaggerfallUI.AddHUDText("You were detected...", 2f);
                    playerEntity.CrimeCommitted = PlayerEntity.Crimes.Theft;
                    playerEntity.SpawnCityGuards(true);
                }
                else if (bT == DFLocation.BuildingTypes.Temple)
                {
                    int factionID = buildingData.factionID;
                    FactionFile.FactionData factionData = playerEntity.FactionData.FactionDict[factionID];
                    string factionName = factionData.name;
                    DaggerfallUI.AddHUDText("You were detected, " + factionName + " disproves of this transgression...", 3f);
                    playerEntity.FactionData.ChangeReputation(factionID, -2, true);
                    playerEntity.CrimeCommitted = PlayerEntity.Crimes.Theft;
                    playerEntity.SpawnCityGuards(true);
                }
                else if (bT == DFLocation.BuildingTypes.GuildHall)
                {
                    int factionID = buildingData.factionID;

                    if (factionID == (int)FactionFile.FactionIDs.The_Mages_Guild || factionID == (int)FactionFile.FactionIDs.The_Fighters_Guild || OwnedByKnightlyOrder(factionID))
                    {
                        FactionFile.FactionData factionData = playerEntity.FactionData.FactionDict[factionID];
                        string factionName = factionData.name;
                        DaggerfallUI.AddHUDText("You were detected, " + factionName + " disproves of this transgression...", 3f);
                        playerEntity.FactionData.ChangeReputation(factionID, -2, true);
                        playerEntity.CrimeCommitted = PlayerEntity.Crimes.Theft;
                        playerEntity.SpawnCityGuards(true);
                    }
                    else if (factionID == (int)FactionFile.FactionIDs.The_Thieves_Guild)
                    {
                        DaggerfallUI.AddHUDText("You were detected, bad thieves bring shame to the entire guild...", 3f);
                        playerEntity.FactionData.ChangeReputation(factionID, -4, true);
                        FactionFile.FactionData factionData = playerEntity.FactionData.FactionDict[factionID];
                        if (factionData.rep < 0)
                        {
                            GameObjectHelper.CreateFoeSpawner(false, MobileTypes.Rogue, 2, 3, 8); // Make 2 instances so maybe they will spawn more quickly?
                            GameObjectHelper.CreateFoeSpawner(false, MobileTypes.Rogue, 2, 3, 8);
                        }
                    }
                    else if (factionID == (int)FactionFile.FactionIDs.The_Dark_Brotherhood)
                    {
                        DaggerfallUI.AddHUDText("You were detected, The Dark Brotherhood does not approve stealing from your own kin...", 3f);
                        playerEntity.FactionData.ChangeReputation(factionID, -4, true);
                        FactionFile.FactionData factionData = playerEntity.FactionData.FactionDict[factionID];
                        if (factionData.rep < 0)
                        {
                            GameObjectHelper.CreateFoeSpawner(false, MobileTypes.Assassin, 2, 3, 8); // Make 2 instances so maybe they will spawn more quickly?
                            GameObjectHelper.CreateFoeSpawner(false, MobileTypes.Assassin, 2, 3, 8);
                        }
                    }
                }
            }
        }

        public static bool IsValidCrimeLocation()
        {
            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeon)
                return false;

            DFLocation.BuildingTypes bT = GameManager.Instance.PlayerEnterExit.BuildingDiscoveryData.buildingType;

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInside)
            {
                if (IsValidShop(bT) || bT == DFLocation.BuildingTypes.Tavern || bT == DFLocation.BuildingTypes.Temple || bT == DFLocation.BuildingTypes.GuildHall ||
                    IsValidTownHouse(bT) || bT == DFLocation.BuildingTypes.Palace)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidShop(DFLocation.BuildingTypes buildingType) // Check if building shop type is valid to have chests be spawned in it.
        {
            switch (buildingType)
            {
                case DFLocation.BuildingTypes.Alchemist:
                case DFLocation.BuildingTypes.Armorer:
                case DFLocation.BuildingTypes.WeaponSmith:
                case DFLocation.BuildingTypes.GeneralStore:
                case DFLocation.BuildingTypes.PawnShop:
                case DFLocation.BuildingTypes.FurnitureStore:
                case DFLocation.BuildingTypes.GemStore:
                case DFLocation.BuildingTypes.ClothingStore:
                case DFLocation.BuildingTypes.Bookseller:
                case DFLocation.BuildingTypes.Library:
                case DFLocation.BuildingTypes.Bank:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsValidTownHouse(DFLocation.BuildingTypes buildingType)
        {
            switch (buildingType) // Just including basically everything that I don't know what they represent, just in-case, can remove some if necessary when I do know more.
            {
                case DFLocation.BuildingTypes.AnyHouse:
                case DFLocation.BuildingTypes.Town4:
                case DFLocation.BuildingTypes.Town23:
                case DFLocation.BuildingTypes.HouseForSale:
                case DFLocation.BuildingTypes.Special1:
                case DFLocation.BuildingTypes.Special2:
                case DFLocation.BuildingTypes.Special3:
                case DFLocation.BuildingTypes.Special4:
                case DFLocation.BuildingTypes.House1:
                case DFLocation.BuildingTypes.House2:
                case DFLocation.BuildingTypes.House3:
                case DFLocation.BuildingTypes.House4:
                case DFLocation.BuildingTypes.House5:
                case DFLocation.BuildingTypes.House6:
                    return true;
                default:
                    return false;
            }
        }

        public static bool BuildingOpenCheck(PlayerGPS.DiscoveredBuilding buildingData, DFLocation.BuildingTypes buildingType)
        {
            /*
             * Open Hours For Specific Places:
             * Temples, Dark Brotherhood, Thieves Guild: 24/7
             * All Other Guilds: 11:00 - 23:00
             * Fighters Guild & Mages Guild, Rank 6 = 24/7 Access
             * 
             * Alchemists: 07:00 - 22:00
             * Armorers: 09:00 - 19:00
             * Banks: 08:00 - 15:00
             * Bookstores: 	09:00 - 21:00
             * Clothing Stores: 10:00 - 19:00
             * Gem Stores: 09:00 - 18:00
             * General Stores + Furniture Stores: 06:00 - 23:00
             * Libraries: 09:00 - 23:00
             * Pawn Shops + Weapon Smiths: 09:00 - 20:00
            */

            int buildingInt = (int)buildingType;
            int hour = DaggerfallUnity.Instance.WorldTime.Now.Hour;
            IGuild guild = GameManager.Instance.GuildManager.GetGuild(buildingData.factionID);
            if (buildingType == DFLocation.BuildingTypes.GuildHall && (PlayerActivate.IsBuildingOpen(buildingType) || guild.HallAccessAnytime()))
                return true;
            if (buildingInt < 18)
                return PlayerActivate.IsBuildingOpen(buildingType);
            else if (buildingInt <= 22)
                return hour < 6 || hour > 18 ? false : true;
            else
                return true;
        }

        public static bool OwnedByKnightlyOrder(int factionID)
        {
            switch (factionID)
            {
                case (int)FactionFile.FactionIDs.The_Host_of_the_Horn:
                case (int)FactionFile.FactionIDs.The_Knights_of_the_Dragon:
                case (int)FactionFile.FactionIDs.The_Knights_of_the_Flame:
                case (int)FactionFile.FactionIDs.The_Knights_of_the_Hawk:
                case (int)FactionFile.FactionIDs.The_Knights_of_the_Owl:
                case (int)FactionFile.FactionIDs.The_Knights_of_the_Rose:
                case (int)FactionFile.FactionIDs.The_Knights_of_the_Wheel:
                case (int)FactionFile.FactionIDs.The_Order_of_the_Candle:
                case (int)FactionFile.FactionIDs.The_Order_of_the_Raven:
                case (int)FactionFile.FactionIDs.The_Order_of_the_Scarab:
                    return true;
                default:
                    return false;
            }
        }

        public static bool WithinMarginOfErrorPos(Vector3 value1, Vector3 value2, float xAcceptDif, float yAcceptDif, float zAcceptDif)
        {
            bool xEqual = Mathf.Abs(value1.x - value2.x) <= xAcceptDif;
            bool yEqual = Mathf.Abs(value1.y - value2.y) <= yAcceptDif;
            bool zEqual = Mathf.Abs(value1.z - value2.z) <= zAcceptDif;

            return xEqual && yEqual && zEqual;
        }

        public static bool CoinFlip()
        {
            if (UnityEngine.Random.Range(0, 1 + 1) == 0)
                return false;
            else
                return true;
        }

        public static T[] FillArray<T>(List<T> list, int start, int count, T value)
        {
            for (var i = start; i < start + count; i++)
            {
                list.Add(value);
            }

            return list.ToArray();
        }

        public static int PickOneOf(params int[] values) // Pango provided assistance in making this much cleaner way of doing the random value choice part, awesome.
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }
    }
}
