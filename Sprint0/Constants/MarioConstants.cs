using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Constants
{
    internal class MarioConstants
    {
        public const int InitialPositionX = 5;
        public const int InitialPositionY = 220;
        public const int DeathPositionY = 300;

        public const int RespawnPositionX = 100;
        public const int RespawnPositionY = 220;

        public const float FireballLifespan = 4000f;

        public const float DamageCooldownTime = 1f;
        public const float SuperInvulnerabilityDuration = 3f;

        public const int StartingLives = 3;

        public const float AnimationDelay = 150f;

                // Color Constants
        public const int NORMAL = 0;
        public const int FIRE = 1;
        public const int REDSTAR = 2;
        public const int GREENSTAR = 3;
        public const int BLACKSTAR = 4;

        public static readonly string[] Colors = { "Normal", "Fire", "RedStar", "GreenStar", "BlackStar" };

        public const string CROUCH_COLLISION_CLASS = "crouchingPlayer";
        public const string FLAG_COLLISION_CLASS = "flagPlayer";
    }
}
