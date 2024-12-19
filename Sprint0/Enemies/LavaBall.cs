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
    public class LavaBall : IEnemy, IGameObject, ICollidable
    {
        private Vector2 lavaBallPos;
        private ISprite lavaBallSprite;

        private float yVel = 0;
        private double gravity = 1.0 / 1000;

        private double dormantTimer = 0;
        private double dormantTime = 1500;
        private bool dormant = false;

        private float lavaBallLowestPos;
        public LavaBall(Vector2 pos)
        {
            this.lavaBallPos = pos;
            this.lavaBallSprite = SpriteFactory.Instance.getSpriteById("UpLavaBall", 150.0f);
            this.lavaBallLowestPos = pos.Y + 32;
        }

        public bool IsAlive => true;

        public void Die()
        {
            // LavaBall does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            lavaBallSprite.Draw(spriteBatch, lavaBallPos);
        }

        public string GetCollisionClass()
        {
            return "unkillableEnemy";
        }

        public Rectangle GetHitBox()
        {
            return lavaBallSprite.GetDestinationRectangle(lavaBallPos);
        }

        public bool isMover()
        {
            return true;
        }

        public void Update(GameTime gameTime)
        {

            if (dormant)
            {
                dormantTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (dormantTimer > dormantTime)
                {
                    dormant = false;
                    yVel = -0.5f;
                }
            }
            else
            {
                // LavaBall affected by Gravity
                yVel = yVel + (float)(gravity * gameTime.ElapsedGameTime.TotalMilliseconds);

                if (yVel < 0)
                {
                    lavaBallSprite = SpriteFactory.Instance.getSpriteById("UpLavaBall", 150.0f);
                }
                else
                {
                    lavaBallSprite = SpriteFactory.Instance.getSpriteById("DownLavaBall", 150.0f);
                }

                lavaBallPos.Y += (yVel * (float)gameTime.ElapsedGameTime.TotalMilliseconds);

                if (lavaBallPos.Y > lavaBallLowestPos)
                {
                    dormantTimer = 0;
                    dormant = true;
                }
            }
        }
    }
}
