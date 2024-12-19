using Sprint0.Interfaces.Player;
using Sprint0.MarioStates.DirectionStates;
using Sprint0.MarioStates.PoseStates;

namespace Sprint0.Commands.Player
{
    public class LeftCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public LeftCommand(IPlayer player)
        {
            //this.playerIndex = playerIndex;
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            player.SetDirection(new LeftDirectionState(player));
            player.SetPose(new RunState(player));
        }
    }
}

