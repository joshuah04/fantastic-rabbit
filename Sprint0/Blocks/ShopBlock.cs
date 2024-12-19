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
    public class ShopBlock : IBlock, IGameObject, ICollidable, IItemBlock
    {
        private ISprite shopBlockSprite;
        private Vector2 shopBlockPosition;
        public bool IsAlive { get; private set; }
        private bool isBouncing = false;
        private bool isItem = true;
        private Vector2 origPos;
        private float bounceOffset = 0f;
        private float bounceSpeed = 1f;
        private float maxHeight = 6f;

        private IItem item;
        private Vector2 itemPos;
        private int cost;
        private string itemType;
        private int currCoins;
        private bool canBuy;

        private SpriteFont font;

        public ShopBlock(Vector2 position, string itemType, string cost)
        {
            shopBlockPosition = position;
            shopBlockSprite = SpriteFactory.Instance.getSpriteById("QuestionBlock", BlockConstants.AnimationDelay);
            IsAlive = true;
            origPos = position;
            this.itemType = itemType;
            this.cost = int.Parse(cost);
            font = Game1.Instance.Font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            shopBlockSprite.Draw(spriteBatch, shopBlockPosition);

            string costText = $"Cost: {cost}";
            Vector2 stringPos = shopBlockPosition + new Vector2(-8, 18);
            spriteBatch.DrawString(font, costText, stringPos, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            shopBlockSprite.Update(gameTime);
            if (isBouncing)
            {
                if (bounceOffset < maxHeight)
                {
                    shopBlockPosition.Y -= bounceSpeed;
                    bounceOffset += bounceSpeed;
                }
                else if (bounceOffset >= maxHeight && shopBlockPosition.Y < origPos.Y)
                {
                    shopBlockPosition.Y += bounceSpeed;
                }
                else
                {
                    shopBlockPosition.Y = origPos.Y;
                    isBouncing = false;
                    isItem = false;
                    Game1.Instance.GetLevel().RemoveObjQueue(this);
                    Game1.Instance.GetLevel().AddObjQueue(new EmptyBlock(shopBlockPosition, "0"));
                }
            }
        }

        public Rectangle GetHitBox()
        {
            return shopBlockSprite.GetDestinationRectangle(shopBlockPosition);
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
            currCoins = Game1.Instance.GetScoreScreen().GetCoins();
            canBuy = currCoins >= cost;
            if (canBuy)
            {
                Game1.Instance.GetScoreScreen().RemoveCoinFromScore(cost);
                if (isBouncing) return;
                isBouncing = true;
                bounceOffset = 0;

                // find a way to make item made only if mario is not normal
                // add coin cost vs coin counter condition
                if (isItem)
                {
                    itemPos = new Vector2(shopBlockPosition.X, shopBlockPosition.Y);
                    item = (IItem)XML_Loader.Instance.CreateItem(itemType, itemPos);
                    SoundManager.Instance.PlaySound("bump");
                    item.StartBounce();
                    Game1.Instance.GetLevel().AddObjQueue((ICollidable)item);
                }
            }
        }
    }
}