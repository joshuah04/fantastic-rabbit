using Sprint0.Interfaces.Player;
using Sprint0.MarioStates.DirectionStates;
using Sprint0.MarioStates.PoseStates;

namespace Sprint0.Commands.Player
{
    public class RightCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public RightCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            player.SetDirection(new RightDirectionState(player));
            player.SetPose(new RunState(player));
        }
    }
}

