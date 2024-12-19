using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Blocks
{
    public class LargePipe : IBlock, IGameObject, ICollidable
    {
        private ISprite largePipeSprite;
        private Vector2 largePipePosition;
        public bool IsAlive { get; private set; }

        public LargePipe(Vector2 pos)
        {
            this.largePipePosition = pos;
            this.largePipeSprite = SpriteFactory.Instance.getSpriteById("LargePipe", BlockConstants.AnimationDelay);
            IsAlive = true;
        }

        public LargePipe(Vector2 pos, string warp)
        {
            this.largePipePosition = pos;
            this.largePipeSprite = SpriteFactory.Instance.getSpriteById("LargePipe", BlockConstants.AnimationDelay);

            // Create a new Warp Object and add it to the level
            Vector2 warpPosition = this.largePipePosition + new Vector2(CollisionConstants.WARP_DOWN_X_OFFSET, CollisionConstants.WARP_DOWN_Y_OFFSET);
            WarpZone warpZone = new WarpZone(warpPosition, warp, CollisionConstants.DOWN_WARP_TYPE);
            Game1.Instance.GetLevel().AddGameObject(warpZone);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            largePipeSprite.Draw(spriteBatch, largePipePosition);
        }

        public void Update(GameTime gameTime)
        {
            largePipeSprite.Update(gameTime);
        }

        public Rectangle GetHitBox()
        {
            return largePipeSprite.GetDestinationRectangle(largePipePosition);
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