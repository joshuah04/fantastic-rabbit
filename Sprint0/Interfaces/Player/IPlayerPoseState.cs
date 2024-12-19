using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces.Player
{
    public interface IPlayerPoseState
    {
        public string GetPoseState();

        public void EnterState();

        public void Update(GameTime gameTime);

    }
}
