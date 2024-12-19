using Microsoft.Xna.Framework;
using Sprint0.Sound;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class KoopaShellState : IEnemyState
    {
        private Koopa koopa;
        int Timer = 10;
        int counter = 0;

        public void Enter(Enemy enemy)
        {
            koopa = enemy as Koopa;
            koopa.SetCurrentEnemyState(EnemyStates.KoopaShellState);
            koopa.SetSprite(SpriteFactory.Instance.getSpriteById("ShellKoopa", 0f));
            SoundManager.Instance.PlaySound("stomp");
        }

        public void Update(GameTime gameTime)
        {
            Move();
            counter++;
        
            if (counter > Timer)
            {
                koopa.ChangeState(new KoopaDeadState());
            }
        }

        public void Move()
        {
            koopa.Position += new Vector2(EnemyConstants.ShellSpeed, 0);
        }

        public void TakeDamage()
        {
            // Already stomped, no further damage
        }
    }
}