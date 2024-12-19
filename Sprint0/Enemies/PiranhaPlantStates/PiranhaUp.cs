using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.PiranhaPlantStates
{
    public class PiranhaUp : IEnemyBehaviorState
    {
        private PiranhaPlant piranhaPlant;
        private double idleTimer = 0.0f;
        private double maxIdleTimer = 2000f;
        private Vector2 upAdjustment = new Vector2(0, -1);

        public PiranhaUp(PiranhaPlant piranhaPlant)
        {
            this.piranhaPlant = piranhaPlant;
        }

        public void Update(GameTime gameTime)
        {
            idleTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Piranha plant starts moving up
            if(idleTimer > maxIdleTimer)
            {
                piranhaPlant.movePiranhaPlant(upAdjustment);

                if(piranhaPlant.getPos().Y <= piranhaPlant.getInitialPos().Y)
                {
                    piranhaPlant.changeState(new PiranhaDown(piranhaPlant));
                }
            }
        }
    }
}
