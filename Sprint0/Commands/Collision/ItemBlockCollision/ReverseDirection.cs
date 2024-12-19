using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
namespace Sprint0.Commands.Collision.ItemBlockCollision
{
    public class ReverseDirectionCommand : ICommand
    {
        private IItem item;
        public ReverseDirectionCommand(IItem item, Rectangle rect)
        {
            this.item = item;
        }
        public void Execute()
        {
            item.ReverseDirection();
        }
    }
}