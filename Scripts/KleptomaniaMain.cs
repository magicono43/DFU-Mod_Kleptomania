// Project:         Kleptomania mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2023 Kirk.O
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Kirk.O
// Created On: 	    4/29/2023, 11:20 PM
// Last Edit:		5/7/2023, 1:30 PM
// Version:			1.00
// Special Thanks:  
// Modifier:

using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Game.Utility.ModSupport.ModSettings;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Questing;
using DaggerfallConnect;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Utility;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop.Utility;
using DaggerfallWorkshop.Game.Guilds;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using System;

namespace Kleptomania
{
    public class KleptomaniaMain : MonoBehaviour
    {
        public static KleptomaniaMain Instance;
        public static KleptomaniaSaveData ModSaveData = new KleptomaniaSaveData();

        static Mod mod;

        // Options
        public static bool TogglePotionsGlassBottles { get; set; }
        public static bool TogglePaperNotes { get; set; }
        public static bool ToggleBooks { get; set; }
        public static bool ToggleWeapons { get; set; }
        public static bool ToggleArmor { get; set; }
        public static bool ToggleClothing { get; set; }
        public static bool ToggleBandages { get; set; }
        public static bool ToggleJewelry { get; set; }
        public static bool ToggleReligiousObjects { get; set; }
        public static bool ToggleValuableDecorations { get; set; }
        public static bool ToggleExoticTools { get; set; }
        public static bool ToggleJugsPots { get; set; }
        public static bool ToggleLaborTools { get; set; }
        public static bool ToggleFoodAndCooking { get; set; }
        public static bool ToggleAlchemyIngredients { get; set; }

        // Global Variables
        public static GameObject ClickedObjRef { get; set; }
        public static int ObjTexArchive { get; set; }
        public static int ObjTexRecord { get; set; }
        public static PlayerEntity Player { get { return GameManager.Instance.PlayerEntity; } }
        public static PlayerActivateModes CurrentMode { get { return GameManager.Instance.PlayerActivate.CurrentMode; } }

        // Mod Textures || GUI
        public Texture2D GrabModeChoiceMenuTexture;

        // Will likely move these later to another partial class "formula helper"
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

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<KleptomaniaMain>(); // Add script to the scene.

            mod.LoadSettingsCallback = LoadSettings; // To enable use of the "live settings changes" feature in-game.

            mod.IsReady = true;
        }

