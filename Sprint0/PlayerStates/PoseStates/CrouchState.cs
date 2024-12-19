using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PoseStates
{
    public class CrouchState : IPlayerPoseState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public CrouchState(IPlayer player)
        {
            this.player = player;
        }

        /* Obtain the pose string for our composite key */
        public string GetPoseState()
        {
            return "Crouch";
        }

        /* Get the new sprite from the sprite factory */
        public void EnterState()
        {
        }

        /* Handle state transitions between poses */
        /* Can probably refactor this to somewhere else later */
        /* Probably need a falling state? */
        public void Update(GameTime gameTime)
        {
            /* Account for fact that falling Mario can't crouch elsewhere */
        }
    }
}
