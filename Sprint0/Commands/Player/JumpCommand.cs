using Sprint0.MarioStates.PoseStates;
using Sprint0.Interfaces.Player;

namespace Sprint0.Commands.Player
{
    public class JumpCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public JumpCommand(IPlayer player)
        {
            //this.playerIndex = playerIndex;
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            player.SetPose(new JumpState(player));
        }
    }
}

