using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class GhostRunLeftState : IEnemyState
    {
        private Ghost ghost;
        public void Enter(Enemy enemy)
        {
            ghost = enemy as Ghost;
            ghost.SetCurrentEnemyState(EnemyStates.GhostRunLeftState);
            ghost.SetSprite(SpriteFactory.Instance.getSpriteById("GhostRunLeft", EnemyConstants.AnimationDelay));

        }

        public void Update(GameTime gameTime)
        {
            // Only Run if in a certain range
            if (ghost.WithinAlertRange(ghost.Position.X))
            {
                if (ghost.IsPlayerLeftOfGhost(ghost.Position.X)) {
                    Move();
                     // If within attack range, attack
                    if (ghost.WithinAttackRange(ghost.Position.X)) {
                        TakeDamage();
                    }
                } else {
                    ghost.FindRunningDirection(ghost.Position.X);
                }
            } else {
                ghost.Wandering();
            }

            if (ghost.ReturnToStart(ghost.Position.X)) {
                ghost.ResetPosition();
            }
        }

        public void Move()
        {
            ghost.Position -= new Vector2(2, 0);
        }

        public void TakeDamage()
        {
            ghost.ChangeState(new GhostAttackState());
        }
    }
}