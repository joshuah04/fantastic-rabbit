using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class DieCommand : ICommand
    {
        private IGameObject gameObject;

        public DieCommand(IGameObject obj, Rectangle rect)
        {
            this.gameObject = obj;
        }

        public void Execute()
        {
            gameObject.Die();
        }
    }
}

