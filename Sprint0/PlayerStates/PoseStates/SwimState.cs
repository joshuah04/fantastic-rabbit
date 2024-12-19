using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;
using Sprint0.Players;

namespace Sprint0.MarioStates.PoseStates
{
    public class SwimState : IPlayerPoseState
    {
        private Mario mario;

        public SwimState(Mario mario)
        {
            this.mario = mario;
        }

        public string GetPoseState()
        {
            return "Swim";
        }

        /* Get the new sprite from the sprite factory */
        public void EnterState()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
