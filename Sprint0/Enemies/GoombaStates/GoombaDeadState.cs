using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class GoombaDeadState : IEnemyState
    {
        private Goomba goomba;
        public void Enter(Enemy enemy)
        {
            goomba = enemy as Goomba;
            goomba.SetCurrentEnemyState(EnemyStates.GoombaDeadState);
            goomba.SetSprite(SpriteFactory.Instance.getSpriteById("DeadGoomba", 0f));
        }

        public void Update(GameTime gameTime)
        {
            Move();
        }

        public void Move()
        {
            goomba.Position -= new Vector2(0, EnemyConstants.MoveSpeed);
        }

        public void TakeDamage()
        {
            // Already stomped, no further damage
        }
    }
}