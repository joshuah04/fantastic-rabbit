using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PowerStates
{
    public class NormalPowerState : IPlayerPowerState
    {
        private IPlayer player;

        /* Assign our current reference to the player */
        public NormalPowerState(IPlayer player)
        {
            this.player = player;
            player.SetColor(ColorConstants.NORMAL);
        }

        /* Obtain the power string for our composite key */
        public string GetPowerState()
        {
            return "Normal";
        }

        /* Get the new sprite from the sprite factory */
        public void EnterState()
        {
        }

        /* Change power states based on items */
        /* Handle edge cases by switching other items to False immediately after obtaining a new item */
        public void Update(GameTime gameTime)
        {
        }
    }
}
