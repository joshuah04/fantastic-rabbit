using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
namespace Sprint0.Commands.Collision.ItemBlockCollision
{
    public class ItemBounceUpCommand : ICommand
    {
        private IItem item;
        private Rectangle rect;
        public ItemBounceUpCommand(IItem item, Rectangle rect)
        {
            this.item = item;
            this.rect = rect;
        }
        public void Execute()
        {
            if (!item.isBouncing)  // Check to prevent re-triggering if already bouncing
            {
                Console.WriteLine("Executing ItemBounceUpCommand...");
                item.StartBounce();
                int setback = -(rect.Height);
                Console.WriteLine($"Setting vertical bounce position with setback: {setback}");
                item.SetVerticalBouncePosition(setback);
            }
        }
    }
}