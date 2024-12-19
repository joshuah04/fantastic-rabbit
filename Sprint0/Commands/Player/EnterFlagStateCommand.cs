using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;
using Sprint0.Players;
using Sprint0.PlayerStates.PoseStates;

namespace Sprint0.Commands.Player
{
    public class EnterFlagStateCommand : ICommand
    {
        private IPlayer player;
        private Rectangle rect;

        public EnterFlagStateCommand(IPlayer player, Rectangle rect) 
        {  
            this.player = player; 
            this.rect = rect;
        }

        public void Execute() 
        {
            player.SetPose(new FlagState(player));
            Game1.Instance.StopMusic();
        }
    }
}
