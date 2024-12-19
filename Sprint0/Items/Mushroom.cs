using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Items
{
    internal class Mushroom : IItem, ICollidable, IGameObject
    {
        private ISprite mushroomSprite;
        private Vector2 mushroomPosition;
        public bool IsAlive { get; private set; }
        public bool isBouncing { get; private set; }
        private float bounceHeight = ItemConstants.BounceHeight;
        private float bounceSpeed = ItemConstants.BounceSpeed;
        private float bounceOffset = ItemConstants.BounceOffsetInitial;
        private bool isAffectedByGravity = false;
        private bool isWalking = false;
        private float gravity = ItemConstants.Gravity;
        private float verticalVelocity = 0f;
        private float horizontalVelocity = ItemConstants.HorizontalVelocity;
        private bool initialBounceDone = false; // Flag to track if the initial bounce is completed

        public Mushroom(Vector2 position)
        {
            // Sets the initial position and sprite for the mushroom
            mushroomPosition = position;
            mushroomSprite = SpriteFactory.Instance.getSpriteById("Mushroom", ItemConstants.AnimationDelay);
            IsAlive = true;
            isBouncing = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draws the mushroom sprite if it is alive
            if (IsAlive)
            {
                mushroomSprite.Draw(spriteBatch, mushroomPosition);
            }
        }

        public void Update(GameTime gameTime)
        {
            // Updates the mushroom's state and movement if it is alive
            if (IsAlive)
            {
                mushroomSprite.Update(gameTime);

                // Apply bounce, gravity, and walking conditions
                if (isBouncing)
                {
                    Bounce();
                }
                else if (isAffectedByGravity)
                {
                    ApplyGravity();

                    if (!isWalking)
                    {
                        isWalking = true;
                        Console.WriteLine("Walking activated.");
                    }
                }

                // Apply horizontal movement if walking
                if (isWalking)
                {
                    Walk();
                }
            }
        }

        public void Die()
        {
            // Sets the mushroom to be no longer alive
            IsAlive = false;
            Game1.Instance.GetLevel().RemoveGameObject(this); // remove the coin when picked up
        }

        public Rectangle GetHitBox()
        {
            // Returns the hitbox of the mushroom for collision detection
            return mushroomSprite.GetDestinationRectangle(mushroomPosition);
        }

        public string GetCollisionClass()
        {
            // Returns the collision class of the mushroom
            return "mushroom";
        }

        public bool isMover()
        {
            // Indicates that the mushroom can move
            return true;
        }

        public void StartBounce()
        {
            // Starts the bounce action for the mushroom if it hasn't bounced yet
            if (!initialBounceDone)
            {
                isBouncing = true;
                isAffectedByGravity = false; // Disable gravity during bounce
                bounceOffset = ItemConstants.BounceOffsetInitial;
                verticalVelocity = 0f;
            }
        }

        public void SetVerticalBouncePosition(int offset)
        {
            // Sets the vertical position for the bounce effect
            mushroomPosition = new Vector2(mushroomPosition.X, mushroomPosition.Y + offset);
        }

        private void Bounce()
        {
            // Handles the bounce movement up to a certain height
            if (bounceOffset < bounceHeight)
            {
                mushroomPosition.Y -= bounceSpeed;
                bounceOffset++;
            }
            else
            {
                // Stops bouncing and enables gravity
                isBouncing = false;
                isAffectedByGravity = true;
            }
        }

        private void ApplyGravity()
        {
            // Applies gravity to the mushroom's vertical movement
            verticalVelocity += gravity;
            mushroomPosition.Y += verticalVelocity;

            // Limits the vertical fall speed
            if (verticalVelocity > ItemConstants.MaxVerticalVelocity)
                verticalVelocity = ItemConstants.MaxVerticalVelocity;
        }

        private void Walk()
        {
            // Moves the mushroom horizontally in its current direction
            mushroomPosition.X += horizontalVelocity;
        }

        public void ReverseDirection()
        {
            // Reverses the horizontal direction of movement
            horizontalVelocity = -horizontalVelocity;
        }
    }
}
