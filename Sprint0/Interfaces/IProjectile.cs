using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
    public interface IProjectile : ICollidable
    {
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        public void ApplyGravity();
        public void SetVertBouncePosition(int setback);
    }
}
