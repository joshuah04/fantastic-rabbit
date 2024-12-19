using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class GhostWalkRightState : IEnemyState
    {
        private Ghost ghost;
        int timer;
        int count = 0; 

        public void Enter(Enemy enemy)
        {
            ghost = enemy as Ghost;
            ghost.SetCurrentEnemyState(EnemyStates.GhostWalkRightState);
            ghost.SetSprite(SpriteFactory.Instance.getSpriteById("GhostWalkRight", EnemyConstants.AnimationDelay));

            timer = ghost.switchTime();
        }

        public void Update(GameTime gameTime)
        {
            Move();

            if (count >= timer) {
                ghost.Wandering();
            }

            count++;

            // Check if player in alert range, which means strat running
            if (ghost.WithinAlertRange(ghost.Position.X))
            {
                ghost.FindRunningDirection(ghost.Position.X);
            }

            if (ghost.ReturnToStart(ghost.Position.X)) {
                ghost.ResetPosition();
            }
        
        }

        public void Move()
        {
            ghost.Position += new Vector2(EnemyConstants.GhostSpeed, 0);
        }

        public void TakeDamage()
        {
            ghost.ChangeState(new GhostAttackState());
        }
    }
}