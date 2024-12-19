using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Sprint0.Constants;

namespace Sprint0
{
    public class EndGameScreen : Screen
    {
        private ScreenManager screenManager; // Reference to ScreenManager to handle screen switching
        private Texture2D gameover; // Texture for the game over screen
        private KeyboardState state; // Current keyboard state
        private KeyboardState previousState; // Previous keyboard state for detecting single key presses
        private SpriteFont font; // Font used to display messages on the screen

        // Constructor initializes screen manager and sets the previous state
        public EndGameScreen(Rectangle screenSize, ScreenManager screenManager) : base(screenSize)
        {
            this.screenManager = screenManager;
            previousState = Keyboard.GetState();
        }

        public override void LoadContent(ContentManager content)
        {
            // Load game-related content
            gameover = content.Load<Texture2D>(ScreenConstants.GameOverTexturePath);
            font = content.Load<SpriteFont>(ScreenConstants.FontPath);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw game objects
            spriteBatch.Begin();
            spriteBatch.DrawString(font, ScreenConstants.ReturnMessage, new Vector2(ScreenSize.Width / 2 - ScreenConstants.ReturnMessageOffsetX, ScreenConstants.ReturnMessagePositionY), Color.White);
            spriteBatch.Draw(gameover, new Vector2(ScreenSize.Width / 2 - gameover.Width / 2, ScreenConstants.GameOverImageOffsetY), Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            // Update game logic by checking for key press to return to the main menu
            state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space))
            {
                screenManager.ChangeState(GameState.MainMenu);
                Game1.Instance.reset();
            }

            // Update previousState for the next frame
            previousState = state;
        }
    }
}
