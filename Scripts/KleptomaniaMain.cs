// Project:         Kleptomania mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2023 Kirk.O
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Kirk.O
// Created On: 	    4/29/2023, 11:20 PM
// Last Edit:		5/2/2023, 11:50 PM
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

        public static int RequiredRecoveryHours { get; set; }
        public static float FinalTrainingCostMultiplier { get; set; }

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

            // Goblets/Cups:
            RegisterActivationsWithinRange(200, 0, 6, DoNothingActivation);
            RegisterActivationsWithinRange(253, 30, 35, DoNothingActivation);

            // Random Clothing Item:
            // Continue from here tomorrow.

            PlayerActivate.RegisterCustomActivation(mod, 4734, 0, DoNothingActivation); // Sprites
            PlayerActivate.RegisterCustomActivation(mod, 41811, DoNothingActivation); // Models

            Debug.Log("Finished mod init: Kleptomania");
        }

        private void RegisterActivationsWithinRange(int archive, int start, int end, DaggerfallWorkshop.Game.PlayerActivate.CustomActivation method)
        {
            if (start > end)
                return;

            for (int i = start; i < end; i++) // Make sure the loop condition value is the right amount to not go over the desired range.
            {
                PlayerActivate.RegisterCustomActivation(mod, archive, i, method);
                Debug.LogFormat("Custom Activation Registered For: Archive:{0}, Record:{1}", archive, i);
            }
        }

        static void LoadSettings(ModSettings modSettings, ModSettingsChange change)
        {
            RequiredRecoveryHours = mod.GetSettings().GetValue<int>("TimeRelated", "HoursNeededBetweenSessions");
            FinalTrainingCostMultiplier = mod.GetSettings().GetValue<float>("GoldCost", "FinalCostMultiplier");
        }

        private static void DoNothingActivation(RaycastHit hit)
        {
            // Will be filled with useful stuff later.
        }
    }
}
