using Microsoft.Xna.Framework;
using Sprint0.MarioStates.PowerStates;
using Sprint0.Interfaces.Player;
using Sprint0.Sound;
using Sprint0.Levels;

namespace Sprint0.Commands.Player
{
    /* Temp class to change Mario into fire Mario */
    public class StarCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public StarCommand(IPlayer player, Rectangle rect)
        {
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            if (player.CurrentPower.GetPowerState() != "Star")
            {
                player.SetPower(new StarPowerState(player));
                player.CurrentPower.EnterState();
                SoundManager.Instance.PlaySound("powerup");
            }
        }
    }
}
