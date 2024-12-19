using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Joshua Han
namespace Sprint0
{
    public interface IBlock
    {
        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);
    }
}
