using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;
using Sprint0.Levels;

namespace Sprint0.Commands.Player
{
    internal class TakeDamageCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public TakeDamageCommand(IPlayer player, Rectangle rect)
        {
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            player.TakeDamage();
        }
    }
}
