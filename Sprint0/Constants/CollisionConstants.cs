namespace Sprint0.Constants
{
    public static class CollisionConstants
    {
        public const string WARP_COLLISION_TYPE = "warp";

        public const int WARP_WIDTH = 4;
        public const int WARP_HEIGHT = 16;

        /**
         * Warp Offset Calculation
         * 
         * WARP_DOWN_X_OFFSET = (PIPE_WIDTH - WARP_WIDTH) / 2
         * WARP_DOWN_Y_OFFSET = None (for now)
         */
        public const int WARP_DOWN_X_OFFSET = 14;
        public const int WARP_DOWN_Y_OFFSET = -4;

        public const int WARP_LEFT_X_OFFSET = -4;
        public const int WARP_LEFT_Y_OFFSET = 14;

        public const string DOWN_WARP_TYPE = "crouchWarp";
        public const string LEFT_WARP_TYPE = "runWarp";


    }
}
