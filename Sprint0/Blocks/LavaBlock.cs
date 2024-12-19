using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Blocks
{
    public class LavaBlock : IGameObject, IBlock, ICollidable
    {
        private Vector2 lavaBlockPos;
        private ISprite lavaBlockSprite;

        public LavaBlock(Vector2 pos)
        {
            this.lavaBlockPos = pos;
            this.lavaBlockSprite = SpriteFactory.Instance.getSpriteById("LavaBlock", 150.0f);
        }

        public bool IsAlive => false;

        public void Die()
        {
            // Lava Block does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            lavaBlockSprite.Draw(spriteBatch, this.lavaBlockPos);
        }

        public string GetCollisionClass()
        {
            return "Lava";
        }

        public Rectangle GetHitBox()
        {
            return lavaBlockSprite.GetDestinationRectangle(lavaBlockPos);
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            lavaBlockSprite.Update(gameTime);
        }
    }
}
