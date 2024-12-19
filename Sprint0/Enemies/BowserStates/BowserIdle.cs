using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.BowserStates
{
    public class BowserIdle : IEnemyBehaviorState
    {
        public BowserIdle() 
        {
        
        }
        public void Update(GameTime gameTime)
        {
            // Idle State does not update
        }

    }
}
