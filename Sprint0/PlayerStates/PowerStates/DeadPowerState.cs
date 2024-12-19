using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;

namespace Sprint0.MarioStates.PowerStates
{
    public class DeadPowerState : IPlayerPowerState
    {
        private IPlayer player;
        public int Frame { get; set; }

        /* Assign our current reference to the player */
        public DeadPowerState(IPlayer player)
        {
            this.player = player;
            Frame = 0;
        }

        /* Obtain the power string for our composite key */
        public string GetPowerState()
        {
            return "Dead";
        }

        /* Get the new sprite from the sprite factory */
        public void EnterState()
        {
            //float frame = 0.5f;
            //player.MarioSprite = SpriteFactory.Instance.getSpriteById("DeadMario", frame);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
