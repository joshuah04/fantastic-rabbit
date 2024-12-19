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
    public class Bridge : IGameObject, IBlock, ICollidable
    {
        private Vector2 bridgePosition;
        private ISprite bridgeSprite;

        public Bridge(Vector2 pos)
        {
            bridgePosition = pos;
            bridgeSprite = SpriteFactory.Instance.getSpriteById("Bridge", 150.0f);
        }

        public bool IsAlive => true;

        public void Die()
        {
            // Bridge does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bridgeSprite.Draw(spriteBatch, bridgePosition);
        }

        public string GetCollisionClass()
        {
            return "block";
        }

        public Rectangle GetHitBox()
        {
            return bridgeSprite.GetDestinationRectangle(bridgePosition);
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            bridgeSprite.Update(gameTime);
        }
    }
}
