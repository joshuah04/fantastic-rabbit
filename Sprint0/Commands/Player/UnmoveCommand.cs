using Sprint0.Interfaces.Player;
using Sprint0.Levels;
using Sprint0.MarioStates;
using Sprint0.MarioStates.PoseStates;

namespace Sprint0.Commands.Player
{
    public class UnmoveCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public UnmoveCommand(IPlayer player)
        {
            //this.playerIndex = playerIndex;
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            player.SetPose(new StandState(player));
        }
    }
}