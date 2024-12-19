using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Collision.PlayerBlockCollision
{
    public class SetLevelClearedCommand : ICommand
    {
        FlagPole flagPole;
        public SetLevelClearedCommand(FlagPole flagPole, Rectangle rect) 
        {
            this.flagPole = flagPole;
        }

        public void Execute()
        {
            flagPole.setLevelCleared();
        }
    }
}
