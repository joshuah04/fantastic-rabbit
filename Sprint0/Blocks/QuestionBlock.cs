using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using Sprint0.Sound;
using System;
using Sprint0.XML;
using Sprint0.Interfaces.Player;

namespace Sprint0.Blocks
{
    public class QuestionBlock : IBlock, IGameObject, ICollidable, IItemBlock
    {
        private ISprite questionBlockSprite;
        private Vector2 questionBlockPosition;
        public bool IsAlive { get; private set; }
        private string itemType;
        private bool isBouncing = false;
        private bool isItem = true;
        private Vector2 origPos;
        private float bounceOffset = 0f;
        private float bounceSpeed = 1f;
        private float maxHeight = 6f;

        private IItem item;
        private Vector2 itemPos;

        Random rand = new Random();

        public QuestionBlock(Vector2 position)
        {
            this.questionBlockPosition = position;
            this.questionBlockSprite = SpriteFactory.Instance.getSpriteById("QuestionBlock", BlockConstants.AnimationDelay);
            IsAlive = true;
            this.origPos = position;
            itemType = GetItem();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            questionBlockSprite.Draw(spriteBatch, questionBlockPosition);
        }

        public void Update(GameTime gameTime)
        {
            questionBlockSprite.Update(gameTime);
            if (isBouncing)
            {
                if (bounceOffset < maxHeight)
                {
                    questionBlockPosition.Y -= bounceSpeed;
                    bounceOffset += bounceSpeed;
                }
                else if (bounceOffset >= maxHeight && questionBlockPosition.Y < origPos.Y)
                {
                    questionBlockPosition.Y += bounceSpeed;
                }
                else
                {
                    questionBlockPosition.Y = origPos.Y;
                    isBouncing = false;
                    isItem = false;
                    Game1.Instance.GetLevel().RemoveObjQueue(this);
                    Game1.Instance.GetLevel().AddObjQueue(new EmptyBlock(questionBlockPosition, "0"));
                }
            }
        }

        public Rectangle GetHitBox()
        {
            return questionBlockSprite.GetDestinationRectangle(questionBlockPosition);
        }
        public string GetCollisionClass()
        {
            return "breakable";
        }
        public void Die()
        {
            IsAlive = false;
        }
        public Boolean isMover()
        {
            return false;
        }

        public void MakeItem(IPlayer player)
        {
            if (isBouncing) return;
            isBouncing = true;
            bounceOffset = 0;

            // find a way to make item made only if mario is not normal
            if (isItem)
            {
                itemPos = new Vector2(questionBlockPosition.X, questionBlockPosition.Y);
                item = (IItem)XML_Loader.Instance.CreateItem(itemType, itemPos);
                SoundManager.Instance.PlaySound("bump");
                item.StartBounce();
                Game1.Instance.GetLevel().AddObjQueue((ICollidable)item);
            }
        }

        private string GetItem()
        {
            // get a random double
            double randVal = rand.NextDouble();
            double prob = 0.0;
            // loop checks if the double is less than the prob .0-.50, .50-.55, .55-.62, .62-.82, .82-.97, .97-1
            for (int i = 0; i < BlockConstants.probabilities.Length; i++)
            {
                prob += BlockConstants.probabilities[i];
                if (randVal <= prob)
                {
                    // return string if hit
                    return BlockConstants.itemArray[i];
                }
            }
            // return "mushroom" as fallback
            return BlockConstants.itemArray[0];
        }
    }
}