using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Constants;

namespace Sprint0
{
    public class Sprite : ISprite
    {
        private Texture2D texture;
        private int rows;
        private int columns;
        private float animationDelay;
        private float animationTime;
        private int currentFrame;
        private int totalFrames;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Sprite(Texture2D texture, int rows, int columns, float animationDelay)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            this.animationDelay = animationDelay;
            this.animationTime = SpriteConstants.InitialAnimationTime;
            this.currentFrame = SpriteConstants.InitialFrame;
            this.totalFrames = rows * columns;

            /* added this to satisfy ISprite interface property */
            this.Width = texture.Width / columns;
            this.Height = texture.Height / rows;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            /* Gets necessary dimensions */
            int width = texture.Width / columns;
            int height = texture.Height / rows;

            int row = currentFrame / columns;
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            animationTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (animationTime >= animationDelay)
            {
                animationTime -= animationDelay;
                currentFrame++;

                if (currentFrame == totalFrames) currentFrame = SpriteConstants.InitialFrame;
            }
        }

        public Rectangle GetDestinationRectangle(Vector2 location)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
    }
}
