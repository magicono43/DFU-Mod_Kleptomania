// Project:         Kleptomania mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2023 Kirk.O
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Kirk.O
// Created On: 	    4/29/2023, 11:20 PM
// Last Edit:		5/9/2023, 10:30 PM
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
        public static int PlayerLayerMask { get; set; }
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

            go.AddComponent<KleptomaniaStolenMarker>();

            mod.LoadSettingsCallback = LoadSettings; // To enable use of the "live settings changes" feature in-game.

            mod.IsReady = true;
        }

        private void Start()
        {
            Debug.Log("Begin mod init: Kleptomania");

            Instance = this;

            mod.SaveDataInterface = ModSaveData;

            mod.LoadSettings();

            PlayerLayerMask = ~(1 << LayerMask.NameToLayer("Player"));

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

                // Small Pouch/Sack
                RegisterActivationsWithinRange(205, 36, 36, DoNothingActivation);
                RegisterActivationsWithinRange(205, 44, 44, DoNothingActivation);
                RegisterActivationsWithinRange(216, 30, 30, DoNothingActivation);
                RegisterActivationsWithinRange(253, 1, 1, DoNothingActivation);
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

                // Inkwell:
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
                RegisterActivationsWithinRange(253, 63, 63, DoNothingActivation);
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
            string text = "";
            IsThisACrime();
            GameObject marker = CreateStolenObjectMarker(clickedObj.transform.position, clickedObj.transform.parent);
            DaggerfallAudioSource dfAudioSource = marker.GetComponent<DaggerfallAudioSource>();

            switch (ObjTexArchive)
            {
                case 200:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 6) { DetermineGobletCupType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 30); }
                    else { return; }
                    break;
                case 204:
                    if (ObjTexRecord == 0) {} // Add a random piece(s) of clothing
                    else if (ObjTexRecord >= 1 && ObjTexRecord <= 2) {} // add a random pare of footware clothing.
                    else if (ObjTexRecord >= 3 && ObjTexRecord <= 5) {} // add a random piece of headware clothing (might not exist still)
                    else if (ObjTexRecord == 9) {} // add a random piece of straps clothing item.
                    else { return; }
                    break;
                case 205:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.MakePotion, SoundClips.SplashSmall, 205, 11); }
                    else if (ObjTexRecord == 42)
                    {
                        item = ItemBuilder.CreateWeapon(Weapons.Arrow, WeaponMaterialTypes.Steel);
                        item.stackCount = UnityEngine.Random.Range(3, 14);
                        GeneralItemTakingProcess(item, dfAudioSource, SoundClips.ArrowHit, SoundClips.BodyFall, 207, 16, true);
                    }
                    else if (ObjTexRecord == 41) { DeterminePotUrnJugType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else if (ObjTexRecord == 10) { DetermineFishBundleType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipStaff, SoundClips.SplashSmall, 211, 9); }
                    else if (ObjTexRecord >= 17 && ObjTexRecord <= 20) {} // Will likely add a ration food-item from climates & calories mod if that is currently installed, later.
                    else { return; }
                    break;
                case 207:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 2) {} // add a one-handed "long-sword" of some random (possibly limited) material value.
                    else if (ObjTexRecord == 3 || ObjTexRecord == 5) {} // add a "short-sword" of some random (possibly limited) material value.
                    else if (ObjTexRecord == 4) {} // add a one-handed axe of some random material value.
                    else if (ObjTexRecord == 6) {} // add a mace or club of some random material value.
                    else if (ObjTexRecord == 7) {} // add a staff (or maybe also wand) of some random material value.
                    else if (ObjTexRecord == 8) {} // add a short or long-bow of some random material value.
                    else if (ObjTexRecord == 9) {} // add a tower-shield of some random material value.
                    else if (ObjTexRecord == 10) {} // add a random buckler, round-shield, or kite-shield of some random material value.
                    else if (ObjTexRecord == 11) {} // add a random piece of chest-armor of some random material, include RPR:I stuff as well if active.
                    else if (ObjTexRecord == 12 || ObjTexRecord == 14) {} // add a random piece of head-armor of some random material, include RPR:I stuff as well if active.
                    else if (ObjTexRecord == 13) {} // add a bracer jewelry item.
                    else if (ObjTexRecord == 15) {} // add a two-handed sword of some random (possibly limited) material value.
                    else if (ObjTexRecord == 16)
                    {
                        item = ItemBuilder.CreateWeapon(Weapons.Arrow, WeaponMaterialTypes.Steel);
                        GeneralItemTakingProcess(item, dfAudioSource, SoundClips.ArrowHit, SoundClips.BodyFall, 207, 16, true);
                    }
                    else { return; }
                    break;
                case 208:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.MakePotion, SoundClips.SplashSmall, 205, 11); }
                    else if (ObjTexRecord == 0) {} // custom globe item, will probably be pretty heavy.
                    else if (ObjTexRecord == 1) {} // custom magnifying glass item.
                    else if (ObjTexRecord == 3) {} // custom weight scale item, will probably weight a moderate amount.
                    else if (ObjTexRecord == 4) {} // custom telescope item, maybe add that "spy-glass" item from that old mod or something if installed, will see.
                    else if (ObjTexRecord == 5) {} // custom hand mirror item.
                    else if (ObjTexRecord == 6) {} // custom hourglass item.
                    else { return; }
                    break;
                case 209:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.OpenBook, SoundClips.BodyFall, 209, 3); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.OpenBook, SoundClips.BodyFall, 209, 8); }
                    else if (ObjTexRecord == 9) {} // Add jewelry mark item.
                    else { return; }
                    break;
                case 210:
                    if (ObjTexRecord == 5) {} // Add a moderately valuable candelabra custom item.
                    else { return; }
                    break;
                case 211:
                    if (ObjTexRecord == 0) {} // bandage item
                    else if (ObjTexRecord == 1) {} // custom inkwell item
                    else if (ObjTexRecord == 2) { DeterminePotUrnJugType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 11) { DetermineFishBundleType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipStaff, SoundClips.SplashSmall, 211, 9); }
                    else if (ObjTexRecord == 12) {} // Maybe add 3 low value long-swords
                    else if (ObjTexRecord >= 15 && ObjTexRecord <= 17) {} // add a wagon wheel item from realistic wagons mod if active.
                    else if (ObjTexRecord >= 24 && ObjTexRecord <= 25) {} // add a custom smoking pipe item.
                    else if (ObjTexRecord == 31) {} // add a bread item from C&C
                    else if (ObjTexRecord == 40) {} // add a piece of meat item from C&C
                    else if (ObjTexRecord >= 41 && ObjTexRecord <= 42) {} // add a random small, medium, or large animal fang ingredient.
                    else if (ObjTexRecord == 47) {} // add a small bell item
                    else if (ObjTexRecord == 48) {} // add a torc jewelry item.
                    else if (ObjTexRecord == 49) {} // add a holy water item.
                    else if (ObjTexRecord == 50) {} // add a talisman or whatever those types of "junk" items are.
                    else if (ObjTexRecord == 51 || ObjTexRecord == 53) {} // add an "icon" item.
                    else if (ObjTexRecord == 52) {} // add a scarab item.
                    else if (ObjTexRecord == 57) {} // add a randomly generated painting.
                    else { return; }
                    break;
                case 213:
                    if (ObjTexRecord == 0) {} // Apple from C&C
                    else if (ObjTexRecord == 1) {} // Orange from C&C
                    else if (ObjTexRecord == 6) { DeterminePotUrnJugType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else { return; }
                    break;
                case 214:
                    if (ObjTexRecord == 0 || ObjTexRecord == 4 || ObjTexRecord == 11) {} // add a wooden scoop custom item.
                    else if (ObjTexRecord == 1) {} // add a shovel custom item.
                    else if (ObjTexRecord >= 2 && ObjTexRecord <= 3) {} // add a armorers hammer item from Repair Tools if active.
                    else if (ObjTexRecord == 5) {} // add a butter churn custom item, that or use the churn and make butter or something.
                    else if (ObjTexRecord == 6) {} // add a pickaxe custom item
                    else if (ObjTexRecord == 7) {} // add a scythe custom item.
                    else if (ObjTexRecord == 8) {} // add a rope custom item.
                    else if (ObjTexRecord == 9) {} // add a bellows custom item.
                    else if (ObjTexRecord == 10) {} // add a broom custom item.
                    else if (ObjTexRecord == 12) {} // add a brush custom item.
                    else if (ObjTexRecord == 13) {} // add a tongs custom item.
                    else if (ObjTexRecord == 14) {} // add a shears custom item.
                    else if (ObjTexRecord == 15) {} // add a trowel custom item.
                    else { return; }
                    break;
                case 216:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.OpenBook, SoundClips.BodyFall, 209, 3); }
                    else if (ObjTexRecord == 3) {} // possibly custom item that gives much more value and weight to this "solid gold bar" instead of the vanilla ingredient form.
                    else if (ObjTexRecord >= 6 && ObjTexRecord <= 7) { DetermineCrownPieceType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 6); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 9) { DetermineTiaraPieceType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 9); }
                    else if (ObjTexRecord >= 10 && ObjTexRecord <= 19) { DetermineGemStonePieceType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 10); }
                    else if (ObjTexRecord == 21) {} // Add jewelry bracelet item, may change as well if Jewelry Additions is active.
                    else if (ObjTexRecord == 30) {} // Will likely just hold a random small amount of gold, or later something more random based on the context and such, will see.
                    else { return; }
                    break;
                case 218:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 3) { DeterminePotUrnJugType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else if (ObjTexRecord == 4) {} // add "skillet" item from C&C
                    else if (ObjTexRecord == 6) {} // add a custom "spoon" or scoop item.
                    else { return; }
                    break;
                case 253:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.MakePotion, SoundClips.SplashSmall, 205, 11); }
                    else if (IsBookTextureGroups()) { DetermineBookBundleType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.OpenBook, SoundClips.BodyFall, 209, 3); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.OpenBook, SoundClips.BodyFall, 209, 8); }
                    else if (ObjTexRecord == 0) {} // Apple from C&C
                    else if (ObjTexRecord == 1) {} // Will likely just hold a random small amount of gold, or later something more random based on the context and such, will see.
                    else if (ObjTexRecord == 2) {} // Bandage item
                    else if (ObjTexRecord == 16) {} // Add a random piece(s) of clothing
                    else if (ObjTexRecord == 19) {} // Add a moderately valuable candelabra custom item.
                    else if (ObjTexRecord == 23 || ObjTexRecord == 24) { DetermineFishBundleType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipStaff, SoundClips.SplashSmall, 211, 9); }
                    else if (ObjTexRecord == 28) {} // custom globe item, will probably be pretty heavy.
                    else if (ObjTexRecord >= 30 && ObjTexRecord <= 35) { DetermineGobletCupType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 30); }
                    else if (ObjTexRecord == 39) {} // custom inkwell item.
                    else if (ObjTexRecord == 54) {} // custom magnifying glass item.
                    else if (ObjTexRecord == 55) {} // Orange from C&C
                    else if (ObjTexRecord >= 70 && ObjTexRecord <= 73) {} // Will likely add a ration food-item from climates & calories mod if that is currently installed, later.
                    else if (ObjTexRecord == 63 || ObjTexRecord == 85) { DeterminePotUrnJugType(out item, out text); GeneralItemTakingProcess(item, dfAudioSource, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else { return; }
                    break;
                case 254:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 71) {} // add whatever appropriate alchemical ingredient iten.
                    else { return; }
                    break;
                default:
                    return;
            }
            clickedObj.SetActive(false);
        }

        public static void GeneralItemTakingProcess(DaggerfallUnityItem item, DaggerfallAudioSource dfAudioSource, SoundClips takeSound = SoundClips.EquipJewellery, SoundClips dropSound = SoundClips.BodyFall, int lootPileArc = -1, int lootPileRec = -1, bool noWeight = false)
        {
            if (!noWeight && DoesThisEncumberPlayer(item))
            {
                DaggerfallLoot droppedItem = GameObjectHelper.CreateDroppedLootContainer(GameManager.Instance.PlayerObject, DaggerfallUnity.NextUID, lootPileArc == -1 ? 216 : lootPileArc, lootPileRec == -1 ? -1 : lootPileRec);
                droppedItem.Items.AddItem(item);
                if (dfAudioSource != null) { dfAudioSource.PlayOneShot(dropSound); }
                DaggerfallUI.AddHUDText("Unable to carry anymore, you drop the item on the ground...", 3f);
            }
            else
            {
                Player.Items.AddItem(item);
                if (dfAudioSource != null) { dfAudioSource.PlayOneShot(takeSound); }
            }
        }

        public static void ShowNameOrDescription()
        {
            DaggerfallUI.AddHUDText(GetItemNameOrDescription(), 2f);
        }

        public static void DetermineGobletCupType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 200)
            {
                if (ObjTexRecord == 0 || ObjTexRecord == 2) { item = null; desc = "You see a silver goblet."; }
                else if (ObjTexRecord == 1 || ObjTexRecord == 3) { item = null; desc = "You see a gold goblet."; }
                else if (ObjTexRecord == 4) { item = null; desc = "You see a gem studded silver goblet."; }
                else if (ObjTexRecord == 5) { item = null; desc = "You see a gem studded gold goblet."; }
                else if (ObjTexRecord == 6) { item = null; desc = "You see a wooden cup."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 30 || ObjTexRecord == 32) { item = null; desc = "You see a silver goblet."; }
                else if (ObjTexRecord == 31 || ObjTexRecord == 33) { item = null; desc = "You see a gold goblet."; }
                else if (ObjTexRecord == 34) { item = null; desc = "You see a gem studded silver goblet."; }
                else if (ObjTexRecord == 35) { item = null; desc = "You see a gem studded gold goblet."; }
            }
        }

        public static void DeterminePotUrnJugType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 205)
            {
                if (ObjTexRecord == 41) { item = null; desc = "You see an urn."; }
            }
            else if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 2) { item = null; desc = "You see an urn."; }
            }
            else if (ObjTexArchive == 213)
            {
                if (ObjTexRecord == 6) { item = null; desc = "You see a blue pot with flowers in it."; }
            }
            else if (ObjTexArchive == 218)
            {
                if (ObjTexRecord == 0) { item = null; desc = "You see an engraved brown pot."; }
                else if (ObjTexRecord == 1) { item = null; desc = "You see a gray pot."; }
                else if (ObjTexRecord == 2) { item = null; desc = "You see a brown pot."; }
                else if (ObjTexRecord == 3) { item = null; desc = "You see a green pot."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 63) { item = null; desc = "You see an urn."; }
                else if (ObjTexRecord == 85) { item = null; desc = "You see a blue pot with flowers in it."; }
            }
        }

        public static void DetermineFishBundleType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 205)
            {
                if (ObjTexRecord == 10) { item = null; desc = "You see a basket full of prepared fish."; }
            }
            else if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 8) { item = null; desc = "You see a pile of raw fish."; }
                else if (ObjTexRecord == 9) { item = null; desc = "You see a fish."; }
                else if (ObjTexRecord == 10) { item = null; desc = "You see a cooked fish."; }
                else if (ObjTexRecord == 11) { item = null; desc = "You see a bundle of cooked fish."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 23) { item = null; desc = "You see a pile of raw fish."; }
                else if (ObjTexRecord == 24) { item = null; desc = "You see a fish."; }
            }
        }

        public static void DetermineBookBundleType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 209)
            {
                if (ObjTexRecord == 0) { item = null; desc = "You see a large stack of books."; }
                else if (ObjTexRecord == 1) { item = null; desc = "You see a small stack of books."; }
                else if (ObjTexRecord >= 2 && ObjTexRecord <= 4) { item = null; desc = "You see a book.";}
            }
            else if (ObjTexArchive == 216)
            {
                if (ObjTexRecord == 40) { item = null; desc = "You see a large stack of books."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord >= 7 && ObjTexRecord <= 9) { item = null; desc = "You see a book."; }
                else if (ObjTexRecord == 57) { item = null; desc = "You see a large stack of books."; }
                else if (ObjTexRecord == 58) { item = null; desc = "You see a small stack of books."; }
            }
        }

        public static void DeterminePaperScrollStackType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 209)
            {
                if (ObjTexRecord >= 5) { item = null; desc = "You see a piece of parchment.";}
                else if (ObjTexRecord == 6) { item = null; desc = "You see a stack of papers."; }
                else if (ObjTexRecord >= 7 && ObjTexRecord <= 8) { item = null; desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 10) { item = null; desc = "You see a stack of papers."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord >= 53) { item = null; desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 56) { item = null; desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 64) { item = null; desc = "You see a stack of papers."; }
                else if (ObjTexRecord == 74) { item = null; desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 80) { item = null; desc = "You see a stack of papers."; }
            }
        }

        public static void DetermineCrownPieceType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 216)
            {
                if (ObjTexRecord >= 6) { item = null; desc = "You see a gold crown."; }
                else if (ObjTexRecord == 7) { item = null; desc = "You see a silver crown."; }
            }
        }

        public static void DetermineTiaraPieceType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 216)
            {
                if (ObjTexRecord >= 8) { item = null; desc = "You see a silver tiara."; }
                else if (ObjTexRecord == 9) { item = null; desc = "You see a gold tiara."; }
            }
        }

        public static void DetermineGemStonePieceType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 216)
            {
                if (ObjTexRecord >= 10 && ObjTexRecord <= 17) { item = null; desc = "You see a gem."; }
                else if (ObjTexRecord >= 18 && ObjTexRecord <= 19) { item = null; desc = "You see a small stack of gems."; }
            }
        }

        public static void DetermineGlassBottlePotionType(out DaggerfallUnityItem item, out string desc, bool justText = false)
        {
            item = null;
            desc = "";
            if (ObjTexArchive == 205)
            {
                if (ObjTexRecord >= 1 && ObjTexRecord <= 7) { item = null; desc = "You see a large glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord >= 11 && ObjTexRecord <= 16) { item = null; desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 31) { item = null; desc = "You see a bunch of glass bottles filled with unknown liquids."; }
                else if (ObjTexRecord >= 32 && ObjTexRecord <= 35) { item = null; desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 43) { item = null; desc = "You see a small glass bottle filled with an unknown liquid."; }
            }
            else if (ObjTexArchive == 208)
            {
                if (ObjTexRecord == 2) { item = null; desc = "You see a glass bottle filled with an unknown liquid, being heated by a flame."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord >= 4 && ObjTexRecord <= 6) { item = null; desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord >= 25 && ObjTexRecord <= 27) { item = null; desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 40) { item = null; desc = "You see a large glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 41) { item = null; desc = "You see a glass bottle filled with an unknown liquid, being heated by a flame."; }
                else if (ObjTexRecord >= 42 && ObjTexRecord <= 47) { item = null; desc = "You see a large glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 48) { item = null; desc = "You see a glass bottle filled with an unknown liquid, being heated by a flame."; }
            }
        }

        public static string GetItemNameOrDescription()
        {
            DaggerfallUnityItem item = null;
            string text = "";

            switch (ObjTexArchive)
            {
                case 200:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 6) { DetermineGobletCupType(out item, out text, true); }
                    break;
                case 204:
                    if (ObjTexRecord == 0) { text = "You see a pile of clothing."; }
                    else if (ObjTexRecord >= 1 && ObjTexRecord <= 2) { text = "You see some footware."; }
                    else if (ObjTexRecord >= 3 && ObjTexRecord <= 5) { text = "You see a hat."; }
                    else if (ObjTexRecord == 9) { text = "You see some straps."; }
                    break;
                case 205:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out item, out text, true); }
                    else if (ObjTexRecord == 42) { text = "You see a quiver carrying a few arrows."; }
                    else if (ObjTexRecord == 41) { DeterminePotUrnJugType(out item, out text, true); }
                    else if (ObjTexRecord == 10) { DetermineFishBundleType(out item, out text, true); }
                    else if (ObjTexRecord >= 17 && ObjTexRecord <= 20) { text = "You see a sack."; }
                    break;
                case 207:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 2) { text = "You see a sword."; }
                    else if (ObjTexRecord == 3 || ObjTexRecord == 5) { text = "You see a small blade."; }
                    else if (ObjTexRecord == 4) { text = "You see an axe."; }
                    else if (ObjTexRecord == 6) { text = "You see a mace."; }
                    else if (ObjTexRecord == 7) { text = "You see a staff."; }
                    else if (ObjTexRecord == 8) { text = "You see a bow."; }
                    else if (ObjTexRecord == 9) { text = "You see a large shield."; }
                    else if (ObjTexRecord == 10) { text = "You see a shield."; }
                    else if (ObjTexRecord == 11) { text = "You see a piece of chest armor."; }
                    else if (ObjTexRecord == 12 || ObjTexRecord == 14) { text = "You see a helmet."; }
                    else if (ObjTexRecord == 13) { text = "You see a bracer."; }
                    else if (ObjTexRecord == 15) { text = "You see a large sword."; }
                    else if (ObjTexRecord == 16) { text = "You see an arrow."; }
                    break;
                case 208:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out item, out text, true); }
                    else if (ObjTexRecord == 0) { text = "You see a globe."; }
                    else if (ObjTexRecord == 1) { text = "You see a magnifying glass."; }
                    else if (ObjTexRecord == 3) { text = "You see a scale."; }
                    else if (ObjTexRecord == 4) { text = "You see a telescope."; }
                    else if (ObjTexRecord == 5) { text = "You see a hand mirror."; }
                    else if (ObjTexRecord == 6) { text = "You see an hourglass."; }
                    break;
                case 209:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out item, out text, true); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out item, out text, true); }
                    else if (ObjTexRecord == 9) { text = "You see a cloth mark."; }
                    break;
                case 210:
                    if (ObjTexRecord == 5) { text = "You see a candelabra."; }
                    break;
                case 211:
                    if (ObjTexRecord == 0) { text = "You see a bandage."; }
                    else if (ObjTexRecord == 1) { text = "You see an inkwell."; }
                    else if (ObjTexRecord == 2) { DeterminePotUrnJugType(out item, out text, true); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 11) { DetermineFishBundleType(out item, out text, true); }
                    else if (ObjTexRecord == 12) { text = "You see a stack of swords."; }
                    else if (ObjTexRecord >= 15 && ObjTexRecord <= 17) { text = "You see a wheel."; }
                    else if (ObjTexRecord >= 24 && ObjTexRecord <= 25) { text = "You see a smoking pipe."; }
                    else if (ObjTexRecord == 31) { text = "You see a loaf of bread."; }
                    else if (ObjTexRecord == 40) { text = "You see a piece of meat."; }
                    else if (ObjTexRecord >= 41 && ObjTexRecord <= 42) { text = "You see an animal tooth."; }
                    else if (ObjTexRecord == 47) { text = "You see a small bell."; }
                    else if (ObjTexRecord == 48) { text = "You see a torc."; }
                    else if (ObjTexRecord == 49) { text = "You see a cup of holy water."; }
                    else if (ObjTexRecord == 50) { text = "You see a talisman."; }
                    else if (ObjTexRecord == 51 || ObjTexRecord == 53) { text = "You see a religious icon."; }
                    else if (ObjTexRecord == 52) { text = "You see a scarab."; }
                    else if (ObjTexRecord == 57) { text = "You see a painting."; }
                    break;
                case 213:
                    if (ObjTexRecord == 0) { text = "You see an apple."; }
                    else if (ObjTexRecord == 1) { text = "You see an orange."; }
                    else if (ObjTexRecord == 6) { DeterminePotUrnJugType(out item, out text, true); }
                    break;
                case 214:
                    if (ObjTexRecord == 0 || ObjTexRecord == 4 || ObjTexRecord == 11) { text = "You see a wooden scoop."; }
                    else if (ObjTexRecord == 1) { text = "You see a shovel."; }
                    else if (ObjTexRecord >= 2 && ObjTexRecord <= 3) { text = "You see a hammer."; }
                    else if (ObjTexRecord == 5) { text = "You see a butter churn."; }
                    else if (ObjTexRecord == 6) { text = "You see a pickaxe."; }
                    else if (ObjTexRecord == 7) { text = "You see a scythe."; }
                    else if (ObjTexRecord == 8) { text = "You see a pile of rope."; }
                    else if (ObjTexRecord == 9) { text = "You see a bellows."; }
                    else if (ObjTexRecord == 10) { text = "You see a broom."; }
                    else if (ObjTexRecord == 12) { text = "You see a brush."; }
                    else if (ObjTexRecord == 13) { text = "You see a pair of tongs."; }
                    else if (ObjTexRecord == 14) { text = "You see a pair of shears."; }
                    else if (ObjTexRecord == 15) { text = "You see a wooden trowel."; }
                    break;
                case 216:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out item, out text, true); }
                    else if (ObjTexRecord == 3) { text = "You see a solid gold bar."; }
                    else if (ObjTexRecord >= 6 && ObjTexRecord <= 7) { DetermineCrownPieceType(out item, out text, true); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 9) { DetermineTiaraPieceType(out item, out text, true); }
                    else if (ObjTexRecord >= 10 && ObjTexRecord <= 19) { DetermineGemStonePieceType(out item, out text, true); }
                    else if (ObjTexRecord == 21) { text = "You see a bracelet."; }
                    else if (ObjTexRecord == 30) { text = "You see a small pouch."; }
                    break;
                case 218:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 3) { DeterminePotUrnJugType(out item, out text, true); }
                    else if (ObjTexRecord == 4) { text = "You see an iron skillet."; }
                    else if (ObjTexRecord == 6) { text = "You see a wooden spoon."; }
                    break;
                case 253:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out item, out text, true); }
                    else if (IsBookTextureGroups()) { DetermineBookBundleType(out item, out text, true); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out item, out text, true); }
                    else if (ObjTexRecord == 0) { text = "You see an apple."; }
                    else if (ObjTexRecord == 1) { text = "You see a small pouch."; }
                    else if (ObjTexRecord == 2) { text = "You see a bandage."; }
                    else if (ObjTexRecord == 16) { text = "You see a pile of clothing."; }
                    else if (ObjTexRecord == 19) { text = "You see a candelabra."; }
                    else if (ObjTexRecord == 23 || ObjTexRecord == 24) { DetermineFishBundleType(out item, out text, true); }
                    else if (ObjTexRecord == 28) { text = "You see a globe."; }
                    else if (ObjTexRecord >= 30 && ObjTexRecord <= 35) { DetermineGobletCupType(out item, out text, true); }
                    else if (ObjTexRecord == 39) { text = "You see an inkwell."; }
                    else if (ObjTexRecord == 54) { text = "You see a magnifying glass."; }
                    else if (ObjTexRecord == 55) { text = "You see an orange."; }
                    else if (ObjTexRecord >= 70 && ObjTexRecord <= 73) { text = "You see a sack."; }
                    else if (ObjTexRecord == 63 || ObjTexRecord == 85) { DeterminePotUrnJugType(out item, out text, true); }
                    break;
                case 254:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 71) { text = "You see an alchemical ingredient."; }
                    break;
                default:
                    break;
            }
            return text;
        }

        public static bool IsPotionBottleTextureGroups()
        {
            if (ObjTexArchive == 205) { return (ObjTexRecord >= 1 && ObjTexRecord <= 7) || (ObjTexRecord >= 11 && ObjTexRecord <= 16) || (ObjTexRecord >= 31 && ObjTexRecord <= 35) || ObjTexRecord == 43; }
            else if (ObjTexArchive == 208) { return ObjTexRecord == 2; }
            else if (ObjTexArchive == 253) { return (ObjTexRecord >= 4 && ObjTexRecord <= 6) || (ObjTexRecord >= 25 && ObjTexRecord <= 27) || (ObjTexRecord >= 40 && ObjTexRecord <= 48); }
            else { return false; }
        }

        public static bool IsBookTextureGroups()
        {
            if (ObjTexArchive == 209) { return (ObjTexRecord >= 0 && ObjTexRecord <= 4); }
            else if (ObjTexArchive == 216) { return ObjTexRecord == 40; }
            else if (ObjTexArchive == 253) { return (ObjTexRecord >= 7 && ObjTexRecord <= 9) || (ObjTexRecord >= 57 && ObjTexRecord <= 58); }
            else { return false; }
        }

        public static bool IsPaperTextureGroups()
        {
            if (ObjTexArchive == 209) { return (ObjTexRecord >= 5 && ObjTexRecord <= 8) || ObjTexRecord == 10; }
            else if (ObjTexArchive == 253) { return ObjTexRecord == 53 || ObjTexRecord == 56 || ObjTexRecord == 64 || ObjTexRecord == 74 || ObjTexRecord == 80; }
            else { return false; }
        }

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

        public static GameObject CreateStolenObjectMarker (Vector3 pos, Transform parent)
        {
            ulong loadID = DaggerfallUnity.NextUID;
            string markerName = "Kleptomania_Marker-" + loadID;
            GameObject go = new GameObject(markerName);
            if (parent) go.transform.parent = parent;
            go.transform.position = pos;

            KleptomaniaStolenMarker marker = go.AddComponent<KleptomaniaStolenMarker>();
            marker.LoadID = loadID;
            marker.TextureArchive = ObjTexArchive;
            marker.TextureRecord = ObjTexRecord;

            return go;
        }

        public static bool WithinMarginOfErrorPos(Vector3 value1, Vector3 value2, float xAcceptDif, float yAcceptDif, float zAcceptDif)
        {
            bool xEqual = Mathf.Abs(value1.x - value2.x) <= xAcceptDif;
            bool yEqual = Mathf.Abs(value1.y - value2.y) <= yAcceptDif;
            bool zEqual = Mathf.Abs(value1.z - value2.z) <= zAcceptDif;

            return xEqual && yEqual && zEqual;
        }
    }
}
