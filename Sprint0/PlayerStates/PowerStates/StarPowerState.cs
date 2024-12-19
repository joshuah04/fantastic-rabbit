using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;
using System;

namespace Sprint0.MarioStates.PowerStates
{
    public class StarPowerState : IPlayerPowerState
    {
        private IPlayer player;
        static double elapsedTime = 0.0;
        private double colorChangeIteration;
        /* Needs to have all the powers of its previous state */
        static IPlayerPowerState stateEntered;
        /* Tracks sprite effect needed */
        public int spriteColor { get; private set; }
        private int originalColor;
        public string state { get; private set; }

        /* Assign our current reference to the player */
        public StarPowerState(IPlayer player)
        {
            this.player = player;
            stateEntered = player.CurrentPower;
            state = stateEntered.GetPowerState();

            if (state == "Fire") spriteColor = ColorConstants.FIRE;
            else spriteColor = ColorConstants.NORMAL;

            originalColor = spriteColor;

            String stateEnteredColor = stateEntered.GetPowerState();
            colorChangeIteration = 0.0;

        }

        /* Obtain the power string for our composite key */
        public string GetPowerState()
        {
            return "Star";
        }

        /* Star mario's sprite is bigger so a small position offset is necessary when entering the state */
        public void EnterState()
        {
            //player.SetPosition(player.CurrentPosition.X, player.CurrentPosition.Y - 5);
        }

        public void Update(GameTime gameTime)
        {
            colorChangeIteration += gameTime.ElapsedGameTime.TotalSeconds;
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime > 10.6)
            {
                elapsedTime = 0;
                player.SetPower(stateEntered);
                spriteColor = originalColor;

            }
            else if (colorChangeIteration >= 0.1)
            {
                spriteColor++;
                colorChangeIteration = 0;
                if (spriteColor > ColorConstants.BLACKSTAR) spriteColor = originalColor;
            }
            player.SetColor(spriteColor);
        }
    }
}
