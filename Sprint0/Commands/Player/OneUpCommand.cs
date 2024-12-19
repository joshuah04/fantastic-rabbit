using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;
using Sprint0.Levels;
using Sprint0.Sound;

namespace Sprint0.Commands.Player
{
    public class OneUpCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public OneUpCommand(IPlayer player, Rectangle rect)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.AddLife();
            SoundManager.Instance.PlaySound("powerup");
        }
    }
}
