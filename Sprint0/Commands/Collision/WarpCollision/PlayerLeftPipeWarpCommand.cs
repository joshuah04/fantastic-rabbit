using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;

namespace Sprint0.Commands.Collision.WarpCollision
{
    public class PlayerLeftPipeWarpCommand : ICommand
    {
        private IPlayer player;
        private Rectangle rect;

        public PlayerLeftPipeWarpCommand(IPlayer player, Rectangle rect)
        {
            this.player = player;
            this.rect = rect;
        }

        public void Execute()
        {
            player.enterWarp(rect);
        }
    }
}
