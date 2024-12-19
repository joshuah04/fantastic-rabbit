using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;
using Sprint0.Sound;
using System;

namespace Sprint0.MarioStates.PoseStates
{
    public class JumpState : IPlayerPoseState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public JumpState(IPlayer player)
        {
            this.player = player;
        }

        /* Obtain the pose string for our composite key */
        public string GetPoseState()
        {
            return "Jump";
        }

        /* Might have more in this method later: sounds maybe? */
        public void EnterState()
        {
            Console.WriteLine("Entering MarioJumpState and playing jump sound");
            SoundManager.Instance.PlaySound("jumpSmall");
        }

        /* Handle state transitions between poses */
        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (player.Landed) player.SetVelocity(player.CurrentVelocity.X, -PhysicsConstants.maxJumpVelocity);
            else player.SetVelocity(player.CurrentVelocity.X, player.CurrentVelocity.Y + PhysicsConstants.G * deltaTime);
            
            player.SetLandedState(false);

            float newXPosition = player.CurrentPosition.X - deltaTime * player.CurrentVelocity.X;
            float newYPosition = player.CurrentPosition.Y + player.CurrentVelocity.Y * deltaTime;

            player.SetPosition(newXPosition, newYPosition);
        }
    }
}
