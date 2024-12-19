using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Collision
{
    public class CollisionHandler
    {
        public CollisionHandler()
        {
        }

        public void CheckCollisions(List<ICollidable> movables, List<ICollidable> gameObjects)
        {
            var movablesCopy = new List<ICollidable>(movables);
            var gameObjectsCopy = new List<ICollidable>(gameObjects);

            foreach (ICollidable movable in movablesCopy)
            {
                foreach (ICollidable gameObject in gameObjectsCopy)
                {
                    if (CollisionDetector.IsColliding(movable, gameObject))
                    {
                        string side = CollisionDetector.DetermineCollisionSide(movable, gameObject);
                        Rectangle collisionRect = CollisionDetector.GetCollisionRectangle(movable, gameObject);
                        AllCollisionResponder.Instance.CollisionResponder(movable, gameObject, side, collisionRect);
                    }
                }

                foreach (ICollidable otherMovable in movablesCopy)
                {
                    if (movable != otherMovable && CollisionDetector.IsColliding(movable, otherMovable))
                    {
                        string side = CollisionDetector.DetermineCollisionSide(movable, otherMovable);
                        Rectangle collisionRect = CollisionDetector.GetCollisionRectangle(movable, otherMovable);
                        AllCollisionResponder.Instance.CollisionResponder(movable, otherMovable, side, collisionRect);
                    }
                }
            }
        }

    }
}