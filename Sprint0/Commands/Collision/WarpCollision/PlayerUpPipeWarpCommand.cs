using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;

namespace Sprint0.Commands.Collision.WarpCollision
{
    public class PlayerUpPipeWarpCommand : ICommand
    {
        private IPlayer player;
        private Rectangle rect;

        public PlayerUpPipeWarpCommand(IPlayer player, Rectangle rect)
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
