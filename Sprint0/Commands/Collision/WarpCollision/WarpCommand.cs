using Sprint0.Blocks;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Collision.WarpCollision
{
    public class WarpCommand : ICommand
    {
        private WarpZone warpZone;
        private Rectangle rect;
        public WarpCommand(WarpZone warpZone, Rectangle rect) 
        {
            this.warpZone = warpZone;
            this.rect = rect;
        }
        public void Execute()
        {
            warpZone.Warp();
        }
    }
}
