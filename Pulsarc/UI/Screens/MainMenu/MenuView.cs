﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Pulsarc.Skinning;
using Pulsarc.UI.Screens.MainMenu.UI;
using Pulsarc.UI.Screens.SongSelect;
using Wobble.Screens;

namespace Pulsarc.UI.Screens.MainMenu
{
    class MenuView : ScreenView
    {

        Background background;
        GameIcon gameIcon;

        public List<NavigationButton> navButtons;


        public MenuView(Screen screen) : base(screen)
        {
            background = new Background();

            gameIcon = new GameIcon(new Vector2(getSkinnableInt("IconX"), getSkinnableInt("IconY")));

            navButtons = new List<NavigationButton>();
            navButtons.Add(new NavigationButton(new SongSelection(), getSkinnableInt("PlayType"), "Play Game", new Vector2(getSkinnableInt("PlayX"), getSkinnableInt("PlayY"))));
            navButtons.Add(new NavigationButton(new InProgressScreen(), getSkinnableInt("MultiType"), "Multiplayer", new Vector2(getSkinnableInt("MultiX"), getSkinnableInt("MultiY"))));
            navButtons.Add(new NavigationButton(new InProgressScreen(), getSkinnableInt("EditorType"), "Editor", new Vector2(getSkinnableInt("EditorX"), getSkinnableInt("EditorY"))));
            navButtons.Add(new NavigationButton(new InProgressScreen(), getSkinnableInt("SettingsType"), "Settings", new Vector2(getSkinnableInt("SettingsX"), getSkinnableInt("SettingsY"))));
            navButtons.Add(new NavigationButton(new InProgressScreen(), getSkinnableInt("QuitType"), "Quit", new Vector2(getSkinnableInt("QuitX"), getSkinnableInt("QuitY"))));
        }

        private float getSkinnablePosition(string key)
        {
            return Skin.getConfigFloat("main_menu", "Positions", key);
        }

        private int getSkinnableInt(string key)
        {
            return Skin.getConfigInt("main_menu", "Positions", key);
        }

        private Anchor getSkinnableAnchor(string key)
        {
            return Skin.getConfigAnchor("main_menu", "Positions", key);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            background.Draw();
            foreach(NavigationButton button in navButtons)
            {
                button.Draw();
            }
            gameIcon.Draw();
        }
        public override void Destroy()
        {
        }
    }
}