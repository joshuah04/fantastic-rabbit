using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class GhostWalkLeftState : IEnemyState
    {
        private Ghost ghost;
        int timer;
        int count = 0; 

        public void Enter(Enemy enemy)
        {
            ghost = enemy as Ghost;
            ghost.SetCurrentEnemyState(EnemyStates.GhostWalkLeftState);
            ghost.SetSprite(SpriteFactory.Instance.getSpriteById("GhostWalkLeft", EnemyConstants.AnimationDelay));

            timer = ghost.switchTime();
        }

        public void Update(GameTime gameTime)
        {
            Move();

            if (count >= timer) {
                ghost.Wandering();
            }

            count++;

            // Check if player in alert range which means start running
            if (ghost.WithinAlertRange(ghost.Position.X))
            {
                ghost.FindRunningDirection(ghost.Position.X);
            }

            if (ghost.ReturnToStart(ghost.Position.X))
            {
                ghost.ResetPosition();
            }
        }

        public void Move()
        {
            ghost.Position -= new Vector2(EnemyConstants.GhostSpeed, 0);
        }

        public void TakeDamage()
        {
            ghost.ChangeState(new GhostAttackState());
        }
    }
}