using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Levels;
using Sprint0.Constants;
using System;

namespace Sprint0.Blocks
{
    public class BrickBlockDebris : IBlock, IGameObject
    {
        private ISprite brickDebrisSprite;
        private Vector2 brickDebrisPosition;
        public bool IsAlive { get; private set; }
        private Vector2[] debrisPositions = new Vector2[4];
        private Vector2[] debrisVelocities = new Vector2[4];
        private int timer;
        private float gravity;

        public BrickBlockDebris(Vector2 position, int timer = BlockConstants.DebrisTimerDefault,
                                float velocity = BlockConstants.DebrisVelocityDefault,
                                float gravity = BlockConstants.DebrisGravity)
        {
            this.brickDebrisPosition = position;
            this.brickDebrisSprite = SpriteFactory.Instance.getSpriteById("BrickDebris", BlockConstants.AnimationDelay);
            IsAlive = true;
            this.timer = timer;
            this.gravity = gravity;

            debrisPositions[0] = new Vector2(brickDebrisPosition.X, brickDebrisPosition.Y);                          // top left
            debrisPositions[1] = new Vector2(brickDebrisPosition.X, brickDebrisPosition.Y + BlockConstants.DebrisPositionOffset);   // bottom left
            debrisPositions[2] = new Vector2(brickDebrisPosition.X + BlockConstants.DebrisPositionOffset, brickDebrisPosition.Y);   // top right
            debrisPositions[3] = new Vector2(brickDebrisPosition.X + BlockConstants.DebrisPositionOffset, brickDebrisPosition.Y + BlockConstants.DebrisPositionOffset); // bottom right

            // set velocities to make debris move outward
            debrisVelocities[0] = new Vector2(-velocity, -velocity);
            debrisVelocities[1] = new Vector2(-velocity, -velocity);
            debrisVelocities[2] = new Vector2(velocity, -velocity);
            debrisVelocities[3] = new Vector2(velocity, -velocity);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < debrisPositions.Length; i++)
            {
                brickDebrisSprite.Draw(spriteBatch, debrisPositions[i]);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (timer > 0)
            {
                timer--;
            }
            else
            {
                GameObjectManager.Instance.RemoveGameObject(this);
            }
            for (int i = 0; i < debrisPositions.Length; i++)
            {
                debrisVelocities[i].Y += gravity;
                debrisPositions[i] += debrisVelocities[i];
            }
            brickDebrisSprite.Update(gameTime);
        }

        public Rectangle GetHitBox()
        {
            return brickDebrisSprite.GetDestinationRectangle(brickDebrisPosition);
        }

        public string GetCollisionClass()
        {
            return "";
        }

        public void Die()
        {
            IsAlive = false;
        }

        public Boolean isMover()
        {
            return false;
        }
    }
}
