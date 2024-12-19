using Microsoft.Xna.Framework;
using Sprint0.Enemies;

namespace Sprint0.Commands.Collision.EnemyBlockCollision
{
    public class KoopaShellCommand : ICommand
    {
        private Koopa koopa;
        private Rectangle rect;
        public KoopaShellCommand(Koopa koopa, Rectangle rect)
        {
            this.koopa = koopa;
            this.rect = rect;
        }
        public void Execute()
        {
            koopa.ChangeState(new KoopaShellState());
            koopa.Die();
        }
    }
}