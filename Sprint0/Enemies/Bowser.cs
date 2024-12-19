using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.BowserStates;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class Bowser : IEnemy, IGameObject, ICollidable
    {
        private Vector2 bowserPos;
        private ISprite bowserSprite;
        private bool isLeft = true;
        private bool prevDir;
        private double switchTimer = 0;
        private double timeMax = 4000;

        private double dirTimer = 0;
        private double dirTimeMax = 2000;

        private bool walkLeft = true;

        private IEnemyBehaviorState bowserState;

        public Bowser(Vector2 bowserPos)
        {
            this.bowserPos = bowserPos;
            this.bowserSprite = SpriteFactory.Instance.getSpriteById("LeftBowser", 150.0f);
            this.bowserState = new BowserIdle();
            this.prevDir = isLeft;
        }

        public bool IsAlive => true;

        public void Die()
        {
            // Bowser does not die yet.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bowserSprite.Draw(spriteBatch, bowserPos);
        }

        public string GetCollisionClass()
        {
            return "unkillableEnemy";
        }

        public Rectangle GetHitBox()
        {
            return bowserSprite.GetDestinationRectangle(bowserPos);
        }

        public bool isMover()
        {
            return true;
        }

        public void Update(GameTime gameTime)
        {
            bowserSprite.Update(gameTime);
            bowserState.Update(gameTime);

            // Bandaid solution fix later
            dirTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if(dirTimer > dirTimeMax)
            {
                dirTimer = 0;
                walkLeft = !walkLeft;
            }

            isLeft = Game1.Instance.GetLevel().GetPlayers()[0].CurrentPosition.X < bowserPos.X;

            if(isLeft != prevDir)
            {
                prevDir = isLeft;
                if (isLeft)
                {
                    bowserSprite = SpriteFactory.Instance.getSpriteById("LeftBowser", 150.0f);
                }
                else
                {
                    bowserSprite = SpriteFactory.Instance.getSpriteById("RightBowser", 150.0f);
                }
            }

            

            if (walkLeft)
            {
                bowserPos.X -= 0.25f;
            } else
            {
                bowserPos.X += 0.25f;
            }

            switchTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if(switchTimer > timeMax)
            {
                switchTimer = 0;
                if (bowserState is BowserIdle) bowserState = new BowserFireState(this);
                else bowserState = new BowserIdle();
            }
        }

        public void changePos(Vector2 posOffset)
        {
            bowserPos += posOffset;
        }

        public Vector2 getPos()
        {
            return bowserPos;
        }

        public bool getDir()
        {
            return isLeft;
        }
    }
}
