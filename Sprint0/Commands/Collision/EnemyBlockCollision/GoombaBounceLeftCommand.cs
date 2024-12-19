using Microsoft.Xna.Framework;
using Sprint0.Enemies;

namespace Sprint0.Commands.Collision.EnemyBlockCollision
{
    public class GoombaBounceLeftCommand : ICommand
    {
        private Goomba goomba;
        private Rectangle rect;
        public GoombaBounceLeftCommand(Goomba goomba, Rectangle rect)
        {
            this.goomba = goomba;
            this.rect = rect;
        }
        public void Execute()
        {
            //goomba.Direction("Left");
            goomba.ChangeState(new GoombaMovingLeftState());
        }
    }
}