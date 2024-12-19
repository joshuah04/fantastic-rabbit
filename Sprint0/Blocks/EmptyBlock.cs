using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Blocks
{
    public class EmptyBlock : IBlock, IGameObject, ICollidable
    {
        private Vector2 emptyBlockPosition;
        private ISprite emptyBlockSprite;
        public bool IsAlive { get; private set; }
        private bool isInvis;

        public EmptyBlock(Vector2 pos, string invis)
        {
            this.emptyBlockPosition = pos;
            this.emptyBlockSprite = SpriteFactory.Instance.getSpriteById("EmptyBlock", BlockConstants.AnimationDelay);
            IsAlive = true;
            isInvis = invis == "1";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isInvis) emptyBlockSprite.Draw(spriteBatch, emptyBlockPosition);
        }

        public void Update(GameTime gameTime)
        {
            emptyBlockSprite.Update(gameTime);
        }

        public Rectangle GetHitBox()
        {
            return emptyBlockSprite.GetDestinationRectangle(emptyBlockPosition);
        }
        public string GetCollisionClass()
        {
            return "block";
        }
        public void Die()
        {

        }
        public Boolean isMover()
        {
            return false;
        }

    }
}
