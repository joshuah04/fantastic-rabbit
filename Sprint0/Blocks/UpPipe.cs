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
    public class UpPipe : IBlock, IGameObject, ICollidable
    {
        private Vector2 upPipePos;
        private ISprite upPipeSprite;
        public UpPipe(Vector2 pos, string texture) 
        { 
            this.upPipePos = pos;
            this.upPipeSprite = SpriteFactory.Instance.getSpriteById(texture, 150.0f);
        }

        public UpPipe(Vector2 pos, string texture, string warp)
        {
            this.upPipePos = pos;
            this.upPipeSprite = SpriteFactory.Instance.getSpriteById(texture, BlockConstants.AnimationDelay);

            // Create a new Warp Object and add it to the level
            Vector2 warpPosition = this.upPipePos + new Vector2(CollisionConstants.WARP_DOWN_X_OFFSET, CollisionConstants.WARP_DOWN_Y_OFFSET);
            Game1.Instance.GetLevel().AddGameObject(new WarpZone(warpPosition, warp, CollisionConstants.DOWN_WARP_TYPE));
        }

        public bool IsAlive => false;

        public void Die()
        {
            // UpPipe does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            upPipeSprite.Draw(spriteBatch, this.upPipePos);
        }

        public string GetCollisionClass()
        {
            return "block";
        }

        public Rectangle GetHitBox()
        {
            return upPipeSprite.GetDestinationRectangle(upPipePos);
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            upPipeSprite.Update(gameTime);
        }
    }
}
