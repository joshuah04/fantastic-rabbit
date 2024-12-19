using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class ScreenManager
    {
        private readonly List<Screen> Screens;
        public Screen CurrentScreen { get; private set;}
        public GameState CurrentState { get; private set; }

        public ScreenManager(Rectangle ScreenSize)
        {
            Screens = new List<Screen>
            {
                new MenuScreen(ScreenSize, this),
                new EndGameScreen(ScreenSize, this),
            };

            // Set the current screen to the first screen in the list
            CurrentScreen = Screens[0];
            CurrentState = GameState.MainMenu;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentScreen?.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            CurrentScreen?.Update(gameTime);
        }

        public void LoadContent(ContentManager content)
        {
            foreach (var screen in Screens)
            {
                screen.LoadContent(content);
            }
        }

        // Switch to a different screen by index
        public void SwitchScreen(int screenIndex)
        {
            if (screenIndex >= 0 && screenIndex < Screens.Count)
            {
                CurrentScreen = Screens[screenIndex];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(screenIndex), "Invalid screen index.");
            }
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;

            switch (CurrentState)
            {
                case GameState.MainMenu:
                    CurrentScreen = Screens[0];  // MenuScreen
                    break;
                case GameState.GameRunning:
                    break;
                case GameState.Paused:
                    // Handle paused screen
                    break;
                case GameState.GameOver:
                    CurrentScreen = Screens[1];
                    // Handle game over screen
                    break;
                case GameState.Exiting:
                    // Exit the game
                    break;
            }
        }
    }
}