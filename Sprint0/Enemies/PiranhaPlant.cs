using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.PiranhaPlantStates;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class PiranhaPlant : IEnemy, IGameObject, ICollidable
    {
        private Vector2 piranhaPos;
        private ISprite piranhaSprite;
        private Rectangle piranhaHitbox;
        private Vector2 initialPos;
        private IEnemyBehaviorState piranhaBehaviorState;
        public bool IsAlive { get; set; }

        public PiranhaPlant(Vector2 piranhaPos)
        {
            this.piranhaPos = new Vector2(piranhaPos.X + 8, piranhaPos.Y);
            this.piranhaSprite = SpriteFactory.Instance.getSpriteById("PiranhaPlant", 150.0f);
            piranhaHitbox = new Rectangle((int)piranhaPos.X + 2, (int)piranhaPos.Y + 12, 12, 20);
            this.initialPos = piranhaPos;
            this.piranhaBehaviorState = new PiranhaDown(this);
            this.IsAlive = true;
        }

        

        public void Die()
        {
            Game1.Instance.GetLevel().RemoveObjQueue(this);
            IsAlive = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            piranhaSprite.Draw(spriteBatch, piranhaPos);
        }

        public string GetCollisionClass()
        {
            return "unstompableEnemy";
        }

        public Rectangle GetHitBox()
        {
            return piranhaHitbox;
        }

        public bool isMover()
        {
            return true;
        }

        public void Update(GameTime gameTime)
        {
            piranhaSprite.Update(gameTime);

            piranhaBehaviorState.Update(gameTime);
        }

        public void movePiranhaPlant(Vector2 adjustment)
        {
            piranhaPos += adjustment;
            piranhaHitbox.X += (int)adjustment.X;
            piranhaHitbox.Y += (int)adjustment.Y;
        }

        public Vector2 getPos()
        {
            return piranhaPos;
        }

        public Vector2 getInitialPos()
        {
            return initialPos;
        }

        internal void changeState(IEnemyBehaviorState newPiranhaBehaviorState)
        {
            this.piranhaBehaviorState = newPiranhaBehaviorState;
        }
    }
}
