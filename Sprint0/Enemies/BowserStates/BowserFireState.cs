using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.BowserStates
{
    public class BowserFireState : IEnemyBehaviorState
    {
        private Bowser bowser;
        private double fireDelay = 1000.0f;
        private double fireTimer = 200;
        Random rnd;

        public BowserFireState(Bowser bowser) 
        {
            this.bowser = bowser;
            rnd = new Random();
        }

        public void Update(GameTime gameTime)
        {
            fireTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if(fireTimer > fireDelay )
            {
                fireTimer = 0;
                fire();
            }
        }

        private void fire()
        {
            float yOffset = rnd.NextInt64(32);
            Vector2 firePos = new Vector2(bowser.getPos().X, bowser.getPos().Y - 16 + yOffset);
            Game1.Instance.GetLevel().AddObjQueue(new BowserFire(firePos, bowser.getDir()));
        }
    }
}
