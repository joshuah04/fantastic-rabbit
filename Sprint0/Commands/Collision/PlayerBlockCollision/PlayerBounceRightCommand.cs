using Microsoft.Xna.Framework;
using Sprint0.MarioStates.PoseStates;
using Sprint0.Interfaces.Player;

namespace Sprint0.Commands.Collision.PlayerBlockCollision
{
    public class PlayerBounceRightCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        private Rectangle rect;
        public PlayerBounceRightCommand(IPlayer player, Rectangle rect)
        {
            this.player = player;
            this.rect = rect;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            int setback = (rect.Width + 1);
            player.SetPose(new StandState(player));
            player.SetHoriBouncePosition(setback);
        }
    }
}

