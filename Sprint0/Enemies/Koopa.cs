using Microsoft.Xna.Framework;
using Sprint0.Constants;


namespace Sprint0.Enemies
{
    public class Koopa : Enemy
    {
        private float turnTimer = EnemyConstants.TurnTimer;
        private float timeSinceLastTurn = 0.0f;

        public Koopa(Vector2 initialPosition) : base (initialPosition)
        {
            ChangeState(new KoopaMovingLeftState()); // Default
        }

        public override void Update(GameTime gameTime)
        {
            timeSinceLastTurn += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timeSinceLastTurn >= turnTimer)
            {
                if(currentState is KoopaMovingLeftState)
                {
                    ChangeState(new KoopaMovingRightState());
                }
                else
                {
                    ChangeState(new KoopaMovingLeftState());
                }

                timeSinceLastTurn -= turnTimer;
            }

            base.Update(gameTime);
        }
    }
}

