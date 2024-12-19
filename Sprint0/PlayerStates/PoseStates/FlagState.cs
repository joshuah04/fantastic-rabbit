using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;
using Sprint0.MarioStates.PoseStates;
using Sprint0.Sound;

namespace Sprint0.PlayerStates.PoseStates
{
    public class FlagState : IPlayerPoseState
    {
        private IPlayer player;
        private double timeInFlagState = 0;
        private double timeToLeave = 7200;

        public FlagState(IPlayer player)
        {
            this.player = player;
            player.SetPosition(player.CurrentPosition.X + 6, player.CurrentPosition.Y);
        }

        public void EnterState()
        { 
        }

        public string GetPoseState()
        {
            return "Flag";
        }

        // Moves player down the flagpole
        public void Update(GameTime gameTime)
        {
            timeInFlagState += gameTime.ElapsedGameTime.TotalMilliseconds;
            PlayFlagAnimation();
            if (timeInFlagState > timeToLeave) player.OverridePose(new RunState(player));
        }

        private void PlayFlagAnimation()
        {
            player.SetPosition(player.CurrentPosition.X, player.CurrentPosition.Y + 1);
        }
    }
}
