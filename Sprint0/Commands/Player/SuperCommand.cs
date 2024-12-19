using Microsoft.Xna.Framework;
using Sprint0.MarioStates.PowerStates;
using Sprint0.Interfaces.Player;
using Sprint0.Sound;
using Sprint0.Levels;
using Sprint0.Constants;

namespace Sprint0.Commands.Player
{
    /* Temp class to change Mario into fire Mario */
    public class SuperCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public SuperCommand(IPlayer player, Rectangle rect)
        {
            this.player = player;
        }
        public void Execute()
        {
            if (player.CurrentPower.GetPowerState() == "Normal")
            {
                player.SetPower(new EntrySuperPowerState(player));
                player.CurrentPower.EnterState();
            }
            SoundManager.Instance.PlaySound("powerup");
            Game1.Instance.GetScoreScreen().UpdateScore(GameConstants.CoinScore);
        }
    }
}
