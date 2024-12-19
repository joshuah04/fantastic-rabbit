using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class KoopaDeadState : IEnemyState
    {
        private Koopa koopa;
        public void Enter(Enemy enemy)
        {
            koopa = enemy as Koopa;
            koopa.SetCurrentEnemyState(EnemyStates.KoopaDeadState);
            koopa.SetSprite(SpriteFactory.Instance.getSpriteById("DeadKoopa", 0f));
        }

        public void Update(GameTime gameTime)
        {
            Move();
        }

        public void Move()
        {
            koopa.Position -= new Vector2(0, EnemyConstants.MoveSpeed);
        }

        public void TakeDamage()
        {
            // Already stomped, no further damage
        }
    }
}