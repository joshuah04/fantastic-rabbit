using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PoseStates
{
    public class RunState : IPlayerPoseState
    {
        private IPlayer player;
        /* Need to think about x acceleration potentially because there is a bit of that happening */

        /* Assign our current reference to the player */
        public RunState(IPlayer player)
        {
            this.player = player;
        }

        /* Obtain the pose string for our composite key */
        public string GetPoseState()
        {
            return "Run";
        }

        /* Get the new sprite from the sprite factory */
        public void EnterState()
        {
        }

        /* Handle velocity and position updates based on current state */
        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            /* Obtain appropriate x velocity depending on which direction Mario is running */
            float newVelocity = PhysicsConstants.maxXVelocity;
            if (player.CurrentDirection.GetDirectionState() == "Right") newVelocity = -PhysicsConstants.maxXVelocity;
            player.SetVelocity(newVelocity, player.CurrentVelocity.Y + PhysicsConstants.G * deltaTime);

            if (player.CurrentVelocity.Y != 0)
            {
                player.SetLandedState(false);
            }

            float newXPosition = player.CurrentPosition.X - deltaTime * player.CurrentVelocity.X;
            float newYPosition = player.CurrentPosition.Y + player.CurrentVelocity.Y * deltaTime;

            player.SetPosition(newXPosition, newYPosition);
        }
    }
}
