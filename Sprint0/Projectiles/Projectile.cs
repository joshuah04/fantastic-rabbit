// Author: Bladen Siu
// This class will produce singular projectiles
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;
using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0
{
    public class Projectile : IProjectile
    {
        private float timeAlive; // Tracks how long the projectile has been active
        private Vector2 velocity; // Velocity of the projectile
        private Vector2 position; // Current position of the projectile
        private float maxTimeAlive; // Maximum time the projectile can be alive
        private ISprite projectileSprite; // Sprite associated with the projectile
        public bool hitFloor; //will keep track if gravity is applied or not

        // Determines if the projectile is still active
        public bool IsAlive => timeAlive < maxTimeAlive;

        // Current position of the projectile
        public Vector2 Position => position;

        // Current velocity of the projectile
        public Vector2 Velocity => velocity;


        public Projectile(Vector2 position, IPlayerDirectionState directionState, float maxTimeAlive)
        {
            // Initializes projectile properties
            this.projectileSprite = SpriteFactory.Instance.getSpriteById("Fireball", ProjectileConstants.AnimationDelay);
            this.position = position;
            this.maxTimeAlive = maxTimeAlive;
            this.timeAlive = ProjectileConstants.InitialTimeAlive;
            this.velocity = GetVelocityFromDirection(directionState);
            this.hitFloor = false;
        }

        private static readonly Dictionary<string, Vector2> directionVelocity = new Dictionary<string, Vector2>()
        {
            // Assigns velocity based on direction state
            {"Right", new Vector2(ProjectileConstants.FriendlySpeed, ProjectileConstants.InitialTimeAlive) },
            {"Left", new Vector2(-ProjectileConstants.FriendlySpeed, ProjectileConstants.InitialTimeAlive) }
        };

        public static Vector2 GetVelocityFromDirection(IPlayerDirectionState directionState)
        {
            // Retrieves velocity based on direction state
            if (directionVelocity.TryGetValue(directionState.GetDirectionState(), out Vector2 velocity))
            {
                return velocity;
            }
            // Return zero if not found in dictionary
            return Vector2.Zero;
        }

        // May update the frame or position of a sprite
        public void Update(GameTime gameTime)
        {
            // Updates the time alive and position of the projectile
            timeAlive += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            // Check if it�s still alive
            if (IsAlive)
            {
                if (!hitFloor)
                {
                    ApplyGravity();
                }
                /*For some reason, if we use TotalMiliseconds, it wont draw...so i just stuck with TotalSeconds*/
                position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            projectileSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draws the projectile if it is still active
            if (IsAlive)
            {
                projectileSprite.Draw(spriteBatch, position);
            }
        }

        public Rectangle GetHitBox()
        {
            // Returns the projectile's hitbox for collision detection
            return this.projectileSprite.GetDestinationRectangle(position);
        }

        public string GetCollisionClass()
        {
            // Returns the collision class of the projectile
            return "projectile";
        }

        public void Die()
        {
            // Sets the projectile as no longer alive
            timeAlive = maxTimeAlive;
            Game1.Instance.GetLevel().RemoveGameObject(this);
        }

        public bool isMover()
        {
            // Indicates that the projectile is a movable object
            return true;
        }

        public void ApplyGravity()
        {
            //applies constant gravity, dragging it down
            this.position.Y += ProjectileConstants.Gravity;
            hitFloor = false;
        }

        // Goal is for projectile to go back to a non-intersect position
        public void SetVertBouncePosition(int setback)
        {
            /* 
            Needed additional set bc setback would just make it float on the block, but with gravity applied, it would go underneath the block,
            and hit the right/left side of the block, triggering it's death.
            Adding the additional setback gives it just enough time such that gravity doesnt immediately go underneath the block
            */
            this.position = new Vector2(this.position.X, this.position.Y + setback - ProjectileConstants.AdditionalSetback);
            this.position.Y -= ProjectileConstants.ReverseGravity; //makes it bounce up
            hitFloor = true;
            ApplyGravity(); //makes it go down
        }
    }
}
