using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class GhostIdleState : IEnemyState
    {
        private Ghost ghost;
        int timer; 
        int count = 0; 

        public void Enter(Enemy enemy)
        {
            ghost = enemy as Ghost;
            ghost.SetCurrentEnemyState(EnemyStates.GhostIdleState);
            ghost.SetSprite(SpriteFactory.Instance.getSpriteById("IdleGhost", EnemyConstants.AnimationDelay));
            
            timer = ghost.switchTime();
        }

        public void Update(GameTime gameTime)
        {
            if (!ghost.WithinAlertRange(ghost.Position.X))
            {
                if (count >= timer) {
                    ghost.Wandering();
                }
                count++;
            } else {
                ghost.FindRunningDirection(ghost.Position.X);
            }
        }

        public void Move()
        {
            // Already moving left, so no additional logic here
        }

        public void TakeDamage()
        {
            ghost.ChangeState(new GhostAttackState());
        }
    }
}