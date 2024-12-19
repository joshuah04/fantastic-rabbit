using Sprint0.Interfaces.Player;
using Sprint0.MarioStates.PowerStates;

namespace Sprint0.Commands.Player
{
    /* Temp class to change Mario into fire Mario */
    public class NormalCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        public NormalCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            player.SetPower(new NormalPowerState(player));
        }
    }
}

