using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Blocks
{
    public class UpConnectingPipe : IGameObject, IBlock, ICollidable
    {
        private Vector2 connectingPipePosition;
        private ISprite connectingPipeSprite;

        public bool IsAlive => true;

        public UpConnectingPipe(Vector2 pos)
        {
            this.connectingPipePosition = pos;
            this.connectingPipeSprite = SpriteFactory.Instance.getSpriteById("UpConnectingPipe", 150.0f);
        }

        public UpConnectingPipe(Vector2 pos, string texture)
        {
            this.connectingPipePosition = pos;
            this.connectingPipeSprite = SpriteFactory.Instance.getSpriteById(texture, 150.0f);
        }

        public void Die()
        {
            // connecting pipe does not die
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            connectingPipeSprite.Draw(spriteBatch, connectingPipePosition);
        }

        public string GetCollisionClass()
        {
            return "block";
        }

        public Rectangle GetHitBox()
        {
            return connectingPipeSprite.GetDestinationRectangle(connectingPipePosition);
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            connectingPipeSprite.Update(gameTime);
        }
    }
}
