using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class BowserFire : IGameObject, ICollidable
    {
        private Vector2 firePos;
        private ISprite fireSprite;
        private bool isLeft;
        private Vector2 initPos;

        public BowserFire(Vector2 firePos, bool isLeft)
        {
            this.firePos = firePos;
            this.isLeft = isLeft;
            if(isLeft)
            {
                this.fireSprite = SpriteFactory.Instance.getSpriteById("LeftBowserFire", 150.0f);
            } else
            {
                this.fireSprite = SpriteFactory.Instance.getSpriteById("RightBowserFire", 150.0f);
            }
            
            this.initPos = firePos;
        }


        public bool IsAlive => true;

        public void Die()
        {
            // BowserFire does not die.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireSprite.Draw(spriteBatch, firePos);
        }

        public string GetCollisionClass()
        {
            return "unkillableEnemy";
        }

        public Rectangle GetHitBox()
        {
            return fireSprite.GetDestinationRectangle(firePos);
        }

        public bool isMover()
        {
            return true;
        }

        public void Update(GameTime gameTime)
        {
            fireSprite.Update(gameTime);
            if(isLeft)
            {
                firePos.X -= 1;
                if (initPos.X - firePos.X > 200) removeMe();
            } else
            {
                firePos.X += 1;
                if (firePos.X - initPos.X > 200) removeMe();
            }
        }

        private void removeMe()
        {
            Game1.Instance.GetLevel().RemoveObjQueue(this);
        }
    }
}
