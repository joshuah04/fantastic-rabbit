using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sound;
using Sprint0.Constants;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class Enemy : IEnemy, IGameObject, ICollidable
    {
        protected IEnemyState currentState;
        public EnemyStates currentEnemyState { get; private set; }
        protected ISprite sprite;
        public Vector2 Position { get; set; }
        public bool IsAlive { get; set; }


        public Enemy(Vector2 initialPosition)
        {
            Position = initialPosition;
            IsAlive = true;
        }

        public void ChangeState(IEnemyState newState)
        {
            if (currentEnemyState != EnemyStates.GoombaDeadState || currentEnemyState != EnemyStates.KoopaDeadState)
            {
                currentState = newState;
                currentState.Enter(this);
            }
        }

        public void SetSprite(ISprite newSprite)
        {
            sprite = newSprite;
        }
        public virtual void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                currentState.Update(gameTime);
            }

            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }
        public Rectangle GetHitBox()
        {
            return sprite.GetDestinationRectangle(Position);
        }

        public void TakeDamage()
        {
            currentState.TakeDamage();
        }

        public bool isMover()
        {
            return true;
        }

        public async void Die()
        {
            /* If statement helps prevent adding score multiple times */
            Game1.Instance.GetLevel().RemoveObjQueue(this);
            if (this.IsAlive)
            {
                Game1.Instance.GetScoreScreen().UpdateScore(GameConstants.EnemyScore);
                Game1.Instance.GetScoreScreen().KillCount();
            }
            SoundManager.Instance.PlaySound("stomp");
            currentState.TakeDamage();
            await Task.Delay(EnemyConstants.DeathDelay);
            IsAlive = false;      
        }

        public virtual string GetCollisionClass()
        {
            return "enemy";
        }

        public void SetCurrentEnemyState(EnemyStates item) 
        {
            currentEnemyState = item;
        }
    }
}


