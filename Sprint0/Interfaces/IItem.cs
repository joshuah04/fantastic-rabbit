using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface IItem
    {
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

        public void StartBounce();
        public void SetVerticalBouncePosition(int offset);
        public void ReverseDirection();
        bool isBouncing { get; }
    }
}
