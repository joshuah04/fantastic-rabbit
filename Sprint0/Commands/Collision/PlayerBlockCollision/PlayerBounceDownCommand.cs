using Microsoft.Xna.Framework;
using Sprint0.MarioStates.PoseStates;
using Sprint0.Interfaces.Player;

namespace Sprint0.Commands.Collision.PlayerBlockCollision
{
    public class PlayerBounceDownCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        private Rectangle rect;
        public PlayerBounceDownCommand(IPlayer player, Rectangle rect)
        {
            //this.playerIndex = playerIndex;
            this.player = player;
            this.rect = rect;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            int setback = (rect.Height);
            player.SetPose(new FallState(player));
            player.SetVertBouncePosition(setback);
        }
    }
}

