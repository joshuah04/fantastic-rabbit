using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Constants
{
    internal static class EnemyConstants
    {
        // Animation Constants
        public const float AnimationDelay = 150.0f;

        // Movement Constants
        public const float TurnTimer = 2000.0f;
        public const float MoveSpeed = .3f;
        public const float ShellSpeed = 3f;

        // Death Constants
        public const int DeathDelay = 700;

        // Ghost
        public const int attackRange =200;
        public const int alertRange = 400;
        public const float GhostSpeed = 0.15f;

        public const float GhostMax = 480f;
    }
}
