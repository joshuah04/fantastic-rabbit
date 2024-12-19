using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class Screen
    {
        protected Rectangle ScreenSize;

        // Constructor to initialize the screen size
        public Screen(Rectangle screenSize)
        {
            this.ScreenSize = screenSize;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Default implementation does nothing, derived classes will override this
        }

        public virtual void Update(GameTime gameTime)
        {
            // Default implementation does nothing, derived classes will override this
        }

        public virtual void Initialize()
        {
            // Derived classes can override this method for additional initialization logic
        }

        public virtual void LoadContent(ContentManager content)
        {
            // Derived classes can override this to load assets
        }
    }
}