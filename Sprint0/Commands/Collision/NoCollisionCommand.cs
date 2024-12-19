using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class NoCollisionCommand : ICommand
    {
        private IGameObject obj;
        private Rectangle rect;
        public NoCollisionCommand(IGameObject obj, Rectangle rect)
        {
            this.obj = obj;
            this.rect = rect;
        }
        public void Execute()
        {
            // nothing happens
        }
    }
}

