using Microsoft.Xna.Framework;
using Sprint0.Sound;

namespace Sprint0.Enemies
{
    public class GoombaStompedState : IEnemyState
    {
        private Goomba goomba;
        int Timer = 10;
        int counter = 0;

        public void Enter(Enemy enemy)
        {
            goomba = enemy as Goomba;
            goomba.SetCurrentEnemyState(EnemyStates.GoombaStompedState);
            goomba.SetSprite(SpriteFactory.Instance.getSpriteById("StompedGoomba", 0f));
            SoundManager.Instance.PlaySound("stomp");
        }

        public void Update(GameTime gameTime)
        {
            counter++;

            if (counter > Timer)
            {
                goomba.ChangeState(new GoombaDeadState());
            }
        }

        public void Move()
        {
            // Stomped Koopa does not move
        }

        public void TakeDamage()
        {
            // Already stomped, no further damage
        }
    }
}