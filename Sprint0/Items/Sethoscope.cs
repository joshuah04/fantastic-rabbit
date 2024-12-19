using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using Sprint0.Constants;

namespace Sprint0.Items
{
	internal class Stethoscope : IItem, ICollidable, IGameObject
	{
		private ISprite StethoscopeSprite;
		private Vector2 StethoscopePosition;
		public bool IsAlive { get; private set; }
		private float bounceHeight = ItemConstants.BounceHeight;
		private float bounceSpeed = ItemConstants.BounceSpeed;
		private float bounceOffset = ItemConstants.BounceOffsetInitial;
		public bool isBouncing { get; private set; }

		public Stethoscope(Vector2 position)
		{
			// Initializes the Stethoscope position and sprite
			StethoscopePosition = position;
			StethoscopeSprite = SpriteFactory.Instance.getSpriteById("Stethoscope", ItemConstants.AnimationDelay);
			IsAlive = true;
			isBouncing = false;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			// Draws the Stethoscope if it is alive
			if (IsAlive)
			{
				StethoscopeSprite.Draw(spriteBatch, StethoscopePosition);
			}
		}

		public void Update(GameTime gameTime)
		{
			// Updates the Stethoscope's animation and bounce behavior if it is alive
			if (IsAlive)
			{
				StethoscopeSprite.Update(gameTime);
				if (isBouncing)
				{
					Bounce();
				}
			}
		}

		public void Die()
		{
			// Sets the Stethoscope to be no longer alive
			IsAlive = false;
			Game1.Instance.GetLevel().RemoveGameObject(this); // remove the coin when picked up
		}

		public Rectangle GetHitBox()
		{
			// Returns the hitbox of the Stethoscope for collision detection
			return StethoscopeSprite.GetDestinationRectangle(StethoscopePosition);
		}

		public string GetCollisionClass()
		{
			// Returns the collision class of the Stethoscope
			return "stethoscope";
		}

		public Boolean isMover()
		{
			// Indicates that the Stethoscope is not a movable object
			return false;
		}

		public void StartBounce()
		{
			// Starts the bounce action for the Stethoscope
			isBouncing = true;
			bounceOffset = ItemConstants.BounceOffsetInitial;
		}

		public void Bounce()
		{
			// Handles the bounce movement up to a certain height
			if (bounceOffset < bounceHeight)
			{
				StethoscopePosition.Y -= bounceSpeed;
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
			// No implementation required for Stethoscope
		}

		public void SetVerticalBouncePosition(int offset)
		{
			// No implementation required for Stethoscope
		}
	}
}

