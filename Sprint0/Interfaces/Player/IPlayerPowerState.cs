using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces.Player
{
    public interface IPlayerPowerState
    {
        public string GetPowerState();

        public void EnterState();

        public void Update(GameTime gameTime);
    }
}
