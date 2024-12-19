using Microsoft.Xna.Framework;
using Sprint0.MarioStates.PowerStates;
using Sprint0.Interfaces.Player;
using Sprint0.Sound;

namespace Sprint0.Commands.Player
{
    public class DoctorCommand : ICommand
    {
        private IPlayer player;
        public DoctorCommand(IPlayer player, Rectangle rect)
        {
            this.player = player;
        }
        public void Execute()
        {
            if (player.CurrentPower.GetPowerState() != "Doctor")
            {
                player.SetPower(new DoctorPowerState(player));
                player.CurrentPower.EnterState();
                SoundManager.Instance.PlaySound("powerup");
            }
        }
    }
}
