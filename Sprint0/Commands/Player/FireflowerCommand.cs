using Microsoft.Xna.Framework;
using Sprint0.MarioStates.PowerStates;
using Sprint0.Interfaces.Player;
using Sprint0.Sound;
using Sprint0.Levels;

namespace Sprint0.Commands.Player
{
    public class FireflowerCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public FireflowerCommand(IPlayer player, Rectangle rect)
        {
            //this.playerIndex = playerIndex;
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            if (player.CurrentPower.GetPowerState() != "Fire")
            {
                player.SetPower(new FirePowerState(player));
                player.CurrentPower.EnterState();
                SoundManager.Instance.PlaySound("powerup");
            }
        }
    }
}
