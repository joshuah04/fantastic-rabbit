using Microsoft.Xna.Framework;
using Sprint0.Enemies;

namespace Sprint0.Commands.Collision.EnemyBlockCollision
{
    public class GoombaBounceRightCommand : ICommand
    {
        private Goomba goomba;
        private Rectangle rect;
        public GoombaBounceRightCommand(Goomba goomba, Rectangle rect)
        {
            this.goomba = goomba;
            this.rect = rect;
        }
        public void Execute()
        {
            //goomba.Direction("Right");
            goomba.ChangeState(new GoombaMovingRightState());
        }
    }
}


