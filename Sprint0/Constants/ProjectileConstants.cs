namespace Sprint0.Constants
{
    public static class ProjectileConstants
    {
        public const float AnimationDelay = 150.0f;
        public const float FriendlySpeed = 100f; // Horizontal speed

        public const float InitialTimeAlive = 0f;
        /*Might use enemy speed for bowser, not sure yet*/
        public const float EnemySpeed = 200f;
        public const float Gravity = 2f; // Adjust for downward acceleration
        public const float ReverseGravity = Gravity * 10;
        public const int AdditionalSetback = 1;

    }
}
