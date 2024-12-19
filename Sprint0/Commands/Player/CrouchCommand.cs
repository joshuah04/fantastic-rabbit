using Sprint0.Interfaces.Player;
using Sprint0.Levels;
using Sprint0.MarioStates.PoseStates;

namespace Sprint0.Commands.Player
{
    public class CrouchCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public CrouchCommand(IPlayer player)
        {
            //this.playerIndex = player.PlayerIndex;
            this.player = player;
        }
        public void Execute()
        {
            if(player.Landed) player.SetPose(new CrouchState(player));
        }
    }
}

