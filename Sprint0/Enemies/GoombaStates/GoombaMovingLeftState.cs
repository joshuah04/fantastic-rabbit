using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class GoombaMovingLeftState : IEnemyState
    {
        private Goomba goomba;

        public void Enter(Enemy enemy)
        {
            goomba = enemy as Goomba;
            goomba.SetCurrentEnemyState(EnemyStates.GoombaMovingLeftState);
            goomba.SetSprite(SpriteFactory.Instance.getSpriteById("AliveGoomba", EnemyConstants.AnimationDelay));
        }

        public void Update(GameTime gameTime)
        {
            Move();
        }

        public void Move()
        {
            goomba.Position += new Vector2(-EnemyConstants.MoveSpeed, 0);
        }

        public void TakeDamage()
        {
            goomba.ChangeState(new GoombaStompedState());
        }
    }
}