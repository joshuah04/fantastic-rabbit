using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public interface IState
    {

        /* Draws the sprite at a specified location */
        public void Draw(SpriteBatch spriteBatch, Vector2 location);

		public void Update(GameTime gameTime);


		
	}
}
