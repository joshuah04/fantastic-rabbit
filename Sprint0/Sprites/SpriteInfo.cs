using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public class SpriteInfo
    {
        public Texture2D texture { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }

        public SpriteInfo(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
        }
    }
}