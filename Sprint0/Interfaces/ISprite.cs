using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public interface ISprite
    {
        /* May update the frame or position of a sprite */
        public void Update(GameTime gameTime);
        /* Draws the sprite at a specified location */
        public void Draw(SpriteBatch spriteBatch, Vector2 location);

        public Rectangle GetDestinationRectangle(Vector2 location);
        public int Width { get; }

        public int Height { get; }
    }
}
