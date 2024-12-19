namespace Sprint0.Constants
{
    internal static class BlockConstants
    {
        // Sprite Animation Constants
        public const float AnimationDelay = 150.0f;

        // Bounce Constants
        public const float BounceOffsetInitialValue = 0f;
        public const float BounceSpeed = 1f;
        public const float MaxBounceHeight = 6f;

        // Item Position Offset Constants
        public const int ItemPositionXOffset = 3;

        // Debris Constants
        public const int DebrisTimerDefault = 3;
        public const float DebrisVelocityDefault = 2f;
        public const float DebrisGravity = 1f;
        public const int DebrisPositionOffset = 16;

        // Random Items
        public static readonly string[] itemArray = { "mushroom", "stethoscope", "star", "fireflower", "coin", "oneup"};
        public static readonly double[] probabilities = { 0.50, 0.05, 0.07, 0.2, 0.15, 0.03 };
    }
}
