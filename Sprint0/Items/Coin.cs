using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using Sprint0.Constants;
using Sprint0.Sound;

namespace Sprint0.Items
{
    internal class Coin : IItem, ICollidable, IGameObject
    {
        private ISprite coinSprite;
        private Vector2 coinPosition;
        public bool IsAlive { get; private set; }
        public bool isBouncing { get; private set; }
        private float bounceHeight = ItemConstants.BounceHeight;
        private float bounceSpeed = ItemConstants.BounceSpeed;
        private float bounceOffset = ItemConstants.BounceOffsetInitial;
        private bool waitDie = false;
        private float waitTime = 0f;

        public Coin(Vector2 position)
        {
            coinPosition = position;
            coinSprite = SpriteFactory.Instance.getSpriteById("Coin", ItemConstants.AnimationDelay);
            IsAlive = true;
            isBouncing = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                coinSprite.Draw(spriteBatch, coinPosition);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                coinSprite.Update(gameTime);
                if (isBouncing)
                {
                    // goes up
                    Bounce();
                }
                else if (waitDie)
                {
                    // waits 1 second then dies
                    waitTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (waitTime > ItemConstants.WaitTimeBeforeDie) Die();
                }
            }
        }

        public void Die()
        {
            //remove coin immediately so it doesn't add score multiple times
            Game1.Instance.GetLevel().RemoveObjQueue(this);
            //add coin to score, then update it in scorescreen
            Game1.Instance.GetScoreScreen().UpdateScore(GameConstants.CoinScore);
            Game1.Instance.GetScoreScreen().AddCoinToScore();
            IsAlive = false;
            SoundManager.Instance.PlaySound("coin");
        }

        public Rectangle GetHitBox()
        {
            return coinSprite.GetDestinationRectangle(coinPosition);
        }

        public string GetCollisionClass()
        {
            return "coin";
        }

        public Boolean isMover()
        {
            return false;
        }

        public void StartBounce()
        {
            isBouncing = true;
            bounceOffset = ItemConstants.BounceOffsetInitial;
        }

        public void Bounce()
        {
            // item is in the block
            if (bounceOffset < bounceHeight)
            {
                coinPosition.Y -= bounceSpeed;
                bounceOffset++;
            }
            // stops moving up and starts timer till remove
            else
            {
                isBouncing = false;
                waitDie = true;
            }
        }
        /* Relates to IItem interface, but coin doesnt need bc it doesnt move */
        public void ReverseDirection()
        {
        }

        /* Relates to IItem interface, but since it doesnt move, this is useless. Only meant for items that move & have gravity applied, which this doesnt*/
        public void SetVerticalBouncePosition(int offset)
        {
        }
    }
}
