using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class KoopaMovingRightState : IEnemyState
    {
        private Koopa koopa;

        public void Enter(Enemy enemy)
        {
            koopa = enemy as Koopa;
            koopa.SetCurrentEnemyState(EnemyStates.KoopaMovingRightState);
            koopa.SetSprite(SpriteFactory.Instance.getSpriteById("RightKoopa", EnemyConstants.AnimationDelay));
        }

        public void Update(GameTime gameTime)
        {
            Move();
        }

        public void Move()
        {
            koopa.Position += new Vector2(EnemyConstants.MoveSpeed, 0);
        }

        public void TakeDamage()
        {
            koopa.ChangeState(new KoopaShellState());
        }
    }
}