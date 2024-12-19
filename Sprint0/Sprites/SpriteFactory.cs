using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Sprint0
{
    sealed public class SpriteFactory
    {
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance { get { return instance; } }

        private Dictionary<String, SpriteInfo> spriteMappings;

        public SpriteFactory() 
        {
            spriteMappings = new Dictionary<String, SpriteInfo>();
        }

        public void registerSprite(String name, SpriteInfo sprite)
        {
            if (!spriteMappings.ContainsKey(name))
            {
                spriteMappings.Add(name, sprite);
            }
        }

        public void registerSprite(String key, Texture2D texture, int rows, int columns)
        {
            if (!spriteMappings.ContainsKey(key))
            {
                spriteMappings.Add(key, new SpriteInfo(texture, rows, columns));
            }
        }

        public ISprite getSpriteById(String id, float animationDelay)
        {
            SpriteInfo spriteInfo = spriteMappings[id];
            return new Sprite(spriteInfo.texture, spriteInfo.rows, spriteInfo.columns, animationDelay);
        }
    }
}
