using UnityEngine;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Utility;

namespace Kleptomania
{
    public partial class KleptomaniaMain
    {
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
    }
}
