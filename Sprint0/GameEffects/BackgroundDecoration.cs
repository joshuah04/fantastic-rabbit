using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.GameEffects
{
    public class BackgroundDecoration : IGameObject
    {
        private ISprite backgroundDecorSprite;
        private Vector2 backgroundDecorPosition;

        public BackgroundDecoration(Vector2 backgroundDecorPosition, string sprite)
        {
            this.backgroundDecorPosition = backgroundDecorPosition;
            this.backgroundDecorSprite = SpriteFactory.Instance.getSpriteById(sprite, 150.0f);
        }

        public bool IsAlive => true;

        public void Die()
        {
            // backgroundDecorations do not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundDecorSprite.Draw(spriteBatch, backgroundDecorPosition);
        }

        public void Update(GameTime gameTime)
        {
            backgroundDecorSprite.Update(gameTime);
        }
    }
}
