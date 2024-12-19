using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Constants;
using Sprint0.Sound;

namespace Sprint0.Items
{
    internal class StarPower : IItem, ICollidable, IGameObject
    {
        private ISprite starPowerSprite;
        private Vector2 starPowerPosition;
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

        public StarPower(Vector2 position)
        {
            // Initializes the StarPower's position and sprite
            starPowerPosition = position;
            starPowerSprite = SpriteFactory.Instance.getSpriteById("StarPower", ItemConstants.AnimationDelay);
            IsAlive = true;
            isBouncing = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draws the StarPower if it is alive
            if (IsAlive)
            {
                starPowerSprite.Draw(spriteBatch, starPowerPosition);
            }
        }

        public void Update(GameTime gameTime)
        {
            // Updates the StarPower's animation, bounce, and movement behavior if it is alive
            if (IsAlive)
            {
                starPowerSprite.Update(gameTime);

                if (isBouncing)
                {
                    Bounce();
                }
                else if (isAffectedByGravity)
                {
                    ApplyGravity();

                    // Start walking only after gravity has set in
                    if (!isWalking)
                    {
                        isWalking = true;
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
            // Sets the StarPower to be no longer alive
            IsAlive = false;
            Game1.Instance.GetLevel().RemoveGameObject(this); // remove the coin when picked up
        }

        public Rectangle GetHitBox()
        {
            // Returns the hitbox of the StarPower for collision detection
            return starPowerSprite.GetDestinationRectangle(starPowerPosition);
        }

        public string GetCollisionClass()
        {
            // Returns the collision class of the StarPower
            return "star";
        }

        public bool isMover()
        {
            // Indicates that the StarPower is a movable object
            return true;
        }

        public void StartBounce()
        {
            // Starts the bounce action for the StarPower
            isBouncing = true;
            isAffectedByGravity = false;
            bounceOffset = ItemConstants.BounceOffsetInitial;
            verticalVelocity = 0f;
        }

        public void SetVerticalBouncePosition(int offset)
        {
            // Adjusts the vertical position of the StarPower for bouncing
            starPowerPosition = new Vector2(starPowerPosition.X, starPowerPosition.Y + offset);
        }

        private void Bounce()
        {
            // Handles the bounce movement up to a certain height
            if (bounceOffset < bounceHeight)
            {
                starPowerPosition.Y -= bounceSpeed;
                bounceOffset++;
            }
            else
            {
                // Finish bounce and enable gravity
                isBouncing = false;
                isAffectedByGravity = true;
            }
        }

        private void ApplyGravity()
        {
            // Applies gravity to the StarPower
            verticalVelocity += gravity;
            starPowerPosition.Y += verticalVelocity;

            // Optional: limit fall speed
            if (verticalVelocity > ItemConstants.MaxVerticalVelocity)
                verticalVelocity = ItemConstants.MaxVerticalVelocity;
        }

        private void Walk()
        {
            // Moves the StarPower horizontally
            starPowerPosition.X += horizontalVelocity;
        }

        public void ReverseDirection()
        {
            // Reverses the horizontal movement direction of the StarPower
            horizontalVelocity = -horizontalVelocity;
        }
    }
}
