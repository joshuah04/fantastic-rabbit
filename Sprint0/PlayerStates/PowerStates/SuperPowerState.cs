using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PowerStates
{
    public class SuperPowerState : IPlayerPowerState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public SuperPowerState(IPlayer player)
        {
            this.player = player;
            player.SetColor(ColorConstants.NORMAL);
        }

        /* Obtain the power string for our composite key */
        public string GetPowerState()
        {
            return "Super";
        }

        /* Super mario's sprite is bigger so a small position offset is necessary when entering the state */
        public void EnterState()
        {
            player.SetPosition(player.CurrentPosition.X, player.CurrentPosition.Y - 5);
            
        }

        /* Refactor later */
        public void Update(GameTime gameTime)
        {
        }
    }
}
