using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface IGameObject
    {
        public bool IsAlive { get; }

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

        public void Die();
    }
}
