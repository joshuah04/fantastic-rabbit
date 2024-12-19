using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;

namespace Sprint0.Commands.Collision.PlayerBlockCollision
{
    public class BlockItemCommand : ICommand
    {
        private IItemBlock block;
        private IPlayer player;
        private Rectangle rect;

        public BlockItemCommand(IItemBlock block, IPlayer player, Rectangle rect)
        {
            this.block = block;
            this.player = player;
            this.rect = rect;
        }

        public void Execute()
        {
            block.MakeItem(player);
        }
    }
}
