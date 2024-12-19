using Microsoft.Xna.Framework;
using Sprint0.Constants;

namespace Sprint0.Enemies
{
    public class GhostAttackState : IEnemyState
    {
        private Ghost ghost;
        bool style1 = true;
        int timer = 10; 
        int count = 0; 

        public void Enter(Enemy enemy)
        {
            ghost = enemy as Ghost;
            ghost.SetCurrentEnemyState(EnemyStates.GhostAttackState);

            // Set style to 
            if (ghost.IsPlayerLeftOfGhost(ghost.Position.X)) {
                SetAttackStyleLeft();
            } else {
                SetAttackStyleRight();
            }
        }

        public void Update(GameTime gameTime)
        {
            // Only if player is in attack range
            if (ghost.WithinAttackRange(ghost.Position.X))
            {
                // Alternate between attack styles. Also only attack if within a certain distance. 
                if (count >= timer) {
                    // Change Style
                    if (ghost.IsPlayerLeftOfGhost(ghost.Position.X)) {
                        SetAttackStyleLeft();
                    } else {
                        SetAttackStyleRight();
                    }
                    count = 0; 
                    style1 = !style1;
                } 
            } else {
                // ghost needs to return to running state
                ghost.FindRunningDirection(ghost.Position.X);
            }
        }

        public void Move()
        {
            // Only Attacking in this position
        }

        public void TakeDamage()
        {
            // Ghosts Don't Die
        }

        // To decide which left attack style
        public void SetAttackStyleLeft() {
            if (style1) {
                ghost.SetSprite(SpriteFactory.Instance.getSpriteById("GhostLeftAttack1", EnemyConstants.AnimationDelay));
            } else {
                ghost.SetSprite(SpriteFactory.Instance.getSpriteById("GhostLeftAttack2", EnemyConstants.AnimationDelay));
            }
        }

        // To decide which right attack style. 
        public void SetAttackStyleRight() {
            if (style1) {
                ghost.SetSprite(SpriteFactory.Instance.getSpriteById("GhostRightAttack1", EnemyConstants.AnimationDelay));
            } else {
                ghost.SetSprite(SpriteFactory.Instance.getSpriteById("GhostRightAttack2", EnemyConstants.AnimationDelay));
            }
        }
    }
}