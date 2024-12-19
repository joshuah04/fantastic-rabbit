using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint0.Constants;
using System.Linq;

namespace Sprint0
{
    public class MenuScreen : Screen
    {
        private Texture2D MenuLogo; // Texture for the main menu logo
        private Texture2D cursor; // Texture for the cursor icon
        private int cursorLocation; // Tracks the current menu item selected
        private SpriteFont font; // Font used for menu text
        private Dictionary<string, int> menuItems; // Menu items and their positions on screen
        private SpriteBatch spriteBatch; // SpriteBatch used for drawing
        private KeyboardState previousState; // Stores the previous keyboard state for single key press detection
        private KeyboardState state; // Current keyboard state
        private ScreenManager screenManager; // Reference to the screen manager

        public MenuScreen(Rectangle screenSize, ScreenManager screenManager)
            : base(screenSize)
        {
            this.screenManager = screenManager;

            // Initialize menu items with their display positions
            menuItems = new Dictionary<string, int>
            {
                {"1 Player", ScreenConstants.MenuItems["1 Player"]},
                {"2 Player", ScreenConstants.MenuItems["2 Player"]},
                {"Exit Game", ScreenConstants.MenuItems["Exit Game"]}
            };

            cursorLocation = 0;
            previousState = Keyboard.GetState();
        }

        public override void LoadContent(ContentManager content)
        {
            // Load content related to menu screen
            MenuLogo = content.Load<Texture2D>(ScreenConstants.MenuLogoTexturePath);
            cursor = content.Load<Texture2D>(ScreenConstants.CursorTexturePath);
            font = content.Load<SpriteFont>(ScreenConstants.FontPath);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(MenuLogo, new Vector2(ScreenSize.Width / 2 - MenuLogo.Width / 2, ScreenConstants.MenuLogoPositionY), Color.White);

            // Draw each menu item on screen
            foreach (var item in menuItems)
            {
                spriteBatch.DrawString(font, item.Key, new Vector2(ScreenSize.Width / 2 - ScreenConstants.MenuItemOffsetX, item.Value), Color.White);
            }

            drawCursor(); // Draw the cursor at the selected item

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            state = Keyboard.GetState();

            // Handle "Up" key press event (only trigger once per press)
            if (state.IsKeyDown(Keys.Up) && !previousState.IsKeyDown(Keys.Up))
            {
                backItem();
            }

            // Handle "Down" key press event (only trigger once per press)
            if (state.IsKeyDown(Keys.Down) && !previousState.IsKeyDown(Keys.Down))
            {
                nextItem();
            }

            // Handle selection of menu item with Enter or Right key
            if ((state.IsKeyDown(Keys.Enter) && !previousState.IsKeyDown(Keys.Enter)) || (state.IsKeyDown(Keys.Right) && !previousState.IsKeyDown(Keys.Right)))
            {
                selectItem();
            }

            // Escape key changes to GameOver screen (for testing, will change to Exit later)
            if (state.IsKeyDown(Keys.Escape) && !previousState.IsKeyDown(Keys.Escape))
            {
                screenManager.ChangeState(GameState.GameOver);
            }

            // Update previousState for the next frame
            previousState = state;
        }

        private void drawCursor()
        {
            // Draws the cursor at the currently selected menu item
            spriteBatch.Draw(cursor, new Vector2(ScreenSize.Width / 2 - ScreenConstants.CursorOffsetX, menuItems.ElementAt(cursorLocation).Value), Color.White);
        }

        private void nextItem()
        {
            // Move the cursor down to the next menu item
            cursorLocation++;
            if (cursorLocation >= menuItems.Count)
            {
                cursorLocation = 0; // Wrap to first item if at end
            }
        }

        private void backItem()
        {
            // Move the cursor up to the previous menu item
            cursorLocation--;
            if (cursorLocation < 0)
            {
                cursorLocation = menuItems.Count - 1; // Wrap to last item if at beginning
            }
        }

        private void selectItem()
        {
            // Select the menu item based on cursor position
            switch (cursorLocation)
            {
                case 0: // "1 Player"
                    // Switch to the game screen for single-player mode
                    Game1.Instance.setLevel(GameConstants.levelOne);
                    screenManager.ChangeState(GameState.GameRunning);
                    break;
                case 1: // "2 Player"
                    // Switch to the game screen for two-player mode
                    Game1.Instance.setLevel(GameConstants.levelOne);
                    screenManager.ChangeState(GameState.Multiplayer);
                    break;
                case 2: // "Exit Game"
                    // Exit the game
                    screenManager.ChangeState(GameState.Exiting);
                    break;
            }
        }
    }
}
