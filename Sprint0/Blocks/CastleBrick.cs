using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Blocks
{
    public class CastleBrick : IBlock, IGameObject, ICollidable 
    {
        private Vector2 brickPos;
        private ISprite castleBrickSprite;
        public CastleBrick(Vector2 pos) 
        {
            this.brickPos = pos;
            this.castleBrickSprite = SpriteFactory.Instance.getSpriteById("CastleBrick", 150.0f);
        }

        public bool IsAlive => false;

        public void Die()
        {
            // Castle Brick does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            castleBrickSprite.Draw(spriteBatch, this.brickPos);
        }

        public string GetCollisionClass()
        {
            return "block";
        }

        public Rectangle GetHitBox()
        {
            return castleBrickSprite.GetDestinationRectangle(brickPos);
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            castleBrickSprite.Update(gameTime);
        }
    }
}
