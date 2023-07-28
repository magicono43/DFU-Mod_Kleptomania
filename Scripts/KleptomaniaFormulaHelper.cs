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
using System.Linq;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
        public static int Agili { get { return Player.Stats.LiveAgility - 50; } }
        public static int Luck { get { return Player.Stats.LiveLuck - 50; } }
        public static int PickP { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Pickpocket); } }
        public static int Sneak { get { return Player.Skills.GetLiveSkillValue(DFCareer.Skills.Stealth); } }

        public static bool DoesThisEncumberPlayer(float itemWeights)
        {
            return (Player.CarriedWeight + itemWeights) > Player.MaxEncumbrance;
        }

        public static int RollWeaponOrArmorMaterial(bool isWeapon = true, bool isShield = false, bool multiple = false)
        {
            // Iron, Steel, Silver, Elven, Dwarven, Mithril, Adamantium, Ebony, Orcish, Daedric
            List<float> matOdds = new List<float>() { 17.8f, 16.5f, 15.0f, 13.7f, 11.6f, 9.5f, 6.8f, 4.8f, 2.8f, 1.5f };

            if (isShield)
            {
                int shieldMat = UnityEngine.Random.Range(0, 4);

                if (shieldMat == 0)
                    return (int)ArmorMaterialTypes.Leather;
                else if (shieldMat == 1)
                    return (int)ArmorMaterialTypes.Chain;
            }

            matOdds = new List<float>() { 54.0f, 46.5f, 42.2f, 26.4f, 10.3f, 6.8f, 3.7f, 2.7f, 1.7f, 0.8f };

            // Makes sure any matOdds value can't go below 0.5f at the lowest.
            for (int i = 0; i < matOdds.Count; i++)
            {
                if (matOdds[i] < 0.5f) { matOdds[i] = 0.5f; }
            }

            if (multiple) // This is to restrict the materials that can be selected for instances that clicking an object gives multiple of some item, like a stack of swords, etc.
            {
                matOdds = new List<float>() { 54.0f, 46.5f, 42.2f, 26.4f, 10.3f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            }

            // Normalize matOdds values to ensure they all add up to 100.
            float totalOddsSum = matOdds.Sum();
            for (int i = 0; i < matOdds.Count; i++)
            {
                matOdds[i] = (matOdds[i] / totalOddsSum) * 100f;
            }

            // Choose a material using the weighted random selection algorithm.
            float randomValue = UnityEngine.Random.Range(0f, 101f);
            float cumulativeOdds = 0f;
            int index = 0;
            for (int i = 0; i < matOdds.Count; i++)
            {
                cumulativeOdds += matOdds[i];
                if (randomValue < cumulativeOdds)
                {
                    index = i; // Material i is chosen
                    break;
                }
            }

            if (isWeapon)
            {
                return index;
            }
            else
            {
                return 0x0200 + index;
            }
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
            else if (IsValidDungeonLocation())
            {
                DFLocation locationData = GameManager.Instance.PlayerGPS.CurrentLocation;

                PunishDungeonTheft(locationData);
            }
        }

        public static bool TheftDetectionCheck(PlayerGPS.DiscoveredBuilding buildingData, DFLocation.BuildingTypes buildingType)
        {
            int detectionChance = (45 + (buildingData.quality * 5));
            int closedMod = BuildingOpenCheck(buildingData, buildingType) ? 0 : 40;
            int sneakChance = (Mathf.RoundToInt(Sneak * 0.6f) + Mathf.RoundToInt(PickP * 0.4f) + Mathf.RoundToInt(Agili * 0.7f) + Mathf.RoundToInt(Luck * 0.4f) + closedMod) * -1;

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeonCastle)
                detectionChance = 115;

            Player.TallySkill(DFCareer.Skills.Stealth, 1);
            Player.TallySkill(DFCareer.Skills.Pickpocket, 1);

            if (Dice100.SuccessRoll(Mathf.RoundToInt(Mathf.Clamp(detectionChance + sneakChance, 7f, 93f))))
                return true;
            else
                return false;
        }

        public static void RegisterDetectedPunishment(PlayerGPS.DiscoveredBuilding buildingData, DFLocation.BuildingTypes bT)
        {
            PlayerEntity playerEntity = GameManager.Instance.PlayerEntity;

            if (playerEntity != null)
            {
                if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeonCastle) // Not sure if this works, will have to test.
                {
                    DaggerfallUI.AddHUDText("You were detected...", 2f); // Won't make rest of castle "guards" hostile, because I don't want to potentially mess with mods like Follower Overhaul, so whatever for now.
                    GameObjectHelper.CreateFoeSpawner(false, MobileTypes.Knight, 2, 3, 8); // Make 2 instances so maybe they will spawn more quickly?
                    GameObjectHelper.CreateFoeSpawner(false, MobileTypes.Knight, 2, 3, 8);
                }
                else if (IsValidShop(bT) || bT == DFLocation.BuildingTypes.Tavern || IsValidTownHouse(bT) || bT == DFLocation.BuildingTypes.Palace)
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

        public static void PunishDungeonTheft(DFLocation locData)
        {
            PlayerEntity playerEntity = GameManager.Instance.PlayerEntity;
            int[] enemyType = new int[] { (int)MobileTypes.Rat };
            int roll = 0;
            int detectionChance = 15;
            int sneakChance = (Mathf.RoundToInt(Sneak * 0.2f) + Mathf.RoundToInt(PickP * 0.1f) + Mathf.RoundToInt(Agili * 0.2f) + Mathf.RoundToInt(Luck * 0.1f)) * -1;

            if (playerEntity != null && GameManager.Instance.PlayerEnterExit.IsPlayerInside)
            {
                switch (locData.MapTableData.DungeonType)
                {
                    case DFRegion.DungeonTypes.Crypt: enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.SkeletalWarrior, (int)MobileTypes.Zombie, (int)MobileTypes.Ghost, (int)MobileTypes.Mummy, (int)MobileTypes.Vampire }; break;
                    case DFRegion.DungeonTypes.VampireHaunt: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.SkeletalWarrior, (int)MobileTypes.Zombie, (int)MobileTypes.Ghost, (int)MobileTypes.Mummy, (int)MobileTypes.Vampire }; break;
                    case DFRegion.DungeonTypes.OrcStronghold: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.GrizzlyBear, (int)MobileTypes.Orc, (int)MobileTypes.OrcSergeant, (int)MobileTypes.OrcShaman }; break;
                    case DFRegion.DungeonTypes.HumanStronghold: detectionChance = 30; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Archer, (int)MobileTypes.Battlemage, (int)MobileTypes.Knight, (int)MobileTypes.Mage, (int)MobileTypes.Nightblade, (int)MobileTypes.Rogue, (int)MobileTypes.Sorcerer, (int)MobileTypes.Spellsword, (int)MobileTypes.Warrior }; break;
                    case DFRegion.DungeonTypes.Prison: detectionChance = 20; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.Assassin, (int)MobileTypes.Barbarian, (int)MobileTypes.Burglar, (int)MobileTypes.Nightblade, (int)MobileTypes.Rogue, (int)MobileTypes.Thief }; break;
                    case DFRegion.DungeonTypes.DesecratedTemple: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.Imp, (int)MobileTypes.Gargoyle, (int)MobileTypes.Healer, (int)MobileTypes.Monk, (int)MobileTypes.Sorcerer, (int)MobileTypes.Ghost, (int)MobileTypes.Mummy, (int)MobileTypes.Wraith }; break;
                    case DFRegion.DungeonTypes.Coven: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.Imp, (int)MobileTypes.Gargoyle, (int)MobileTypes.Werewolf, (int)MobileTypes.Wereboar, (int)MobileTypes.Harpy, (int)MobileTypes.FleshAtronach, (int)MobileTypes.SkeletalWarrior, (int)MobileTypes.Zombie, (int)MobileTypes.Ghost, (int)MobileTypes.Wraith, (int)MobileTypes.Vampire, (int)MobileTypes.Daedroth }; break;
                    case DFRegion.DungeonTypes.Laboratory: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.Imp, (int)MobileTypes.Gargoyle, (int)MobileTypes.FleshAtronach, (int)MobileTypes.IronAtronach, (int)MobileTypes.FireAtronach, (int)MobileTypes.IceAtronach, (int)MobileTypes.Zombie, (int)MobileTypes.Harpy, (int)MobileTypes.Werewolf, (int)MobileTypes.Wereboar, (int)MobileTypes.Mage }; break;
                    case DFRegion.DungeonTypes.HarpyNest: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Harpy, (int)MobileTypes.Werewolf, (int)MobileTypes.Wereboar, (int)MobileTypes.Nymph }; break;
                    case DFRegion.DungeonTypes.Mine: detectionChance = 20; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.Giant, (int)MobileTypes.Orc, (int)MobileTypes.OrcSergeant, (int)MobileTypes.IronAtronach, (int)MobileTypes.Ghost, (int)MobileTypes.Thief, (int)MobileTypes.Rogue }; break;
                    case DFRegion.DungeonTypes.NaturalCave: enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.GrizzlyBear, (int)MobileTypes.SabertoothTiger, (int)MobileTypes.Spriggan, (int)MobileTypes.Nymph, (int)MobileTypes.Giant, (int)MobileTypes.Centaur, (int)MobileTypes.Orc, (int)MobileTypes.Ranger, (int)MobileTypes.Barbarian, (int)MobileTypes.Thief, (int)MobileTypes.Rogue }; break;
                    case DFRegion.DungeonTypes.SpiderNest: detectionChance = 30; enemyType = new int[] { (int)MobileTypes.Spider }; break;
                    case DFRegion.DungeonTypes.ScorpionNest: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.GiantScorpion }; break;
                    case DFRegion.DungeonTypes.VolcanicCaves: detectionChance = 20; enemyType = new int[] { (int)MobileTypes.Dragonling, (int)MobileTypes.Imp, (int)MobileTypes.Gargoyle, (int)MobileTypes.FireAtronach, (int)MobileTypes.IronAtronach, (int)MobileTypes.FireDaedra, (int)MobileTypes.Sorcerer }; break;
                    case DFRegion.DungeonTypes.RuinedCastle: detectionChance = 20; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.Dragonling, (int)MobileTypes.Ghost, (int)MobileTypes.Giant, (int)MobileTypes.Orc, (int)MobileTypes.OrcSergeant, (int)MobileTypes.Centaur, (int)MobileTypes.Werewolf, (int)MobileTypes.Wereboar, (int)MobileTypes.Archer, (int)MobileTypes.Battlemage, (int)MobileTypes.Knight, (int)MobileTypes.Mage, (int)MobileTypes.Nightblade, (int)MobileTypes.Thief, (int)MobileTypes.Rogue, (int)MobileTypes.Sorcerer, (int)MobileTypes.Spellsword, (int)MobileTypes.Warrior }; break;
                    case DFRegion.DungeonTypes.GiantStronghold: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.GrizzlyBear, (int)MobileTypes.Giant, (int)MobileTypes.Gargoyle, (int)MobileTypes.Barbarian }; break;
                    case DFRegion.DungeonTypes.BarbarianStronghold: detectionChance = 30; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.GrizzlyBear, (int)MobileTypes.SabertoothTiger, (int)MobileTypes.Centaur, (int)MobileTypes.Orc, (int)MobileTypes.OrcSergeant, (int)MobileTypes.Barbarian }; break;
                    case DFRegion.DungeonTypes.DragonsDen: detectionChance = 25; enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.Spider, (int)MobileTypes.Dragonling }; break;
                    case DFRegion.DungeonTypes.Cemetery: enemyType = new int[] { (int)MobileTypes.Rat, (int)MobileTypes.GiantBat, (int)MobileTypes.Spider, (int)MobileTypes.SkeletalWarrior, (int)MobileTypes.Zombie, (int)MobileTypes.Thief, (int)MobileTypes.Rogue }; break;
                    default:
                        break;
                }

                if (enemyType.Length > 1)
                    roll = UnityEngine.Random.Range(0, enemyType.Length);

                if (Dice100.SuccessRoll(Mathf.RoundToInt(Mathf.Clamp(detectionChance + sneakChance, 3f, 55f))))
                {
                    DaggerfallUI.AddHUDText("Your sticky fingers got the attention of someone, or something...", 3f); // Might add more text variants for this, will see.
                    GameObjectHelper.CreateFoeSpawner(true, (MobileTypes)enemyType[roll], 1, 6);
                }
            }
        }

        public static bool IsValidCrimeLocation()
        {
            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeonCastle) // Not sure if this works, will have to test.
                return true;

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

        public static bool IsValidDungeonLocation()
        {
            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeonCastle) // Not sure if this works, will have to test.
                return false;

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeon)
                return true;

            return false;
        }

        public static bool IsValidShop(DFLocation.BuildingTypes buildingType)
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
    }
}
