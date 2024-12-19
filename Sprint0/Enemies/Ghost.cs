using Microsoft.Xna.Framework;
using Sprint0.Constants;
using System;
using System.Linq;
using Sprint0.Interfaces.Player;

namespace Sprint0.Enemies
{
    public class Ghost : Enemy
    {
        private IPlayer player;
        private Random Rand = new Random();
        public Vector2 startingPosition; 

        public Ghost(Vector2 initialPosition) : base(initialPosition)
        {
            ChangeState(new GhostIdleState()); // Default
            //Console.WriteLine($"Ghost created at position: {initialPosition}");
            startingPosition = initialPosition;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Get the player if not already set or if it's null
            if (player == null)
            {
                player = Game1.Instance.GetLevel().GetPlayers().FirstOrDefault();
                //Console.WriteLine("Player reference acquired.");
            }

            if (player != null)
            {
                //Console.WriteLine($"Player position: {player.CurrentPosition}, Ghost position: {Position}");

                // Adjust ghost behavior based on player position
                if (WithinAttackRange(Position.X))
                {
                    //Console.WriteLine("Player is within attack range. Ghost will chase.");
                    FindRunningDirection(Position.X);
                }
                else if (WithinAlertRange(Position.X))
                {
                    //Console.WriteLine("Player is within alert range. Ghost will wander.");
                    Wandering(); // Random wandering when player is not close
                }
                else
                {
                    //Console.WriteLine("Player is out of range. Ghost remains idle.");
                }
            }
            else
            {
                //Console.WriteLine("No player found.");
            }
        }

        // This helps switch up the ghost's movement so it's mostly random.
        public void Wandering()
        {
            int num = Rand.Next(1, 4);
            //Console.WriteLine($"Ghost is wandering. Randomly chosen action: {num}");

            switch (num)
            {
                case 1:
                    ChangeState(new GhostIdleState());
                    //Console.WriteLine("Ghost is idling.");
                    break;
                case 2:
                    ChangeState(new GhostWalkRightState());
                    //Console.WriteLine("Ghost is walking right.");
                    break;
                case 3:
                    ChangeState(new GhostWalkLeftState());
                    //Console.WriteLine("Ghost is walking left.");
                    break;
                default:
                    break;
            }
        }

        // This function helps switch up how long the ghost remains in that state when out of range.
        public int switchTime()
        {
            int time = Rand.Next(1000, 2000);
            //Console.WriteLine($"Ghost state switch time chosen: {time} ms");
            return time;
        }

        // This function helps find which direction the ghost should run in and switches state accordingly.
        public void FindRunningDirection(float ghost_position)
        {
            if (IsPlayerLeftOfGhost(ghost_position))
            {
                ChangeState(new GhostRunLeftState());
                //Console.WriteLine("Ghost is running left towards the player.");
            }
            else
            {
                ChangeState(new GhostRunRightState());
                //Console.WriteLine("Ghost is running right towards the player.");
            }
        }

        // This function checks if the player is left of the ghost
        public bool IsPlayerLeftOfGhost(float ghost_position)
        {
            bool isLeft = player != null && player.CurrentPosition.X < ghost_position;
            //Console.WriteLine($"Is player left of ghost? {isLeft}");
            return isLeft;
        }

        // Check if the player is within attack range
        public bool WithinAttackRange(float ghost_position)
        {
            bool inRange = player != null &&
                           Math.Abs(player.CurrentPosition.X - ghost_position) <= EnemyConstants.attackRange;
            //Console.WriteLine($"Is player within attack range? {inRange}");
            return inRange;
        }

        // Check if the player is within the ghost's alert range
        public bool WithinAlertRange(float ghost_position)
        {
            bool inRange = player != null &&
                           Math.Abs(player.CurrentPosition.X - ghost_position) <= EnemyConstants.alertRange;
            //Console.WriteLine($"Is player within alert range? {inRange}");
            return inRange;
        }

        //ghost cant die so give it is own collision mapping
        public override string GetCollisionClass()
        {
            return "ghost";
        }

        // Once towards end of game return to start position. 
        public  bool ReturnToStart(float ghost_position) {
            return ghost_position >= startingPosition.X + EnemyConstants.GhostMax;
        }

        public void ResetPosition()
        {
            this.Position = startingPosition;
        }


    }
}
