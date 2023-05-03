// Project:         Kleptomania mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2023 Kirk.O
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Kirk.O
// Created On: 	    4/29/2023, 11:20 PM
// Last Edit:		5/3/2023, 6:40 PM
// Version:			1.00
// Special Thanks:  
// Modifier:

using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Game.Utility.ModSupport.ModSettings;

namespace Kleptomania
{
    public class KleptomaniaMain : MonoBehaviour
    {
        public static KleptomaniaMain Instance;

        static Mod mod;

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

        private static void DoNothingActivation(RaycastHit hit)
        {
            // Will be filled with useful stuff later.
        }
    }
}