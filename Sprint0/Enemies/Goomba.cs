using Microsoft.Xna.Framework;
using Sprint0.Constants;


namespace Sprint0.Enemies
{
    public class Goomba : Enemy
    {
        private float turnTimer = EnemyConstants.TurnTimer;
        private float timeSinceLastTurn = 0.0f;

        public Goomba(Vector2 initialPosition) : base (initialPosition)
        {
            ChangeState(new GoombaMovingLeftState()); // Default
        }

        public override void Update(GameTime gameTime)
        {
            timeSinceLastTurn += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timeSinceLastTurn >= turnTimer)
            {
                if(currentState is GoombaMovingLeftState)
                {
                    ChangeState(new GoombaMovingRightState());
                }
                else
                {
                    ChangeState(new GoombaMovingLeftState());
                }

                timeSinceLastTurn -= turnTimer;
            }
            base.Update(gameTime);
        }
    }
}
