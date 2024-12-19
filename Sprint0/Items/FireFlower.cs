using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using Sprint0.Constants;

namespace Sprint0.Items
{
    internal class FireFlower : IItem, ICollidable, IGameObject
    {
        private ISprite fireFlowerSprite;
        private Vector2 fireFlowerPosition;
        public bool IsAlive { get; private set; }
        private float bounceHeight = ItemConstants.BounceHeight;
        private float bounceSpeed = ItemConstants.BounceSpeed;
        private float bounceOffset = ItemConstants.BounceOffsetInitial;
        public bool isBouncing { get; private set; }

        public FireFlower(Vector2 position)
        {
            // Initializes the FireFlower position and sprite
            fireFlowerPosition = position;
            fireFlowerSprite = SpriteFactory.Instance.getSpriteById("FireFlower", ItemConstants.AnimationDelay);
            IsAlive = true;
            isBouncing = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draws the FireFlower if it is alive
            if (IsAlive)
            {
                fireFlowerSprite.Draw(spriteBatch, fireFlowerPosition);
            }
        }

        public void Update(GameTime gameTime)
        {
            // Updates the FireFlower's animation and bounce behavior if it is alive
            if (IsAlive)
            {
                fireFlowerSprite.Update(gameTime);
                if (isBouncing)
                {
                    Bounce();
                }
            }
        }

        public void Die()
        {
            // Sets the FireFlower to be no longer alive
            IsAlive = false;
            Game1.Instance.GetLevel().RemoveObjQueue(this); // remove the coin when picked up
        }

        public Rectangle GetHitBox()
        {
            // Returns the hitbox of the FireFlower for collision detection
            return fireFlowerSprite.GetDestinationRectangle(fireFlowerPosition);
        }

        public string GetCollisionClass()
        {
            // Returns the collision class of the FireFlower
            return "fireflower";
        }

        public Boolean isMover()
        {
            // Indicates that the FireFlower is not a movable object
            return false;
        }

        public void StartBounce()
        {
            // Starts the bounce action for the FireFlower
            isBouncing = true;
            bounceOffset = ItemConstants.BounceOffsetInitial;
        }

        public void Bounce()
        {
            // Handles the bounce movement up to a certain height
            if (bounceOffset < bounceHeight)
            {
                fireFlowerPosition.Y -= bounceSpeed;
                bounceOffset++;
            }
            else
            {
                // Stops the bouncing action
                isBouncing = false;
            }
        }

        public void ReverseDirection()
        {
            // No implementation required for FireFlower
        }

        public void SetVerticalBouncePosition(int offset)
        {
            // No implementation required for FireFlower
        }
    }
}
