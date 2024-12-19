using Microsoft.Xna.Framework;

namespace Sprint0.Enemies
{
    public interface IEnemyState
    {
        void Enter(Enemy enemy); // Called when entering the state
        void Update(GameTime gameTime); // Called every frame
        void Move(); // Define how the enemy moves
        void TakeDamage(); // Define what happens when the enemy gets hit
    }
}