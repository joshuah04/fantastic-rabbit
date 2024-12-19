using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Blocks
{
    public class SolidBlock : IBlock, IGameObject, ICollidable
    {
        private ISprite solidBlockSprite;
        private Vector2 solidBlockPosition;
        public bool IsAlive { get; private set; }

        public SolidBlock(Vector2 position)
        {
            this.solidBlockPosition = position;
            this.solidBlockSprite = SpriteFactory.Instance.getSpriteById("SolidBlock", BlockConstants.AnimationDelay);
            IsAlive = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            solidBlockSprite.Draw(spriteBatch, this.solidBlockPosition);
        }

        public void Update(GameTime gameTime)
        {
            solidBlockSprite.Update(gameTime);
        }

        public Rectangle GetHitBox()
        {
            return solidBlockSprite.GetDestinationRectangle(solidBlockPosition);
        }
        public string GetCollisionClass()
        {
            return "block";
        }
        public void Die()
        {

        }
        public Boolean isMover()
        {
            return false;
        }
    }
}