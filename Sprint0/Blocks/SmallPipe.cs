using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Blocks
{
    public class SmallPipe : IBlock, IGameObject, ICollidable
    {
        private ISprite smallPipeSprite;
        private Vector2 smallPipePosition;
        public bool IsAlive { get; private set; }

        public SmallPipe(Vector2 position)
        {
            this.smallPipePosition = position;
            this.smallPipeSprite = SpriteFactory.Instance.getSpriteById("SmallPipe", BlockConstants.AnimationDelay);
            IsAlive = true;
        }

        public SmallPipe(Vector2 position, string warp)
        {
            this.smallPipePosition = position;
            this.smallPipeSprite = SpriteFactory.Instance.getSpriteById("SmallPipe", BlockConstants.AnimationDelay);

            // Create a new Warp Object and add it to the level
            Vector2 warpPosition = this.smallPipePosition + new Vector2(CollisionConstants.WARP_DOWN_X_OFFSET, CollisionConstants.WARP_DOWN_Y_OFFSET);
            Game1.Instance.GetLevel().AddGameObject(new WarpZone(warpPosition, warp, CollisionConstants.DOWN_WARP_TYPE));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            smallPipeSprite.Draw(spriteBatch, smallPipePosition);
        }

        public void Update(GameTime gameTime)
        {
            smallPipeSprite.Update(gameTime);
        }

        public Rectangle GetHitBox()
        {
            return smallPipeSprite.GetDestinationRectangle(smallPipePosition);
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