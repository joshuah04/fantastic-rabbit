using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using Sprint0.Sound;
using System;
using Sprint0.XML;
using Sprint0.Interfaces.Player;
using System.Linq;

namespace Sprint0.Blocks
{
    public class BrickBlock : IBlock, IGameObject, ICollidable, IItemBlock
    {
        private ISprite brickBlockSprite;
        private Vector2 brickBlockPosition;
        public bool IsAlive { get; private set; }
        private int itemCount;
        private bool isBouncing = false;
        private Vector2 origPos;
        private float bounceOffset = BlockConstants.BounceOffsetInitialValue;
        private float bounceSpeed = BlockConstants.BounceSpeed;
        private float maxHeight = BlockConstants.MaxBounceHeight;

        private IItem item;
        private Vector2 itemPos;

        private IPlayer player;
        private bool isSmall;

        public BrickBlock(Vector2 position, string texture)
        {
            this.brickBlockPosition = position;
            this.brickBlockSprite = SpriteFactory.Instance.getSpriteById(texture, BlockConstants.AnimationDelay);
            IsAlive = true;
            itemCount = 0;
            this.origPos = position;
            isSmall = false;
        }

        public BrickBlock(Vector2 position, string count, string texture)
        {
            this.brickBlockPosition = position;
            this.brickBlockSprite = SpriteFactory.Instance.getSpriteById(texture, BlockConstants.AnimationDelay);
            IsAlive = true;
            itemCount = int.Parse(count);
            this.origPos = position;
            isSmall = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            brickBlockSprite.Draw(spriteBatch, brickBlockPosition);
        }

        public void Update(GameTime gameTime)
        {
            brickBlockSprite.Update(gameTime);
            if (isBouncing)
            {
                if (bounceOffset < maxHeight)
                {
                    // move block up
                    brickBlockPosition.Y -= bounceSpeed;
                    bounceOffset += bounceSpeed;
                }
                else if (bounceOffset >= maxHeight && brickBlockPosition.Y < origPos.Y)
                {
                    // move block down
                    brickBlockPosition.Y += bounceSpeed;
                }
                else
                {
                    // end of bounce
                    brickBlockPosition.Y = origPos.Y;
                    isBouncing = false;
                }
            }
        }

        public Rectangle GetHitBox()
        {
            return brickBlockSprite.GetDestinationRectangle(brickBlockPosition);
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
            bounceOffset = BlockConstants.BounceOffsetInitialValue;

            // find a way to make item made only if mario is not normal
            if (player.CurrentPower.GetPowerState() != "Normal")
            {
                if (itemCount > 0)
                {
                    itemPos = new Vector2(brickBlockPosition.X + BlockConstants.ItemPositionXOffset, brickBlockPosition.Y);
                    item = (IItem)XML_Loader.Instance.CreateItem("coin", itemPos);
                    item.StartBounce();
                    Game1.Instance.GetLevel().AddObjQueue((IGameObject)item);

                    // add coin to points and update UI
                    //SoundManager.Instance.PlaySound("coin");
                    SoundManager.Instance.PlaySound("bump");
                    itemCount--;
                }
                else
                {
                    Game1.Instance.GetLevel().RemoveObjQueue(this);
                    Game1.Instance.GetLevel().AddObjQueue(new BrickBlockDebris(brickBlockPosition));
                    SoundManager.Instance.PlaySound("breakblock");
                }
            }
        }
    }
}