        private void Start()
        {
            Debug.Log("Begin mod init: Kleptomania");

            Instance = this;

            mod.SaveDataInterface = ModSaveData;

            mod.LoadSettings();

            if (TogglePotionsGlassBottles)
            {
                Debug.Log("Kleptomania: Registering Potions/Glass-Bottle Custom Activators");
                // Small Potions Glasses:
                RegisterActivationsWithinRange(205, 11, 16, DoNothingActivation);
                RegisterActivationsWithinRange(205, 31, 35, DoNothingActivation);
                RegisterActivationsWithinRange(205, 43, 43, DoNothingActivation);
                RegisterActivationsWithinRange(208, 2, 2, DoNothingActivation);
                RegisterActivationsWithinRange(253, 4, 6, DoNothingActivation);
                RegisterActivationsWithinRange(253, 25, 27, DoNothingActivation);

                // Large Potions Glasses:
                RegisterActivationsWithinRange(205, 1, 7, DoNothingActivation);
                RegisterActivationsWithinRange(253, 40, 48, DoNothingActivation);
            }

            if (TogglePaperNotes)
            {
                Debug.Log("Kleptomania: Registering Paper/Notes Custom Activators");
                // Paper, Parchment, Scrolls:
                RegisterActivationsWithinRange(209, 5, 8, DoNothingActivation);
                RegisterActivationsWithinRange(209, 10, 10, DoNothingActivation);
                RegisterActivationsWithinRange(253, 53, 56, DoNothingActivation);
                RegisterActivationsWithinRange(253, 64, 64, DoNothingActivation);
                RegisterActivationsWithinRange(253, 74, 74, DoNothingActivation);
                RegisterActivationsWithinRange(253, 80, 80, DoNothingActivation);
            }

            if (ToggleBooks)
            {
                Debug.Log("Kleptomania: Registering Book Custom Activators");
                // Books & Multiple Books, Skill-books:
                RegisterActivationsWithinRange(209, 0, 4, DoNothingActivation);
                RegisterActivationsWithinRange(216, 40, 40, DoNothingActivation);
                RegisterActivationsWithinRange(216, 40, 40, DoNothingActivation);
                RegisterActivationsWithinRange(253, 7, 9, DoNothingActivation);
                RegisterActivationsWithinRange(253, 57, 58, DoNothingActivation);
            }

            if (ToggleWeapons)
            {
                Debug.Log("Kleptomania: Registering Weapon Custom Activators");
                // Longswords:
                RegisterActivationsWithinRange(207, 0, 2, DoNothingActivation);
                RegisterActivationsWithinRange(207, 15, 15, DoNothingActivation);
                RegisterActivationsWithinRange(211, 12, 12, DoNothingActivation);

                // Shortswords:
                RegisterActivationsWithinRange(207, 3, 3, DoNothingActivation);
                RegisterActivationsWithinRange(207, 5, 5, DoNothingActivation);

                // 1H Axe:
                RegisterActivationsWithinRange(207, 4, 4, DoNothingActivation);

                // 1H Mace/Club:
                RegisterActivationsWithinRange(207, 6, 6, DoNothingActivation);

                // Staff or Wand:
                RegisterActivationsWithinRange(207, 7, 7, DoNothingActivation);

                // Bows:
                RegisterActivationsWithinRange(207, 8, 8, DoNothingActivation);

                // Arrows or Multiple Arrows in a Quiver:
                RegisterActivationsWithinRange(205, 42, 42, DoNothingActivation);
                RegisterActivationsWithinRange(207, 16, 16, DoNothingActivation);
            }

            if (ToggleArmor)
            {
                Debug.Log("Kleptomania: Registering Armor Custom Activators");
                // Shields:
                RegisterActivationsWithinRange(207, 9, 10, DoNothingActivation);

                // Cuirass/Chest-piece:
                RegisterActivationsWithinRange(207, 11, 11, DoNothingActivation);

                // Helmets:
                RegisterActivationsWithinRange(207, 12, 12, DoNothingActivation);
                RegisterActivationsWithinRange(207, 14, 14, DoNothingActivation);
            }

            if (ToggleClothing)
            {
                Debug.Log("Kleptomania: Registering Clothing Custom Activators");
                // Random Clothing Item:
                RegisterActivationsWithinRange(204, 0, 0, DoNothingActivation);
                RegisterActivationsWithinRange(253, 16, 16, DoNothingActivation);

                // Shoes/Boots Clothing Item:
                RegisterActivationsWithinRange(204, 1, 2, DoNothingActivation);

                // Clothing Hat Headware Item:
                RegisterActivationsWithinRange(204, 3, 5, DoNothingActivation);

                // Straps Clothing Item or Cloth Amulet:
                RegisterActivationsWithinRange(204, 9, 9, DoNothingActivation);
            }

            if (ToggleBandages)
            {
                Debug.Log("Kleptomania: Registering Bandage Custom Activators");
                // Bandages:
                RegisterActivationsWithinRange(211, 0, 0, DoNothingActivation);
                RegisterActivationsWithinRange(253, 2, 2, DoNothingActivation);
            }

            if (ToggleJewelry)
            {
                Debug.Log("Kleptomania: Registering Jewelry Custom Activators");
                // Jewelry Bracer:
                RegisterActivationsWithinRange(207, 13, 13, DoNothingActivation);

                // Jewelry Mark Item:
                RegisterActivationsWithinRange(209, 9, 9, DoNothingActivation);

                // Jewelry Torc:
                RegisterActivationsWithinRange(211, 48, 48, DoNothingActivation);

                // Jewelry Bracelet:
                RegisterActivationsWithinRange(216, 21, 21, DoNothingActivation);

                // Crowns:
                RegisterActivationsWithinRange(216, 6, 7, DoNothingActivation);

                // Tiaras:
                RegisterActivationsWithinRange(216, 8, 9, DoNothingActivation);

                // Gemstones:
                RegisterActivationsWithinRange(216, 10, 19, DoNothingActivation);

                // Gold Bar:
                RegisterActivationsWithinRange(216, 3, 3, DoNothingActivation);
            }

            if (ToggleReligiousObjects)
            {
                Debug.Log("Kleptomania: Registering Religious Objects Custom Activators");
                // Small Religious Items:
                RegisterActivationsWithinRange(211, 49, 53, DoNothingActivation);
            }

            if (ToggleValuableDecorations)
            {
                Debug.Log("Kleptomania: Registering Valuable Decorations Custom Activators");
                // Goblets/Cups:
                RegisterActivationsWithinRange(200, 0, 6, DoNothingActivation);
                RegisterActivationsWithinRange(253, 30, 35, DoNothingActivation);

                // Candelabra:
                RegisterActivationsWithinRange(210, 5, 5, DoNothingActivation);
                RegisterActivationsWithinRange(253, 19, 19, DoNothingActivation);

                // Painting:
                RegisterActivationsWithinRange(211, 57, 57, DoNothingActivation);
            }

            if (ToggleExoticTools)
            {
                Debug.Log("Kleptomania: Registering Exotic Tools Custom Activators");
                // Globe:
                RegisterActivationsWithinRange(208, 0, 0, DoNothingActivation);
                RegisterActivationsWithinRange(253, 28, 28, DoNothingActivation);

                // Telescope Spy-glass:
                RegisterActivationsWithinRange(208, 4, 4, DoNothingActivation);

                // Weight Scales:
                RegisterActivationsWithinRange(208, 3, 3, DoNothingActivation);

                // Hour-glass:
                RegisterActivationsWithinRange(208, 6, 6, DoNothingActivation);

                // Magnifying Glass:
                RegisterActivationsWithinRange(208, 1, 1, DoNothingActivation);
                RegisterActivationsWithinRange(253, 54, 54, DoNothingActivation);

                // Hand-Mirror:
                RegisterActivationsWithinRange(208, 5, 5, DoNothingActivation);

                // Ink-well:
                RegisterActivationsWithinRange(211, 1, 1, DoNothingActivation);
                RegisterActivationsWithinRange(253, 39, 39, DoNothingActivation);

                // Tiny Bell:
                RegisterActivationsWithinRange(211, 47, 47, DoNothingActivation);

                // Smoking Pipes:
                RegisterActivationsWithinRange(211, 24, 25, DoNothingActivation);
            }

            if (ToggleJugsPots)
            {
                Debug.Log("Kleptomania: Registering Jugs/Pots Custom Activators");
                // Jugs, Jars, Pots:
                RegisterActivationsWithinRange(205, 41, 41, DoNothingActivation);
                RegisterActivationsWithinRange(211, 2, 2, DoNothingActivation);
                RegisterActivationsWithinRange(213, 6, 6, DoNothingActivation);
                RegisterActivationsWithinRange(218, 0, 3, DoNothingActivation);
                RegisterActivationsWithinRange(253, 85, 85, DoNothingActivation);
            }

            if (ToggleLaborTools)
            {
                Debug.Log("Kleptomania: Registering Labor Tools Custom Activators");
                // Wagon Wheels:
                RegisterActivationsWithinRange(211, 15, 17, DoNothingActivation);

                // Various Labor Tools:
                RegisterActivationsWithinRange(214, 0, 15, DoNothingActivation);
                RegisterActivationsWithinRange(218, 6, 6, DoNothingActivation);
            }

            if (ToggleFoodAndCooking)
            {
                Debug.Log("Kleptomania: Registering Food/Cooking Custom Activators");
                // Frying-pan or Skillet:
                RegisterActivationsWithinRange(218, 4, 4, DoNothingActivation);

                // Fish & Fish Containers:
                RegisterActivationsWithinRange(205, 10, 10, DoNothingActivation);
                RegisterActivationsWithinRange(211, 8, 11, DoNothingActivation);
                RegisterActivationsWithinRange(253, 23, 24, DoNothingActivation);

                // Ration Sacks:
                RegisterActivationsWithinRange(205, 17, 20, DoNothingActivation);
                RegisterActivationsWithinRange(253, 70, 73, DoNothingActivation);

                // Bread Loaf:
                RegisterActivationsWithinRange(211, 31, 31, DoNothingActivation);

                // Haunch of Meat:
                RegisterActivationsWithinRange(211, 40, 40, DoNothingActivation);

                // Orange:
                RegisterActivationsWithinRange(213, 0, 0, DoNothingActivation);
                RegisterActivationsWithinRange(253, 55, 55, DoNothingActivation);

                // Apple:
                RegisterActivationsWithinRange(213, 1, 1, DoNothingActivation);
                RegisterActivationsWithinRange(253, 0, 0, DoNothingActivation);
            }

            if (ToggleAlchemyIngredients)
            {
                Debug.Log("Kleptomania: Registering Alchemy Ingredients Custom Activators");
                // Teeth or Fangs:
                RegisterActivationsWithinRange(211, 41, 42, DoNothingActivation);

                // Various Ingredients:
                RegisterActivationsWithinRange(254, 0, 71, DoNothingActivation);
            }

            // Load Resources
            LoadTextures();
            //LoadAudio();

            Debug.Log("Finished mod init: Kleptomania");
        }

