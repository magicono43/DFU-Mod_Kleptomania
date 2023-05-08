using UnityEngine;
using DaggerfallWorkshop.Game.UserInterface;
using Kleptomania;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallConnect.Arena2;

namespace DaggerfallWorkshop.Game.UserInterfaceWindows
{
    /// <summary>
    /// Implements Kleptomania's Grab-Mode Choice Interface Window.
    /// </summary>
    public class GrabModeChoiceWindow : DaggerfallPopupWindow
    {
        PlayerEntity player;

        PlayerEntity Player
        {
            get { return (player != null) ? player : player = GameManager.Instance.PlayerEntity; }
        }

        protected GameObject clickedObj = null;

        #region Testing Properties

        public static Rect butt1 = new Rect(0, 0, 0, 0);
        public static Rect butt2 = new Rect(0, 0, 0, 0);
        public static Rect butt3 = new Rect(0, 0, 0, 0);

        #endregion

        #region Constructors

        public GrabModeChoiceWindow(IUserInterfaceManager uiManager, GameObject clickedObj = null)
            : base(uiManager)
        {
            this.clickedObj = clickedObj;
        }

        #endregion

        #region UI Textures

        Texture2D baseTexture;

        #endregion

        protected override void Setup()
        {
            base.Setup();

            // Load textures
            LoadTextures();

            // This makes the background "transparent" instead of a blank black screen when opening this window.
            ParentPanel.BackgroundColor = ScreenDimColor;

            // Setup native panel background
            NativePanel.BackgroundColor = ScreenDimColor;
            NativePanel.BackgroundTexture = baseTexture;

            SetupGrabModeChoiceButtons();
        }

        protected virtual void LoadTextures()
        {
            baseTexture = KleptomaniaMain.Instance.GrabModeChoiceMenuTexture;
        }

        protected void SetupGrabModeChoiceButtons()
        {
            // Steal Item button
            Button stealItemButton = DaggerfallUI.AddButton(new Rect(144, 70, 33, 16), NativePanel);
            stealItemButton.ToolTip = defaultToolTip;
            stealItemButton.ToolTipText = "Steal Item";
            stealItemButton.OnMouseClick += StealItemButton_OnMouseClick;
            stealItemButton.ClickSound = DaggerfallUI.Instance.GetAudioClip(SoundClips.ButtonClick);

            // Inspect Item button
            Button inspectItemButton = DaggerfallUI.AddButton(new Rect(144, 92, 33, 16), NativePanel);
            inspectItemButton.ToolTip = defaultToolTip;
            inspectItemButton.ToolTipText = "Inspect Item";
            inspectItemButton.OnMouseClick += InspectItemButton_OnMouseClick;
            inspectItemButton.ClickSound = DaggerfallUI.Instance.GetAudioClip(SoundClips.ButtonClick);

            // Exit button
            Button exitButton = DaggerfallUI.AddButton(new Rect(142, 114, 36, 17), NativePanel);
            exitButton.OnMouseClick += ExitButton_OnMouseClick;
            exitButton.ClickSound = DaggerfallUI.Instance.GetAudioClip(SoundClips.ButtonClick);
        }

        private void InspectItemButton_OnMouseClick(BaseScreenComponent sender, Vector2 position)
        {
            CloseWindow();

            TextFile.Token[] textToken = DaggerfallUnity.Instance.TextProvider.CreateTokens(TextFile.Formatting.JustifyCenter,
            KleptomaniaMain.GetItemNameOrDescription());

            DaggerfallMessageBox inspectItemPopup = new DaggerfallMessageBox(DaggerfallUI.UIManager, DaggerfallUI.UIManager.TopWindow);
            inspectItemPopup.SetTextTokens(textToken);
            inspectItemPopup.Show();
            inspectItemPopup.ClickAnywhereToClose = true;
        }

        private void StealItemButton_OnMouseClick(BaseScreenComponent sender, Vector2 position)
        {
            CloseWindow();
            KleptomaniaMain.TakeOrStealItem(clickedObj);
        }

        private void ExitButton_OnMouseClick(BaseScreenComponent sender, Vector2 position)
        {
            CloseWindow();
        }
    }
}
