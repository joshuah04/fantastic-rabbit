using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Blocks
{
    public class GroundBlock : IBlock, IGameObject, ICollidable
    {
        private ISprite groundBlockSprite;
        private Vector2 groundBlockPosition;
        public bool IsAlive { get; private set; }

        public GroundBlock(Vector2 position, String texture)
        {
            this.groundBlockPosition = position;
            this.groundBlockSprite = SpriteFactory.Instance.getSpriteById(texture, BlockConstants.AnimationDelay);
            IsAlive = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            groundBlockSprite.Draw(spriteBatch, groundBlockPosition);
        }

        public void Update(GameTime gameTime)
        {
            groundBlockSprite.Update(gameTime);
        }

        public Rectangle GetHitBox()
        {
            return groundBlockSprite.GetDestinationRectangle(groundBlockPosition);
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
