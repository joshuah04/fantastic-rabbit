using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Collision
{
    public class CollisionDetector
    {

        public CollisionDetector()
        {

        }

        public static bool IsColliding(ICollidable obj1, ICollidable obj2)
        {
            return obj1.GetHitBox().Intersects(obj2.GetHitBox());
        }

        // may need a better implementation for the side, not sure how accurate this is
        public static string DetermineCollisionSide(ICollidable obj1, ICollidable obj2)
        {
            Rectangle obj1Rect = obj1.GetHitBox();
            Rectangle obj2Rect = obj2.GetHitBox();

            Rectangle collisionArea = Rectangle.Intersect(obj1Rect, obj2Rect);

            if (collisionArea.IsEmpty)
            {
                return "None";
            }

            // horizontal collision
            if (collisionArea.Width < collisionArea.Height)
            {
                // if object1 is to the left of object2
                if (obj1Rect.Center.X < obj2Rect.Center.X)
                {
                    return "Left";
                }
                // if right
                else
                {
                    return "Right";
                }
            }
            // vertical collision
            else
            {
                // if object1 is above object2
                if (obj1Rect.Center.Y < obj2Rect.Center.Y)
                {
                    return "Top";
                }
                // if above
                else
                {
                    return "Bottom";
                }
            }
            // doesn't check if collision area is a square/corner collision. fix later
            // could check based on velocity of object1

        }

        // need to find the rectangle of the intersection so that the command can push the object back to where it should be so its not intersecting
        public static Rectangle GetCollisionRectangle(ICollidable obj1, ICollidable obj2)
        {
            Rectangle obj1Rect = obj1.GetHitBox();
            Rectangle obj2Rect = obj2.GetHitBox();

            return Rectangle.Intersect(obj1Rect, obj2Rect);
        }
    }
}