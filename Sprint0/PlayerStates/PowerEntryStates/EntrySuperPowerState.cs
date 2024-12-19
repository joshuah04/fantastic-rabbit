using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;
using System;

namespace Sprint0.MarioStates.PowerStates
{
    public class EntrySuperPowerState : IPlayerPowerState
    {
        private IPlayer player;
        static double elapsedTime = 0.0;
        private double sizeChangeTime;

        private String[] sizes;
        private Boolean forward;

        /* Tracks sprite effect needed */
        public int size { get; private set; }

        /* Assign our current reference to the player */
        public EntrySuperPowerState(IPlayer player)
        {
            this.player = player;
            player.SetColor(ColorConstants.NORMAL);

            size = 0;
            forward = true;
            sizeChangeTime = 0.0;
            sizes = new String[] { "Normal", "Medium", "Super" };
        }

        /* Obtain the power string for our composite key */
        public string GetPowerState()
        {
            return sizes[size];
        }

        /* Super mario's sprite is bigger so a small position offset is necessary when entering the state */
        public void EnterState()
        {
            player.SetPosition(player.CurrentPosition.X, player.CurrentPosition.Y - 5);
        }

        public void Update(GameTime gameTime)
        {
            sizeChangeTime += gameTime.ElapsedGameTime.TotalSeconds;
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime > 1.0)
            {
                elapsedTime = 0;
                player.SetPower(new SuperPowerState(player));

            }
            else if (sizeChangeTime >= 0.1)
            {
                sizeChangeTime = 0;
                if (forward)
                {
                    size++;
                    if (size > 2)
                    {
                        size = 2;
                        forward = false;
                    }
                }
                else
                {
                    size--;
                    if (size < 0)
                    {
                        size = 0;
                        forward = true;
                    }
                }
            }
        }
    }
}
