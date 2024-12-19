using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Interfaces
{
    public interface ICollidable : IGameObject
    {
        public Boolean isMover();

        public Rectangle GetHitBox();

        public string GetCollisionClass();
    }
}
