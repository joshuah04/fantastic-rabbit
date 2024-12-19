using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using Sprint0.Sound;
using System;

namespace Sprint0.Blocks
{
    public class FlagPole : IBlock, IGameObject, ICollidable
    {
        private ISprite flagPoleSprite;
        private Vector2 flagPolePosition;
        private bool cleared = false;
        public bool IsAlive { get; private set; }
        private double flagAnimationTimer = 0;
        private double flagAnimationLimit = 7000;

        // Flag
        private ISprite flagSprite;
        private Vector2 flagSpritePosition;

        public FlagPole(Vector2 position)
        {
            this.flagPolePosition = position;
            this.flagPoleSprite = SpriteFactory.Instance.getSpriteById("FlagPole", BlockConstants.AnimationDelay);

            this.flagSprite = SpriteFactory.Instance.getSpriteById("Flag", BlockConstants.AnimationDelay);
            this.flagSpritePosition = new Vector2(position.X - 8, position.Y + 8);
            IsAlive = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            flagPoleSprite.Draw(spriteBatch, flagPolePosition);
            flagSprite.Draw(spriteBatch, flagSpritePosition);
        }

        public void Update(GameTime gameTime)
        {
            flagPoleSprite.Update(gameTime);

            // Bandaid solution, NEEDS FIXED
            if(cleared)
            {
                PlayFlagPoleAnimation();

                flagAnimationTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

                if(flagAnimationTimer > flagAnimationLimit)
                {
                    Game1.Instance.GetLevel().SetLevelState(1);
                }
            }
        }

        public void PlayFlagPoleAnimation()
        {
            if(flagSpritePosition.Y < 192)
            {
                flagSpritePosition += new Vector2(0, 1);
            }
        }

        public Rectangle GetHitBox()
        {
            return flagPoleSprite.GetDestinationRectangle(flagPolePosition);
        }
        public string GetCollisionClass()
        {
            return "flag";
        }
        public void Die()
        {
            // Flag does not die
        }
        public Boolean isMover()
        {
            return false;
        }

        // Changes the FlagPole to the Animation state
        public void setLevelCleared()
        {
            if(!this.cleared)
            {
                this.cleared = true;
                SoundManager.Instance.PlaySound("LevelCleared");
            }
            
        }
    }
}