using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using Sprint0.Constants;

namespace Sprint0.Blocks
{
    public class WarpZone : IGameObject, ICollidable
    {
        private Vector2 warpZonePosition;
        private string warp;
        private Rectangle warpBounds;
        private string warpSide;

        public bool IsAlive => throw new NotImplementedException();

        public WarpZone(Vector2 pos, String warp, String side)
        {
            this.warpZonePosition = pos;
            this.warp = warp;
            this.warpBounds = new Rectangle((int)warpZonePosition.X, (int)warpZonePosition.Y, CollisionConstants.WARP_WIDTH, CollisionConstants.WARP_HEIGHT);
            this.warpSide = side;
        }

        public void Die()
        {
            // Do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public string GetCollisionClass()
        {
            return warpSide;
        }

        public Rectangle GetHitBox()
        {
            return warpBounds;
        }

        public bool isMover()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            // No update logic
        }

        public void Warp()
        {
            Game1.Instance.GetLevel().Warp(warp);
        }
    }
}
