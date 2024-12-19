using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0.Levels
{
    public class GameObjectManager
    {
        private static GameObjectManager instance = new GameObjectManager();
        public static GameObjectManager Instance { get { return instance; } }
        private List<IPlayer> players;
        private List<ICollidable> movingObjects;
        private List<ICollidable> nonMovingObjects;
        private List<IGameObject> gameEffects;
        private CollisionHandler collisionHandler;
        private Queue<IGameObject> objAddQueue;
        private Queue<IGameObject> objRemoveQueue;
        /*
        For enemies bc death animations
        */
        private List<IGameObject> dyingObjects;

        public GameObjectManager()
        {
            players = new List<IPlayer>();
            movingObjects = new List<ICollidable>();
            nonMovingObjects = new List<ICollidable>();
            gameEffects = new List<IGameObject>();
            collisionHandler = new CollisionHandler();
            objAddQueue = new Queue<IGameObject>();
            objRemoveQueue = new Queue<IGameObject>();
            dyingObjects = new List<IGameObject>();
        }

        public void Update(GameTime gameTime)
        {
            while (objAddQueue.Count > 0) AddGameObject(objAddQueue.Dequeue());
            while (objRemoveQueue.Count > 0) RemoveGameObject(objRemoveQueue.Dequeue());
            
            foreach (IPlayer player in players) player.Update(gameTime);
            foreach (ICollidable mover in movingObjects) mover.Update(gameTime);
            foreach (ICollidable nonmover in nonMovingObjects) nonmover.Update(gameTime);
            foreach (IGameObject effect in gameEffects) effect.Update(gameTime);
            foreach (IGameObject dyingObject in dyingObjects) dyingObject.Update(gameTime);

            /*Only removes it after death animation is done(when IsAlive is false)*/
            dyingObjects = dyingObjects.Where(obj => obj.IsAlive).ToList();
            collisionHandler.CheckCollisions(GetMovers(), GetNonMovers());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject effect in gameEffects) effect.Draw(spriteBatch);
            foreach (ICollidable mover in movingObjects) mover.Draw(spriteBatch);
            foreach (IPlayer player in players)
            {
                player.Shader.CurrentTechnique.Passes[0].Apply();
                player.Draw(spriteBatch);
            }
            foreach (ICollidable nonmover in nonMovingObjects) nonmover.Draw(spriteBatch);
            foreach (IGameObject dyingObject in dyingObjects) dyingObject.Draw(spriteBatch);
        }

        public void AddGameObject(IGameObject gameObject)
        {
            Type[] interfaces = gameObject.GetType().GetInterfaces();

            if (interfaces.Contains(typeof(IPlayer)))
            {
                players.Add((IPlayer)gameObject);
                return;
            }

            if (interfaces.Contains(typeof(ICollidable)))
            {
                AddCollidable((ICollidable)gameObject);
                return;
            }

            // gameObject does not fall into any of the other lists, must be a gameEffect
            gameEffects.Add(gameObject);
        }

        public void AddCollidable(ICollidable collidable)
        {
            if (collidable.isMover()) movingObjects.Add(collidable);
            else nonMovingObjects.Add(collidable);
        }

        public void RemoveGameObject(IGameObject gameObject)
        {
            Type[] interfaces = gameObject.GetType().GetInterfaces();

            if (interfaces.Contains(typeof(IPlayer)))
            {
                players.Remove((IPlayer)gameObject);
                return;
            }
            /* Check if gameobject is type of enemy, if so move it to dyingObject list*/
            if (interfaces.Contains(typeof(IEnemy)))
            {
                RemoveCollidable((ICollidable)gameObject);
                dyingObjects.Add(gameObject);
                return;
            }

            if (interfaces.Contains(typeof(ICollidable)))
            {
                RemoveCollidable((ICollidable)gameObject);
                return;
            }

            gameEffects.Remove(gameObject);
        }

        public void RemoveCollidable(ICollidable collidable)
        {
            if (collidable.isMover()) movingObjects.Remove(collidable);
            else nonMovingObjects.Remove(collidable);
        }

        public List<ICollidable> GetMovers()
        {
            List<ICollidable> totalMoversList = new List<ICollidable>();
            foreach (IPlayer player in players)
            {
                totalMoversList.Add((ICollidable)(player));
            }
            totalMoversList.AddRange(movingObjects);

            return totalMoversList;
        }

        public List<ICollidable> GetNonMovers()
        {
            return nonMovingObjects;
        }

        public List<IPlayer> GetPlayers()
        {
            return players;
        }

        public List<IGameObject> GetGameEffects()
        {
            return gameEffects;
        }
        public void ClearAll()
        {
            players.Clear();
            movingObjects.Clear();
            nonMovingObjects.Clear();
            gameEffects.Clear();
            objAddQueue.Clear();
            objRemoveQueue.Clear();
            dyingObjects.Clear();
        }

        public void AddQueue(IGameObject gameObject)
        {
            objAddQueue.Enqueue(gameObject);
        }

        public void RemoveQueue(IGameObject gameObject)
        {
            objRemoveQueue.Enqueue(gameObject);
        }
    }
}
