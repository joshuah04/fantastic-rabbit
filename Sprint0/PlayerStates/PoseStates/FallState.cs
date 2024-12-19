using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PoseStates
{
    public class FallState : IPlayerPoseState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public FallState(IPlayer player)
        {
            this.player = player;
        }

        /* Obtain the pose string for our composite key */
        public string GetPoseState()
        {
            return "Fall";
        }

        /* Get the new sprite from the sprite factory */
        public void EnterState()
        {
        }

        /* Handle state transitions between poses */
        public void Update(GameTime gameTime)
        {
            //Console.Write("MARIO IS FALLLLLINNGNGNGGGGGG");
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            player.SetLandedState(false);
            if (!player.Landed) player.SetVelocity(player.CurrentVelocity.X, player.CurrentVelocity.Y + PhysicsConstants.G * deltaTime);
            else
            {
                player.SetVelocity(player.CurrentVelocity.X, 0);
                player.SetPose(new StandState(player));
            }

            float newXPosition = player.CurrentPosition.X - deltaTime * player.CurrentVelocity.X;
            float newYPosition = player.CurrentPosition.Y + player.CurrentVelocity.Y * deltaTime;

            player.SetPosition(newXPosition, newYPosition);
        }
    }
}
