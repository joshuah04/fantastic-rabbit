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
    public class Lava : IBlock, IGameObject, ICollidable
    {
        private Vector2 lavaPos;
        private ISprite lavaSprite;
        public Lava(Vector2 pos)
        {
            lavaPos = pos;
            lavaSprite = SpriteFactory.Instance.getSpriteById("Lava", 150.0f);
        }

        public bool IsAlive => false;

        public void Die()
        {
            // Lava does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            lavaSprite.Draw(spriteBatch, lavaPos);
        }

        public string GetCollisionClass()
        {
            // TODO: Change this to Lava
            return "unkillableEnemy";
        }

        public Rectangle GetHitBox()
        {
            return lavaSprite.GetDestinationRectangle(lavaPos);
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            lavaSprite.Update(gameTime);
        }
    }
}
