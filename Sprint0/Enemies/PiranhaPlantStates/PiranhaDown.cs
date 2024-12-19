using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.PiranhaPlantStates
{
    public class PiranhaDown : IEnemyBehaviorState
    {
        private PiranhaPlant piranhaPlant;
        private double idleTimer = 0.0f;
        private double maxIdleTimer = 2000;
        private Vector2 downAdjustment = new Vector2(0, 1);

        public PiranhaDown(PiranhaPlant piranhaPlant)
        {
            this.piranhaPlant = piranhaPlant;
        }

        public void Update(GameTime gameTime)
        {
            idleTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Piranha plant starts moving up
            if (idleTimer > maxIdleTimer)
            {
                piranhaPlant.movePiranhaPlant(downAdjustment);

                if (piranhaPlant.getPos().Y >= piranhaPlant.getInitialPos().Y + 32)
                {
                    piranhaPlant.changeState(new PiranhaUp(piranhaPlant));
                }
            }
        }
    }
}