        private void RegisterActivationsWithinRange(int archive, int start, int end, DaggerfallWorkshop.Game.PlayerActivate.CustomActivation method)
        {
            if (start > end)
                return;

            for (int i = start; i <= end; i++) // Make sure the loop condition value is the right amount to not go over the desired range.
            {
                PlayerActivate.RegisterCustomActivation(mod, archive, i, method);
                Debug.LogFormat("Custom Activation Registered For: Archive:{0}, Record:{1}", archive, i);
            }
        }

        static void LoadSettings(ModSettings modSettings, ModSettingsChange change)
        {
            TogglePotionsGlassBottles = mod.GetSettings().GetValue<bool>("ToggleInteractables", "PotionsPoisonsAlcoholGlass-Bottles");
            TogglePaperNotes = mod.GetSettings().GetValue<bool>("ToggleInteractables", "PaperParchmentScrollsNotes");
            ToggleBooks = mod.GetSettings().GetValue<bool>("ToggleInteractables", "BooksSkill-Books");
            ToggleWeapons = mod.GetSettings().GetValue<bool>("ToggleInteractables", "Weapons");
            ToggleArmor = mod.GetSettings().GetValue<bool>("ToggleInteractables", "Armor");
            ToggleClothing = mod.GetSettings().GetValue<bool>("ToggleInteractables", "Clothing");
            ToggleBandages = mod.GetSettings().GetValue<bool>("ToggleInteractables", "Bandages");
            ToggleJewelry = mod.GetSettings().GetValue<bool>("ToggleInteractables", "Jewelry");
            ToggleReligiousObjects = mod.GetSettings().GetValue<bool>("ToggleInteractables", "ReligiousObjects");
            ToggleValuableDecorations = mod.GetSettings().GetValue<bool>("ToggleInteractables", "ValuableDecorations");
            ToggleExoticTools = mod.GetSettings().GetValue<bool>("ToggleInteractables", "ExoticTools");
            ToggleJugsPots = mod.GetSettings().GetValue<bool>("ToggleInteractables", "JugsJarsPots");
            ToggleLaborTools = mod.GetSettings().GetValue<bool>("ToggleInteractables", "LaborTools");
            ToggleFoodAndCooking = mod.GetSettings().GetValue<bool>("ToggleInteractables", "Food&Cooking");
            ToggleAlchemyIngredients = mod.GetSettings().GetValue<bool>("ToggleInteractables", "AlchemyIngredients");
        }

