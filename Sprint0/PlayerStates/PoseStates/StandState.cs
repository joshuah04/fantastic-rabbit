using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PoseStates
{
    public class StandState : IPlayerPoseState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public StandState(IPlayer player)
        {
            this.player = player;
        }

        /* Obtain the pose string for our composite key */
        public string GetPoseState()
        {
            return "Stand";
        }

        /* Get the new sprite from the sprite factory */
        public void EnterState()
        {
        }

        /* Handle state transitions between poses */
        public void Update(GameTime gameTime)
        {
            /* Not moving */
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            player.SetVelocity(0, player.CurrentVelocity.Y + PhysicsConstants.G * deltaTime);
            //mario.currentVelocity = new Vector2(0, mario.currentVelocity.Y + G * delta_time);

            if (!player.Landed) player.SetPose(new FallState(player));

            float newXPosition = player.CurrentPosition.X - deltaTime * player.CurrentVelocity.X;
            float newYPosition = player.CurrentPosition.Y + player.CurrentVelocity.Y * deltaTime;

            player.SetPosition(newXPosition, newYPosition);
        }
    }
}
