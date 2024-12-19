using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PowerStates
{
    public class DoctorPowerState : IPlayerPowerState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public DoctorPowerState(IPlayer player)
        {
            this.player = player;
            player.SetColor(ColorConstants.NORMAL);
        }

        /* Obtain the power string for our composite key */
        public string GetPowerState()
        {
            return "Doctor";
        }

        /* Doctor flower mario's sprite is bigger so a small position offset is necessary when entering the state */
        public void EnterState()
        {
            player.SetPosition(player.CurrentPosition.X, player.CurrentPosition.Y - 5);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