        private void LoadTextures() // Example taken from Penwick Papers Mod
        {
            ModManager modManager = ModManager.Instance;
            bool success = true;

            success &= modManager.TryGetAsset("Grab-Mode_Choice_Menu", false, out GrabModeChoiceMenuTexture);

            if (!success)
                throw new Exception("Kleptomania: Missing texture asset");
        }

        private static bool BasicChecks(RaycastHit hit)
        {
            ClickedObjRef = hit.collider.gameObject; // Sets clicked object as global variable reference for later use.
            ObjTexArchive = -1;
            ObjTexRecord = -1;

            // Oh yeah, don't forget to eventually exclude all of these if currently inside a player-owned ship/building.

            // Ignore any objects that have "DaggerfallAction" or "QuestResourceBehavior" attached to them. Will need to test to make sure this actually works as I intend.
            if (ClickedObjRef.GetComponent<DaggerfallAction>()) { return false; }

            if (ClickedObjRef.GetComponent<QuestResourceBehaviour>()) { return false; }

            if (ClickedObjRef.GetComponent<DaggerfallLoot>()) { return false; }

            if (hit.distance > PlayerActivate.DefaultActivationDistance)
            {
                DaggerfallUI.SetMidScreenText(TextManager.Instance.GetLocalizedText("youAreTooFarAway")); // Will have to see with testing if I should have this pop-up or not.
                return false;
            }

            DaggerfallBillboard billBoard = ClickedObjRef.GetComponent<DaggerfallBillboard>(); // Will have to test and eventually account for mods like "Handpainted Models" etc.
            if (billBoard != null)
            {
                ObjTexArchive = billBoard.Summary.Archive;
                ObjTexRecord = billBoard.Summary.Record;
            }
            return true;
        }

