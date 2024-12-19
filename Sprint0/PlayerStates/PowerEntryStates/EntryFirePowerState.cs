using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;
using Sprint0.MarioStates.PoseStates;

namespace Sprint0.MarioStates.PowerStates
{
    public class EntryFirePowerState : IPlayerPowerState
    {
        private IPlayer player;
        static double elapsedTime = 0.0;
        private double colorChangeTime;

        /* Tracks sprite effect needed */
        public int spriteColor { get; private set; }
        private int originalColor;

        /* Assign our current reference to the player */
        public EntryFirePowerState(IPlayer player)
        {
            this.player = player;

            spriteColor = ColorConstants.NORMAL;
            originalColor = spriteColor;

            colorChangeTime = 0.0;
        }

        /* Obtain the power string for our composite key */
        public string GetPowerState()
        {
            return "Super";
        }

        /* Super mario's sprite is bigger so a small position offset is necessary when entering the state */
        public void EnterState()
        {
            player.SetPosition(player.CurrentPosition.X, player.CurrentPosition.Y - 5);
            //Game1.Instance.ScreenPaused = true;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 originalVelocity = new Vector2(player.CurrentVelocity.X, player.CurrentVelocity.Y);

            //player.SetPose(new FreezeState(player));
            colorChangeTime += gameTime.ElapsedGameTime.TotalSeconds;
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime > 1.0)
            {
                elapsedTime = 0;
                player.SetPower(new FirePowerState(player));

            }
            else if (colorChangeTime >= 0.1)
            {
                spriteColor++;
                colorChangeTime = 0;
                if (spriteColor > ColorConstants.BLACKSTAR) spriteColor = originalColor;
                player.SetColor(spriteColor);
            }

            player.SetVelocity(originalVelocity.X, originalVelocity.Y);
            player.SetPose(new FallState(player));
        }
    }
}
