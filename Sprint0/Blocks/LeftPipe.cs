using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Blocks
{
    public class LeftPipe : IGameObject, IBlock, ICollidable
    {
        private Vector2 leftPipePosition;
        private ISprite leftPipeSprite;

        public LeftPipe(Vector2 pos) 
        {
            this.leftPipePosition = pos;
            this.leftPipeSprite = SpriteFactory.Instance.getSpriteById("LeftPipe", 150.0f);
        }

        public LeftPipe(Vector2 pos, string warp)
        {
            this.leftPipePosition = pos;
            this.leftPipeSprite = SpriteFactory.Instance.getSpriteById("LeftPipe", 150.0f);

            Vector2 warpPosition = this.leftPipePosition + new Vector2(CollisionConstants.WARP_LEFT_X_OFFSET, CollisionConstants.WARP_LEFT_Y_OFFSET);
            Game1.Instance.GetLevel().AddGameObject(new WarpZone(warpPosition, warp, CollisionConstants.LEFT_WARP_TYPE));
        }

        public bool IsAlive => throw new NotImplementedException();

        public void Die()
        {
            // Warp Pipe does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            leftPipeSprite.Draw(spriteBatch, leftPipePosition);
        }

        public string GetCollisionClass()
        {
            return "block";
        }

        public Rectangle GetHitBox()
        {
            return leftPipeSprite.GetDestinationRectangle(leftPipePosition);
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            leftPipeSprite.Update(gameTime);
        }
    }
}
