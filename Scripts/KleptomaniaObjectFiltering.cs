using UnityEngine;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Utility;
using System.Collections.Generic;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
        public static void TakeOrStealItem(GameObject clickedObj)
        {
            List<DaggerfallUnityItem> items = new List<DaggerfallUnityItem>();
            string text = "";

            if (clickedObj == null) { return; }

            switch (ObjTexArchive)
            {
                case 200:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 6) { DetermineGobletCupType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 30); }
                    else { return; }
                    break;
                case 204:
                    if (ObjTexRecord == 0) { DetermineClothingItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.EquipLeather, 204, 0); }
                    else if (ObjTexRecord >= 1 && ObjTexRecord <= 2) { DetermineClothingItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.EquipLeather, 204, 2); }
                    else if (ObjTexRecord >= 3 && ObjTexRecord <= 5) { DetermineClothingItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.EquipLeather, 204, 4); }
                    else if (ObjTexRecord == 9) { DetermineClothingItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.EquipLeather, 204, 9); }
                    else { return; }
                    break;
                case 205:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.MakePotion, SoundClips.SplashSmall, 205, 11); }
                    else if (ObjTexRecord == 42)
                    {
                        items.Add(ItemBuilder.CreateWeapon(Weapons.Arrow, WeaponMaterialTypes.Steel));
                        items[0].stackCount = UnityEngine.Random.Range(3, 14);
                        GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.BodyFall, 207, 16, true);
                    }
                    else if (ObjTexRecord == 41) { DeterminePotUrnJugType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else if (ObjTexRecord == 10) { DetermineFishBundleType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.SplashSmall, 211, 9); }
                    else if (ObjTexRecord >= 17 && ObjTexRecord <= 20) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 205, 17); }
                    else { return; }
                    break;
                case 207:
                    if (ObjTexRecord == 0 || ObjTexRecord == 2 || ObjTexRecord == 3) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLongBlade, SoundClips.Parry1, 207, 3); }
                    else if (ObjTexRecord == 1 || ObjTexRecord == 5) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipShortBlade, SoundClips.Parry1, 207, 5); }
                    else if (ObjTexRecord == 4) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipAxe, SoundClips.Parry1, 207, 4); }
                    else if (ObjTexRecord == 6) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipFlail, SoundClips.Parry1, 207, 6); }
                    else if (ObjTexRecord == 7) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.EquipBow, 207, 7); }
                    else if (ObjTexRecord == 8) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipBow, SoundClips.EquipBow, 207, 8); }
                    else if (ObjTexRecord == 9) { DetermineArmorItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 207, 9); }
                    else if (ObjTexRecord == 10) { DetermineArmorItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 207, 10); }
                    else if (ObjTexRecord == 11) { DetermineArmorItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 207, 11); }
                    else if (ObjTexRecord == 12 || ObjTexRecord == 14) { DetermineArmorItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 207, 14); }
                    else if (ObjTexRecord == 13) { DetermineJewelryItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 207, 13); }
                    else if (ObjTexRecord == 15) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipTwoHandedBlade, SoundClips.Parry1, 207, 15); }
                    else if (ObjTexRecord == 16)
                    {
                        items.Add(ItemBuilder.CreateWeapon(Weapons.Arrow, WeaponMaterialTypes.Steel));
                        GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.BodyFall, 207, 16, true);
                    }
                    else { return; }
                    break;
                case 208:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.MakePotion, SoundClips.SplashSmall, 205, 11); }
                    else if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 208, 0); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 208, 1); }
                    else if (ObjTexRecord == 3) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 208, 3); }
                    else if (ObjTexRecord == 4) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 208, 4); }
                    else if (ObjTexRecord == 5) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 208, 5); }
                    else if (ObjTexRecord == 6) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 208, 6); }
                    else { return; }
                    break;
                case 209:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.OpenBook, SoundClips.BodyFall, 209, 3); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.OpenBook, SoundClips.BodyFall, 209, 8); }
                    else if (ObjTexRecord == 9) { DetermineJewelryItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 209, 9); }
                    else { return; }
                    break;
                case 210:
                    if (ObjTexRecord == 5) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 216, 30); }
                    else { return; }
                    break;
                case 211:
                    if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.EquipClothing, 211, 0); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 211, 1); }
                    else if (ObjTexRecord == 2) { DeterminePotUrnJugType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 11) { DetermineFishBundleType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.SplashSmall, 211, 9); }
                    else if (ObjTexRecord == 12) { DetermineWeaponItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLongBlade, SoundClips.Parry1, 211, 12); }
                    else if (ObjTexRecord >= 15 && ObjTexRecord <= 17) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.BodyFall, 211, 17); }
                    else if (ObjTexRecord >= 24 && ObjTexRecord <= 25) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.EquipStaff, 211, 24); }
                    else if (ObjTexRecord == 31) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 211, 31); }
                    else if (ObjTexRecord == 40) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 211, 40); }
                    else if (ObjTexRecord >= 41 && ObjTexRecord <= 42) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.EquipStaff, 211, 41); }
                    else if (ObjTexRecord == 47) { DetermineReligiousItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 211, 47); }
                    else if (ObjTexRecord == 48) { DetermineJewelryItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 211, 48); }
                    else if (ObjTexRecord == 49) { DetermineReligiousItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.SplashSmall, 211, 49); }
                    else if (ObjTexRecord == 50) { DetermineReligiousItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 211, 50); }
                    else if (ObjTexRecord == 51 || ObjTexRecord == 53) { DetermineReligiousItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 211, 51); }
                    else if (ObjTexRecord == 52) { DetermineReligiousItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 211, 52); }
                    else if (ObjTexRecord == 57) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.BodyFall, 211, 57); }
                    else { return; }
                    break;
                case 213:
                    if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 253, 55); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 253, 0); }
                    else if (ObjTexRecord == 6) { DeterminePotUrnJugType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else { return; }
                    break;
                case 214:
                    if (ObjTexRecord == 0 || ObjTexRecord == 4 || ObjTexRecord == 11) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.EquipStaff, 214, 4); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.EquipStaff, 214, 1); }
                    else if (ObjTexRecord >= 2 && ObjTexRecord <= 3) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipMaceOrHammer, SoundClips.Parry1, 214, 3); }
                    else if (ObjTexRecord == 5) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.BodyFall, 214, 5); }
                    else if (ObjTexRecord == 6) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipAxe, SoundClips.Parry1, 214, 6); }
                    else if (ObjTexRecord == 7) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLongBlade, SoundClips.Parry1, 214, 7); }
                    else if (ObjTexRecord == 8) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 214, 8); }
                    else if (ObjTexRecord == 9) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 214, 9); }
                    else if (ObjTexRecord == 10) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.EquipStaff, 214, 10); }
                    else if (ObjTexRecord == 12) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.EquipStaff, 214, 12); }
                    else if (ObjTexRecord == 13) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.Parry1, 214, 13); }
                    else if (ObjTexRecord == 14) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.Parry1, 214, 14); }
                    else if (ObjTexRecord == 15) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.EquipStaff, 214, 15); }
                    else { return; }
                    break;
                case 216:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.OpenBook, SoundClips.BodyFall, 209, 3); }
                    else if (ObjTexRecord == 3) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 216, 3); }
                    else if (ObjTexRecord >= 6 && ObjTexRecord <= 7) { DetermineCrownPieceType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 6); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 9) { DetermineTiaraPieceType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 9); }
                    else if (ObjTexRecord >= 10 && ObjTexRecord <= 19) { DetermineGemStonePieceType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 10); }
                    else if (ObjTexRecord == 21) { DetermineJewelryItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 216, 21); }
                    else if (ObjTexRecord == 30) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.GoldPieces, SoundClips.AmbientGoldPieces, 216, 1); }
                    else { return; }
                    break;
                case 218:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 3) { DeterminePotUrnJugType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else if (ObjTexRecord == 4) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.Parry1, 218, 4); }
                    else if (ObjTexRecord == 6) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.EquipStaff, 218, 6); }
                    else { return; }
                    break;
                case 253:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.MakePotion, SoundClips.SplashSmall, 205, 11); }
                    else if (IsBookTextureGroups()) { DetermineBookBundleType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.OpenBook, SoundClips.BodyFall, 209, 3); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.OpenBook, SoundClips.BodyFall, 209, 8); }
                    else if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 213, 0); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.GoldPieces, SoundClips.AmbientGoldPieces, 216, 1); }
                    else if (ObjTexRecord == 2) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.EquipClothing, 211, 0); }
                    else if (ObjTexRecord == 16) { DetermineClothingItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipClothing, SoundClips.EquipLeather, 204, 0); }
                    else if (ObjTexRecord == 19) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 216, 30); }
                    else if (ObjTexRecord == 23 || ObjTexRecord == 24) { DetermineFishBundleType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipStaff, SoundClips.SplashSmall, 211, 9); }
                    else if (ObjTexRecord == 28) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipPlate, SoundClips.BodyFall, 208, 0); }
                    else if (ObjTexRecord >= 30 && ObjTexRecord <= 35) { DetermineGobletCupType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.EquipPlate, 216, 30); }
                    else if (ObjTexRecord == 39) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 211, 1); }
                    else if (ObjTexRecord == 54) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipJewellery, SoundClips.Parry1, 208, 1); }
                    else if (ObjTexRecord == 55) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 213, 1); }
                    else if (ObjTexRecord >= 70 && ObjTexRecord <= 73) { DetermineMiscItemType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipLeather, SoundClips.BodyFall, 205, 17); }
                    else if (ObjTexRecord == 63 || ObjTexRecord == 85) { DeterminePotUrnJugType(out items, out text); GeneralItemTakingProcess(items, clickedObj, SoundClips.EquipFlail, SoundClips.EquipLeather, 218, 2); }
                    else { return; }
                    break;
                /*case 254:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 71) {} // add whatever appropriate alchemical ingredient iten.
                    else { return; }
                    break;*/
                default:
                    return;
            }
        }

        public static string GetItemNameOrDescription() // Suppose I will do something with the "JustText" value later on in the methods, not a big deal atm.
        {
            List<DaggerfallUnityItem> items = new List<DaggerfallUnityItem>();
            string text = "";

            switch (ObjTexArchive)
            {
                case 200:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 6) { DetermineGobletCupType(out items, out text, true); }
                    break;
                case 204:
                    if (ObjTexRecord == 0) { DetermineClothingItemType(out items, out text, true); }
                    else if (ObjTexRecord >= 1 && ObjTexRecord <= 2) { DetermineClothingItemType(out items, out text, true); }
                    else if (ObjTexRecord >= 3 && ObjTexRecord <= 5) { DetermineClothingItemType(out items, out text, true); }
                    else if (ObjTexRecord == 9) { DetermineClothingItemType(out items, out text, true); }
                    break;
                case 205:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out items, out text, true); }
                    else if (ObjTexRecord == 42) { text = "You see a quiver carrying a few arrows."; }
                    else if (ObjTexRecord == 41) { DeterminePotUrnJugType(out items, out text, true); }
                    else if (ObjTexRecord == 10) { DetermineFishBundleType(out items, out text, true); }
                    else if (ObjTexRecord >= 17 && ObjTexRecord <= 20) { DetermineMiscItemType(out items, out text); }
                    break;
                case 207:
                    if (ObjTexRecord == 0 || ObjTexRecord == 2 || ObjTexRecord == 3) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord == 1 || ObjTexRecord == 5) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord == 4) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord == 6) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord == 7) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord == 8) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord == 9) { DetermineArmorItemType(out items, out text, true); }
                    else if (ObjTexRecord == 10) { DetermineArmorItemType(out items, out text, true); }
                    else if (ObjTexRecord == 11) { DetermineArmorItemType(out items, out text, true); }
                    else if (ObjTexRecord == 12 || ObjTexRecord == 14) { DetermineArmorItemType(out items, out text, true); }
                    else if (ObjTexRecord == 13) { DetermineJewelryItemType(out items, out text, true); }
                    else if (ObjTexRecord == 15) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord == 16) { text = "You see an arrow."; }
                    break;
                case 208:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out items, out text, true); }
                    else if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 3) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 4) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 5) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 6) { DetermineMiscItemType(out items, out text, true); }
                    break;
                case 209:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out items, out text, true); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out items, out text, true); }
                    else if (ObjTexRecord == 9) { DetermineJewelryItemType(out items, out text, true); }
                    break;
                case 210:
                    if (ObjTexRecord == 5) { DetermineMiscItemType(out items, out text, true); }
                    break;
                case 211:
                    if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 2) { DeterminePotUrnJugType(out items, out text, true); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 11) { DetermineFishBundleType(out items, out text, true); }
                    else if (ObjTexRecord == 12) { DetermineWeaponItemType(out items, out text, true); }
                    else if (ObjTexRecord >= 15 && ObjTexRecord <= 17) { DetermineMiscItemType(out items, out text); }
                    else if (ObjTexRecord >= 24 && ObjTexRecord <= 25) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 31) { DetermineMiscItemType(out items, out text); }
                    else if (ObjTexRecord == 40) { DetermineMiscItemType(out items, out text); }
                    else if (ObjTexRecord >= 41 && ObjTexRecord <= 42) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 47) { DetermineReligiousItemType(out items, out text, true); }
                    else if (ObjTexRecord == 48) { DetermineJewelryItemType(out items, out text, true); }
                    else if (ObjTexRecord == 49) { DetermineReligiousItemType(out items, out text, true); }
                    else if (ObjTexRecord == 50) { DetermineReligiousItemType(out items, out text, true); }
                    else if (ObjTexRecord == 51 || ObjTexRecord == 53) { DetermineReligiousItemType(out items, out text, true); }
                    else if (ObjTexRecord == 52) { DetermineReligiousItemType(out items, out text, true); }
                    else if (ObjTexRecord == 57) { DetermineMiscItemType(out items, out text, true); }
                    break;
                case 213:
                    if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text); }
                    else if (ObjTexRecord == 6) { DeterminePotUrnJugType(out items, out text, true); }
                    break;
                case 214:
                    if (ObjTexRecord == 0 || ObjTexRecord == 4 || ObjTexRecord == 11) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord >= 2 && ObjTexRecord <= 3) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 5) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 6) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 7) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 8) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 9) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 10) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 12) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 13) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 14) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 15) { DetermineMiscItemType(out items, out text, true); }
                    break;
                case 216:
                    if (IsBookTextureGroups()) { DetermineBookBundleType(out items, out text, true); }
                    else if (ObjTexRecord == 3) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord >= 6 && ObjTexRecord <= 7) { DetermineCrownPieceType(out items, out text, true); }
                    else if (ObjTexRecord >= 8 && ObjTexRecord <= 9) { DetermineTiaraPieceType(out items, out text, true); }
                    else if (ObjTexRecord >= 10 && ObjTexRecord <= 19) { DetermineGemStonePieceType(out items, out text, true); }
                    else if (ObjTexRecord == 21) { DetermineJewelryItemType(out items, out text, true); }
                    else if (ObjTexRecord == 30) { DetermineMiscItemType(out items, out text, true); }
                    break;
                case 218:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 3) { DeterminePotUrnJugType(out items, out text, true); }
                    else if (ObjTexRecord == 4) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 6) { DetermineMiscItemType(out items, out text, true); }
                    break;
                case 253:
                    if (IsPotionBottleTextureGroups()) { DetermineGlassBottlePotionType(out items, out text, true); }
                    else if (IsBookTextureGroups()) { DetermineBookBundleType(out items, out text, true); }
                    else if (IsPaperTextureGroups()) { DeterminePaperScrollStackType(out items, out text, true); }
                    else if (ObjTexRecord == 0) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 1) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 2) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 16) { DetermineClothingItemType(out items, out text, true); }
                    else if (ObjTexRecord == 19) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 23 || ObjTexRecord == 24) { DetermineFishBundleType(out items, out text, true); }
                    else if (ObjTexRecord == 28) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord >= 30 && ObjTexRecord <= 35) { DetermineGobletCupType(out items, out text, true); }
                    else if (ObjTexRecord == 39) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 54) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord == 55) { DetermineMiscItemType(out items, out text, true); }
                    else if (ObjTexRecord >= 70 && ObjTexRecord <= 73) { DetermineMiscItemType(out items, out text); }
                    else if (ObjTexRecord == 63 || ObjTexRecord == 85) { DeterminePotUrnJugType(out items, out text, true); }
                    break;
                /*case 254:
                    if (ObjTexRecord >= 0 && ObjTexRecord <= 71) { text = "You see an alchemical ingredient."; }
                    break;*/
                default:
                    break;
            }
            return text;
        }

        public static void GeneralItemTakingProcess(List<DaggerfallUnityItem> items, GameObject clickedObj, SoundClips takeSound = SoundClips.EquipJewellery, SoundClips dropSound = SoundClips.BodyFall, int lootPileArc = -1, int lootPileRec = -1, bool noWeight = false)
        {
            float totalWeight = 0f;
            int nonNullCount = 0;
            GameObject marker = null;
            DaggerfallAudioSource dfAudioSource = null;

            if (items == null || items.Count < 1) { return; }

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == null) { continue; }
                totalWeight += items[i].weightInKg;
                nonNullCount++;
            }

            if (nonNullCount < 1) { return; }

            IsThisACrime();
            marker = CreateStolenObjectMarker(clickedObj.transform.position, clickedObj.transform.parent);
            dfAudioSource = marker.GetComponent<DaggerfallAudioSource>();

            if (!noWeight && DoesThisEncumberPlayer(totalWeight))
            {
                DaggerfallLoot droppedItems = GameObjectHelper.CreateDroppedLootContainer(GameManager.Instance.PlayerObject, DaggerfallUnity.NextUID, lootPileArc == -1 ? 216 : lootPileArc, lootPileRec == -1 ? -1 : lootPileRec);
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] == null) { continue; }
                    droppedItems.Items.AddItem(items[i]);
                }
                if (dfAudioSource != null) { dfAudioSource.PlayOneShot(dropSound); }
                DaggerfallUI.AddHUDText("Unable to carry anymore, you drop the item on the ground...", 3f);
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] == null) { continue; }
                    Player.Items.AddItem(items[i]);
                }
                if (dfAudioSource != null) { dfAudioSource.PlayOneShot(takeSound); }
            }
            clickedObj.SetActive(false);
        }

        public static void ShowNameOrDescription()
        {
            DaggerfallUI.AddHUDText(GetItemNameOrDescription(), 2f);
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

        public static void DetermineGlassBottlePotionType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false) // Was thinking of having potions picked up in this way be unidentified and potentially poisoned or some other effects. While I still would like to do something like this eventually, I think for now for the initial release I'll just have be more basic, as to avoid the headache of implementing it the way I initially wanted, eventually but not for v1.0 atleast.
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 205)
            {
                if (ObjTexRecord >= 1 && ObjTexRecord <= 7) { items.Add(CreateRandomPotionItems()); desc = "You see a large glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord >= 11 && ObjTexRecord <= 16) { items.Add(CreateRandomPotionItems()); desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 31)
                {
                    int amount = 5;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateRandomPotionItems());
                    }
                    desc = "You see a bunch of glass bottles filled with unknown liquids.";
                }
                else if (ObjTexRecord >= 32 && ObjTexRecord <= 35) { items.Add(CreateRandomPotionItems()); desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 43) { items.Add(CreateRandomPotionItems()); desc = "You see a small glass bottle filled with an unknown liquid."; }
            }
            else if (ObjTexArchive == 208)
            {
                if (ObjTexRecord == 2) { items.Add(CreateRandomPotionItems()); desc = "You see a glass bottle filled with an unknown liquid, being heated by a flame."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord >= 4 && ObjTexRecord <= 6) { items.Add(CreateRandomPotionItems()); desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord >= 25 && ObjTexRecord <= 27) { items.Add(CreateRandomPotionItems()); desc = "You see a glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 40) { items.Add(CreateRandomPotionItems()); desc = "You see a large glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 41) { items.Add(CreateRandomPotionItems()); desc = "You see a glass bottle filled with an unknown liquid, being heated by a flame."; }
                else if (ObjTexRecord >= 42 && ObjTexRecord <= 47) { items.Add(CreateRandomPotionItems()); desc = "You see a large glass bottle filled with an unknown liquid."; }
                else if (ObjTexRecord == 48) { items.Add(CreateRandomPotionItems()); desc = "You see a glass bottle filled with an unknown liquid, being heated by a flame."; }
            }
        }

        public static void DeterminePaperScrollStackType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false) // This is where alot of the flavor text and various other efforts are likely going to go into, so get comfy being around here for awhile...
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 209)
            {
                if (ObjTexRecord == 5) { items.Add(GetLetterItemDungeonOrInterior()); desc = "You see a piece of parchment.";}
                else if (ObjTexRecord == 6)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(GetLetterItemDungeonOrInterior());
                    }
                    desc = "You see a stack of papers.";
                }
                else if (ObjTexRecord >= 7 && ObjTexRecord <= 8) { items.Add(GetLetterItemDungeonOrInterior()); desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 10)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(GetLetterItemDungeonOrInterior());
                    }
                    desc = "You see a stack of papers.";
                }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 53) { items.Add(GetLetterItemDungeonOrInterior()); desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 56) { items.Add(GetLetterItemDungeonOrInterior()); desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 64)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(GetLetterItemDungeonOrInterior());
                    }
                    desc = "You see a stack of papers.";
                }
                else if (ObjTexRecord == 74) { items.Add(GetLetterItemDungeonOrInterior()); desc = "You see a piece of parchment."; }
                else if (ObjTexRecord == 80)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(GetLetterItemDungeonOrInterior());
                    }
                    desc = "You see a stack of papers.";
                }
            }
        }

        public static void DetermineBookBundleType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 209)
            {
                if (ObjTexRecord == 0)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateRandomBookItems(true));
                    }
                    desc = "You see a large stack of books.";
                }
                else if (ObjTexRecord == 1)
                {
                    int amount = 2;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateRandomBookItems(true));
                    }
                    desc = "You see a small stack of books.";
                }
                else if (ObjTexRecord >= 2 && ObjTexRecord <= 4) { items.Add(CreateRandomBookItems()); desc = "You see a book.";}
            }
            else if (ObjTexArchive == 216)
            {
                if (ObjTexRecord == 40)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateRandomBookItems(true));
                    }
                    desc = "You see a large stack of books.";
                }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord >= 7 && ObjTexRecord <= 9) { items.Add(CreateRandomBookItems()); desc = "You see a book."; }
                else if (ObjTexRecord == 57)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateRandomBookItems(true));
                    }
                    desc = "You see a large stack of books.";
                }
                else if (ObjTexRecord == 58)
                {
                    int amount = 2;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateRandomBookItems(true));
                    }
                    desc = "You see a small stack of books.";
                }
            }
        }

        public static void DetermineGobletCupType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 200)
            {
                if (ObjTexRecord == 0 || ObjTexRecord == 2) { items.Add(KMItemBuilder.CreateGobletCupVariant(1)); desc = "You see a silver goblet."; }
                else if (ObjTexRecord == 1 || ObjTexRecord == 3) { items.Add(KMItemBuilder.CreateGobletCupVariant(2)); desc = "You see a gold goblet."; }
                else if (ObjTexRecord == 4) { items.Add(KMItemBuilder.CreateGobletCupVariant(3)); desc = "You see a gem studded silver goblet."; }
                else if (ObjTexRecord == 5) { items.Add(KMItemBuilder.CreateGobletCupVariant(4)); desc = "You see a gem studded gold goblet."; }
                else if (ObjTexRecord == 6) { items.Add(KMItemBuilder.CreateGobletCupVariant(0)); desc = "You see a wooden cup."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 30 || ObjTexRecord == 32) { items.Add(KMItemBuilder.CreateGobletCupVariant(1)); desc = "You see a silver goblet."; }
                else if (ObjTexRecord == 31 || ObjTexRecord == 33) { items.Add(KMItemBuilder.CreateGobletCupVariant(2)); desc = "You see a gold goblet."; }
                else if (ObjTexRecord == 34) { items.Add(KMItemBuilder.CreateGobletCupVariant(3)); desc = "You see a gem studded silver goblet."; }
                else if (ObjTexRecord == 35) { items.Add(KMItemBuilder.CreateGobletCupVariant(4)); desc = "You see a gem studded gold goblet."; }
            }
        }

        public static void DeterminePotUrnJugType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 205)
            {
                if (ObjTexRecord == 41) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemUrn.templateIndex)); desc = "You see an urn."; }
            }
            else if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 2) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemUrn.templateIndex)); desc = "You see an urn."; }
            }
            else if (ObjTexArchive == 213)
            {
                if (ObjTexRecord == 6) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemVase.templateIndex)); desc = "You see a blue vase with flowers in it."; }
            }
            else if (ObjTexArchive == 218)
            {
                if (ObjTexRecord == 0) { items.Add(KMItemBuilder.CreateClayPotVariant(3)); desc = "You see an engraved brown pot."; }
                else if (ObjTexRecord == 1) { items.Add(KMItemBuilder.CreateClayPotVariant(1)); desc = "You see a gray pot."; }
                else if (ObjTexRecord == 2) { items.Add(KMItemBuilder.CreateClayPotVariant(0)); desc = "You see a brown pot."; }
                else if (ObjTexRecord == 3) { items.Add(KMItemBuilder.CreateClayPotVariant(2)); desc = "You see a green pot."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 63) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemUrn.templateIndex)); desc = "You see an urn."; }
                else if (ObjTexRecord == 85) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemVase.templateIndex)); desc = "You see a blue vase with flowers in it."; }
            }
        }

        public static void DetermineMiscItemType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 205)
            {
                if (ObjTexRecord >= 17 && ObjTexRecord <= 20) { items.Add(CreateCNCItems(0)); desc = "You see a sack."; }
            }
            else if (ObjTexArchive == 208)
            {
                if (ObjTexRecord == 0) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemGlobe.templateIndex)); desc = "You see a globe."; }
                else if (ObjTexRecord == 1) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemMagnifyingGlass.templateIndex)); desc = "You see a magnifying glass."; }
                else if (ObjTexRecord == 3) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemWeightScale.templateIndex)); desc = "You see a scale."; }
                else if (ObjTexRecord == 4) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemTelescope.templateIndex)); desc = "You see a telescope."; }
                else if (ObjTexRecord == 5) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemHandMirror.templateIndex)); desc = "You see a hand mirror."; }
                else if (ObjTexRecord == 6) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemHourglass.templateIndex)); desc = "You see an hourglass."; }
            }
            else if (ObjTexArchive == 210)
            {
                if (ObjTexRecord == 5) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemCandelabra.templateIndex)); desc = "You see a candelabra."; }
            }
            else if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 0) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Bandage)); desc = "You see a bandage."; }
                else if (ObjTexRecord == 1) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemInkwell.templateIndex)); desc = "You see an inkwell."; }
                else if (ObjTexRecord >= 15 && ObjTexRecord <= 17) { items.Add(CreateRealisticWagonItems(0)); desc = "You see a wheel."; }
                else if (ObjTexRecord >= 24 && ObjTexRecord <= 25) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemSmokingPipe.templateIndex)); desc = "You see a smoking pipe."; }
                else if (ObjTexRecord == 31) { items.Add(CreateCNCItems(3)); desc = "You see a loaf of bread."; }
                else if (ObjTexRecord == 40) { items.Add(CreateCNCItems(6)); desc = "You see a piece of meat."; }
                else if (ObjTexRecord >= 41 && ObjTexRecord <= 42) { items.Add(KMItemBuilder.CreateRandomAnimalTooth()); desc = "You see an animal tooth."; }
                else if (ObjTexRecord == 57) { items.Add(KMItemBuilder.CreateRandomPainting()); desc = "You see a painting."; }
            }
            else if (ObjTexArchive == 213)
            {
                if (ObjTexRecord == 0) { items.Add(CreateCNCItems(2)); desc = "You see an orange."; }
                else if (ObjTexRecord == 1) { items.Add(CreateCNCItems(1)); desc = "You see an apple."; }
            }
            else if (ObjTexArchive == 214)
            {
                if (ObjTexRecord == 0 || ObjTexRecord == 4 || ObjTexRecord == 11) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemScoop.templateIndex)); desc = "You see a scoop."; }
                else if (ObjTexRecord == 1) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemShovel.templateIndex)); desc = "You see a shovel."; }
                else if (ObjTexRecord >= 2 && ObjTexRecord <= 3) { items.Add(CreateRepairToolsItems(0)); desc = "You see a hammer."; }
                else if (ObjTexRecord == 5) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemButterChurn.templateIndex)); desc = "You see a butter churn."; }
                else if (ObjTexRecord == 6) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemPickaxe.templateIndex)); desc = "You see a pickaxe."; }
                else if (ObjTexRecord == 7) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemScythe.templateIndex)); desc = "You see a scythe."; }
                else if (ObjTexRecord == 8) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemRope.templateIndex)); desc = "You see a pile of rope."; }
                else if (ObjTexRecord == 9) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemBellows.templateIndex)); desc = "You see a bellows."; }
                else if (ObjTexRecord == 10) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemBroom.templateIndex)); desc = "You see a broom."; }
                else if (ObjTexRecord == 12) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemBrush.templateIndex)); desc = "You see a brush."; }
                else if (ObjTexRecord == 13) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemTongs.templateIndex)); desc = "You see a pair of tongs."; }
                else if (ObjTexRecord == 14) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemShears.templateIndex)); desc = "You see a pair of shears."; }
                else if (ObjTexRecord == 15) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemTrowel.templateIndex)); desc = "You see a wooden trowel."; }
            }
            else if (ObjTexArchive == 216)
            {
                if (ObjTexRecord == 3) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemGoldBar.templateIndex)); desc = "You see a solid gold bar."; }
                else if (ObjTexRecord == 30) { items.Add(KMItemBuilder.CreatePouchDrops()); desc = "You see a small pouch."; }
            }
            else if (ObjTexArchive == 218)
            {
                if (ObjTexRecord == 4) { items.Add(CreateCNCItems(8)); desc = "You see an iron skillet."; }
                else if (ObjTexRecord == 6) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemSpoon.templateIndex)); desc = "You see a wooden spoon."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 0) { items.Add(CreateCNCItems(1)); desc = "You see an apple."; }
                else if (ObjTexRecord == 1) { items.Add(KMItemBuilder.CreatePouchDrops()); desc = "You see a small pouch."; }
                else if (ObjTexRecord == 2) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, (int)UselessItems2.Bandage)); desc = "You see a bandage."; }
                else if (ObjTexRecord == 19) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemCandelabra.templateIndex)); desc = "You see a candelabra."; }
                else if (ObjTexRecord == 28) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemGlobe.templateIndex)); desc = "You see a globe."; }
                else if (ObjTexRecord == 39) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemInkwell.templateIndex)); desc = "You see an inkwell."; }
                else if (ObjTexRecord == 54) { items.Add(ItemBuilder.CreateItem(ItemGroups.UselessItems2, ItemMagnifyingGlass.templateIndex)); desc = "You see a magnifying glass."; }
                else if (ObjTexRecord == 55) { items.Add(CreateCNCItems(2)); desc = "You see an orange."; }
                else if (ObjTexRecord >= 70 && ObjTexRecord <= 73) { items.Add(CreateCNCItems(0)); desc = "You see a sack."; }
            }
        }

        public static void DetermineClothingItemType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 204)
            {
                if (ObjTexRecord == 0)
                {
                    int amount = UnityEngine.Random.Range(1, 5);
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(KMItemBuilder.ChooseRandomClothingPiece());
                    }
                    desc = "You see a pile of clothing.";
                }
                else if (ObjTexRecord >= 1 && ObjTexRecord <= 2) { items.Add(KMItemBuilder.ChooseRandomFootwear()); desc = "You see a pair of footwear."; }
                else if (ObjTexRecord >= 3 && ObjTexRecord <= 5) { items = null; desc = "You see a hat."; } // No headwear for the time being, but maybe eventually.
                else if (ObjTexRecord == 9) { items.Add(KMItemBuilder.ChooseRandomStraps()); desc = "You see some straps of cloth."; }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 16)
                {
                    int amount = UnityEngine.Random.Range(1, 5);
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(KMItemBuilder.ChooseRandomClothingPiece());
                    }
                    desc = "You see a pile of clothing.";
                }
            }
        }

        public static void DetermineWeaponItemType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 207)
            {
                if (ObjTexRecord == 0 || ObjTexRecord == 2 || ObjTexRecord == 3) { items.Add(ChooseRandomWeapon(0)); desc = "You see a sword."; }
                else if (ObjTexRecord == 1 || ObjTexRecord == 5) { items.Add(ChooseRandomWeapon(1)); desc = "You see a small blade."; }
                else if (ObjTexRecord == 4) { items.Add(ChooseRandomWeapon(2)); desc = "You see an axe."; }
                else if (ObjTexRecord == 6) { items.Add(ChooseRandomWeapon(3)); desc = "You see a mace."; }
                else if (ObjTexRecord == 7) { items.Add(ChooseRandomWeapon(4)); desc = "You see a staff."; }
                else if (ObjTexRecord == 8) { items.Add(ChooseRandomWeapon(5)); desc = "You see a bow."; }
                else if (ObjTexRecord == 15) { items.Add(ChooseRandomWeapon(6)); desc = "You see a large sword."; }
            }
            else if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 12)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(ChooseRandomWeapon(0, -1, true));
                    }
                    desc = "You see a stack of swords.";
                }
            }
        }

        public static void DetermineArmorItemType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 207)
            {
                if (ObjTexRecord == 9) { items.Add(ChooseRandomArmor(0)); desc = "You see a large shield."; }
                else if (ObjTexRecord == 10) { items.Add(ChooseRandomArmor(1)); desc = "You see a shield."; }
                else if (ObjTexRecord == 11) { items.Add(ChooseRandomArmor(2)); desc = "You see a piece of chest armor."; }
                else if (ObjTexRecord == 12 || ObjTexRecord == 14) { items.Add(ChooseRandomArmor(3)); desc = "You see a helmet."; }
            }
        }

        public static void DetermineJewelryItemType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 207)
            {
                if (ObjTexRecord == 13) { items.Add(ItemBuilder.CreateItem(ItemGroups.Jewellery, (int)Jewellery.Bracer)); desc = "You see a bracer."; }
            }
            else if (ObjTexArchive == 209)
            {
                if (ObjTexRecord == 9) { items.Add(ItemBuilder.CreateItem(ItemGroups.Jewellery, (int)Jewellery.Mark)); desc = "You see a cloth mark."; }
            }
            else if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 48) { items.Add(ItemBuilder.CreateItem(ItemGroups.Jewellery, (int)Jewellery.Torc)); desc = "You see a torc."; }
            }
            else if (ObjTexArchive == 216)
            {
                if (ObjTexRecord == 21) { items.Add(ItemBuilder.CreateItem(ItemGroups.Jewellery, (int)Jewellery.Bracelet)); desc = "You see a bracelet."; }
            }
        }

        public static void DetermineReligiousItemType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 47) { items.Add(ItemBuilder.CreateItem(ItemGroups.ReligiousItems, (int)ReligiousItems.Bell)); desc = "You see a small bell."; }
                else if (ObjTexRecord == 49) { items.Add(ItemBuilder.CreateItem(ItemGroups.ReligiousItems, (int)ReligiousItems.Holy_water)); desc = "You see a cup of holy water."; }
                else if (ObjTexRecord == 50) { items.Add(ItemBuilder.CreateItem(ItemGroups.ReligiousItems, (int)ReligiousItems.Talisman)); desc = "You see a talisman."; }
                else if (ObjTexRecord == 51 || ObjTexRecord == 53) { items.Add(ItemBuilder.CreateItem(ItemGroups.ReligiousItems, (int)ReligiousItems.Icon)); desc = "You see a religious icon."; }
                else if (ObjTexRecord == 52) { items.Add(ItemBuilder.CreateItem(ItemGroups.ReligiousItems, (int)ReligiousItems.Scarab)); desc = "You see a scarab."; }
            }
            else if (ObjTexArchive == 209)
            {
                if (ObjTexRecord == 9) { items.Add(ItemBuilder.CreateItem(ItemGroups.Jewellery, (int)Jewellery.Mark)); desc = "You see a cloth mark."; }
            }
        }

        public static void DetermineFishBundleType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 205)
            {
                if (ObjTexRecord == 10)
                {
                    int amount = UnityEngine.Random.Range(4, 11);
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateCNCItems(5));
                    }
                    desc = "You see a basket full of prepared fish.";
                }
            }
            else if (ObjTexArchive == 211)
            {
                if (ObjTexRecord == 8)
                {
                    int amount = UnityEngine.Random.Range(4, 11);
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateCNCItems(4));
                    }
                    desc = "You see a pile of raw fish.";
                }
                else if (ObjTexRecord == 9) { items.Add(CreateCNCItems(4)); desc = "You see a fish."; }
                else if (ObjTexRecord == 10) { items.Add(CreateCNCItems(5)); desc = "You see a cooked fish."; }
                else if (ObjTexRecord == 11)
                {
                    int amount = UnityEngine.Random.Range(2, 4);
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateCNCItems(5));
                    }
                    desc = "You see a bundle of cooked fish.";
                }
            }
            else if (ObjTexArchive == 253)
            {
                if (ObjTexRecord == 23)
                {
                    int amount = UnityEngine.Random.Range(4, 11);
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateCNCItems(4));
                    }
                    desc = "You see a pile of raw fish.";
                }
                else if (ObjTexRecord == 24) { items.Add(CreateCNCItems(4)); desc = "You see a fish."; }
            }
        }

        public static void DetermineGemStonePieceType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 216)
            {
                if (ObjTexRecord >= 10 && ObjTexRecord <= 17) { items.Add(CreateRandomGemStoneItems()); desc = "You see a gem."; }
                else if (ObjTexRecord >= 18 && ObjTexRecord <= 19)
                {
                    int amount = 3;
                    for (int i = 0; i < amount; i++)
                    {
                        items.Add(CreateRandomGemStoneItems());
                    }
                    desc = "You see a small stack of gems.";
                }
            }
        }

        public static void DetermineCrownPieceType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 216)
            {
                if (ObjTexRecord >= 6) { items.Add(CreateRandomCrownItems()); desc = "You see a gold crown."; }
                else if (ObjTexRecord == 7) { items.Add(CreateRandomCrownItems()); desc = "You see a silver crown."; }
            }
        }

        public static void DetermineTiaraPieceType(out List<DaggerfallUnityItem> items, out string desc, bool justText = false)
        {
            items = new List<DaggerfallUnityItem>();
            desc = "";
            if (ObjTexArchive == 216)
            {
                if (ObjTexRecord >= 8) { items.Add(CreateRandomTiaraItems()); desc = "You see a silver tiara."; }
                else if (ObjTexRecord == 9) { items.Add(CreateRandomTiaraItems()); desc = "You see a gold tiara."; }
            }
        }
    }
}
