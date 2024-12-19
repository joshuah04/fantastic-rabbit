using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;
using Sprint0.Levels;

namespace Sprint0.Commands.Player
{
    internal class KillEnemyCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public KillEnemyCommand(IPlayer player, Rectangle rect)
        {
            //this.playerIndex = playerIndex;
            this.player = player;
        }
        public void Execute()
        {
            if (player.CurrentPower.GetPowerState() == "Doctor")
            {
                player.AddLife();
            }
            player.KillEnemy();
        }
    }
}