        private static void DoNothingActivation(RaycastHit hit)
        {
            if (!BasicChecks(hit)) { ClickedObjRef = null; return; }

            if (ClickedObjRef == null || ObjTexArchive == -1 || ObjTexRecord == -1) { return; } // Put error/debug text here as well so I know when/if this occurs.

            if (CurrentMode == PlayerActivateModes.Grab) // Method for grab mode.
            {
                GrabModeChoiceWindow grabModeWindow = new GrabModeChoiceWindow(DaggerfallUI.UIManager, ClickedObjRef);
                DaggerfallUI.UIManager.PushWindow(grabModeWindow);
            }
            else if (CurrentMode == PlayerActivateModes.Steal) {TakeOrStealItem(ClickedObjRef);} // Method for steal mode.
            else {ShowNameOrDescription();} // For now, assuming Info or Talk mode. This will be Method to show item name or description, if there is one.

            ClickedObjRef = null;
        }

        public static void TakeOrStealItem(GameObject clickedObj)
        {
            DaggerfallUnityItem item = null;
            IsThisACrime();

            switch (ObjTexArchive)
            {
                case 205:
                    if (IsPotionBottleTextureGroups())
                    {
                        item = ItemBuilder.CreateRandomPotion();
                        if (DoesThisEncumberPlayer(item))
                        {
                            DaggerfallLoot droppedItem = GameObjectHelper.CreateDroppedLootContainer(GameManager.Instance.PlayerObject, DaggerfallUnity.NextUID, 216, 31);
                            droppedItem.Items.AddItem(item);
                            DaggerfallUI.AddHUDText("Unable to carry anymore, you drop the item on the ground...", 3f);
                        }
                        else
                        {
                            Player.Items.AddItem(item);
                            // Play audio-clip that sounds like picking up a bottle/potion, probably something from Oblivion.
                        }
                    }
                    else if (ObjTexRecord == 42) {}
                    else if (ObjTexRecord == 41) {}
                    else if (ObjTexRecord == 10) {}
                    else if (ObjTexRecord >= 17 && ObjTexRecord <= 20) {}
                    else {}
                    break;
                default:
                    break;
            }
            clickedObj.SetActive(false);
            // Here likely disable or delete the flat/object that was clicked and stolen in this case. Will have to deal with saving/loading related stuff later.
        }

        public static bool IsPotionBottleTextureGroups()
        {
            return (ObjTexRecord >= 1 && ObjTexRecord <= 7) || (ObjTexRecord >= 11 && ObjTexRecord <= 16) || (ObjTexRecord >= 31 && ObjTexRecord <= 35) || ObjTexRecord == 43;
        }

        public static bool DoesThisEncumberPlayer(DaggerfallUnityItem item)
        {
            if (item == null) { return false; }
            return (Player.CarriedWeight + item.weightInKg) > Player.MaxEncumbrance;
        }

        public static void IsThisACrime()
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

        public static void ShowNameOrDescription()
        {
            DaggerfallUI.AddHUDText(GetItemNameOrDescription(), 2f);
        }

        public static string GetItemNameOrDescription()
        {
            string hudText = "";

            switch (ObjTexArchive)
            {
                case 205:
                    if (IsPotionBottleTextureGroups())
                    {
                        hudText = "You see a glass bottle filled with an unknown liquid."; break; // Will likely change these later to better describe the individual sprite graphic used, will see.
                    }
                    else if (ObjTexRecord == 42) {}
                    else if (ObjTexRecord == 41) {}
                    else if (ObjTexRecord == 10) {}
                    else if (ObjTexRecord >= 17 && ObjTexRecord <= 20) {}
                    else {}
                    break;
                default:
                    break;
            }
            return hudText;
        }
    }
}
