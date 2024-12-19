using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PoseStates
{
    public class FreezeState : IPlayerPoseState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public FreezeState(IPlayer player)
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
            player.SetVelocity(0, 0);
        }
    }
}
