using Microsoft.Xna.Framework;
using Sprint0.MarioStates.PoseStates;
using Sprint0.Interfaces.Player;

namespace Sprint0.Commands.Collision.PlayerBlockCollision
{
    public class PlayerBounceUpCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        private Rectangle rect;
        public PlayerBounceUpCommand(IPlayer player, Rectangle rect)
        {
            //this.playerIndex = playerIndex;
            this.player = player;
            this.rect = rect;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            int setback = -(rect.Height);
            player.SetVertBouncePosition(setback);
            player.SetLandedState(true);
            player.SetPose(new StandState(player));
        }
    }
}

