using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Constants;


namespace Sprint0.Items
{
    public class OneUp : IItem, ICollidable, IGameObject
    {
        private ISprite oneUpSprite;
        private Vector2 oneUpPosition;
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

        public OneUp(Vector2 position)
        {
            // Initializes the OneUp position and sprite
            oneUpPosition = position;
            oneUpSprite = SpriteFactory.Instance.getSpriteById("OneUp", ItemConstants.AnimationDelay);
            IsAlive = true;
            isBouncing = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draws the OneUp if it is alive
            if (IsAlive)
            {
                oneUpSprite.Draw(spriteBatch, oneUpPosition);
            }
        }

        public void Update(GameTime gameTime)
        {
            // Updates the OneUp's animation and bounce behavior if it is alive
            if (IsAlive)
            {
                oneUpSprite.Update(gameTime);

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
            // Sets the OneUp to be no longer alive
            IsAlive = false;
            Game1.Instance.GetLevel().RemoveGameObject(this); // remove the object when picked up
            Game1.Instance.GetScoreScreen().OneUp(); //adds 1 life to player
        }

        public Rectangle GetHitBox()
        {
            // Returns the hitbox of the OneUp for collision detection
            return oneUpSprite.GetDestinationRectangle(oneUpPosition);
        }

        public string GetCollisionClass()
        {
            // Returns the collision class of the OneUp
            return "oneup";
        }

        public bool isMover()
        {
            // Indicates that the OneUp is a movable object
            return true;
        }

        public void StartBounce()
        {
            // Starts the bounce action for the OneUp
            isBouncing = true;
            isAffectedByGravity = false;
            bounceOffset = ItemConstants.BounceOffsetInitial;
            verticalVelocity = 0f;
        }

        public void SetVerticalBouncePosition(int offset)
        {
            // Adjusts the vertical position of the OneUp for bouncing
            oneUpPosition.Y += offset;
        }

        private void Bounce()
        {
            // Handles the bounce movement up to a certain height
            if (bounceOffset < bounceHeight)
            {
                oneUpPosition.Y -= bounceSpeed;
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
            // Applies gravity to the OneUp
            verticalVelocity += gravity;
            oneUpPosition.Y += verticalVelocity;

            // Optional: limit fall speed
            if (verticalVelocity > ItemConstants.MaxVerticalVelocity)
                verticalVelocity = ItemConstants.MaxVerticalVelocity;
        }

        private void Walk()
        {
            // Moves the OneUp horizontally
            oneUpPosition.X += horizontalVelocity;
        }

        public void ReverseDirection()
        {
            // Reverses the horizontal movement direction of the OneUp
            horizontalVelocity = -horizontalVelocity;
        }
    }
}
