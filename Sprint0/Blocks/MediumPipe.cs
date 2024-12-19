using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Blocks
{
    public class MediumPipe : IBlock, IGameObject, ICollidable
    {
        private ISprite mediumPipeSprite;
        private Vector2 mediumPipePosition;
        public bool IsAlive { get; private set; }

        public MediumPipe(Vector2 pos)
        {
            this.mediumPipePosition = pos;
            this.mediumPipeSprite = SpriteFactory.Instance.getSpriteById("MediumPipe", BlockConstants.AnimationDelay);
            IsAlive = true;
        }

        public MediumPipe(Vector2 pos, string warp)
        {
            this.mediumPipePosition = pos;
            this.mediumPipeSprite = SpriteFactory.Instance.getSpriteById("MediumPipe", BlockConstants.AnimationDelay);

            // Create a new Warp Object and add it to the level
            Vector2 warpPosition = this.mediumPipePosition + new Vector2(CollisionConstants.WARP_DOWN_X_OFFSET, CollisionConstants.WARP_DOWN_Y_OFFSET);
            Game1.Instance.GetLevel().AddGameObject(new WarpZone(warpPosition, warp, CollisionConstants.DOWN_WARP_TYPE));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mediumPipeSprite.Draw(spriteBatch, mediumPipePosition);
        }

        public void Update(GameTime gameTime)
        {
            mediumPipeSprite.Update(gameTime);
        }

        public Rectangle GetHitBox()
        {
            return mediumPipeSprite.GetDestinationRectangle(mediumPipePosition);
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