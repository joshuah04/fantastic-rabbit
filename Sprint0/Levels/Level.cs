using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using Sprint0.Levels;
using Sprint0.Sound;
using Sprint0.XML;
using System;
using System.Collections.Generic;

namespace Sprint0
{
    public class Level
    {
        private GameObjectManager gameObjectManager;
        private SubWorldManager subWorldManager;
        private Dictionary<string, Color> levelColors;
        private int levelState;
        private string nextLevel;

        public Level()
        {
            gameObjectManager = new GameObjectManager();
            subWorldManager = new SubWorldManager();
            levelColors = new Dictionary<string, Color>();
        }

        public void Initialize(ContentManager content, string textureFile, string contentFile, string soundFile, string levelFolder)
        {
            
            levelColors.Add("Underground", Color.Black);
            levelColors.Add("Default", Color.CornflowerBlue);

            XML_Loader.Instance.Load_Sprite_Data(content, textureFile);
            XML_Loader.Instance.Load_Level_Data(contentFile, this);
            SoundManager.Instance.LoadSoundData(content, levelFolder, soundFile);
        }

        public void AddGameObject(IGameObject gameObject)
        {
            gameObjectManager.AddGameObject(gameObject);
        }

        public void RemoveGameObject(IGameObject gameObject)
        {
            gameObjectManager.RemoveGameObject(gameObject);
        }

        public void ClearObjects()
        {
            GameObjectManager.Instance.ClearAll();
        }

        public void Update(GameTime gameTime)
        {
            if(levelState == 0)
            {
                gameObjectManager.Update(gameTime);
            } else
            {
                Game1.Instance.setLevel(nextLevel);
            } 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gameObjectManager.Draw(spriteBatch);
        }

        public List<IPlayer> GetPlayers()
        {
            return gameObjectManager.GetPlayers();
        }

        public SubWorldManager GetSubWorldManager()
        {
            return subWorldManager;
        }

        public void ChangeLevelColor(string color)
        {
            Game1.Instance.SetBackgroundColor(levelColors[color]);
        }

        /**
         * Warps to specified warp location (found using the SubWorldManager)
         * 
         * Should only be able to warp to one place at a time (i.e. when one player
         * takes a warp all other warps are disabled)
         * 
         * The warp should take a few seconds before moving all players to the warp location and
         * moving the camera there.
         */
        public void Warp(string name)
        {
            Tuple<Vector2, int, int, string> warpInfo = subWorldManager.GetWarpSpot(name);
            ChangeLevelColor(warpInfo.Item4);
            Game1.Instance.SetCamera(warpInfo.Item2, warpInfo.Item3);
            foreach (IPlayer player in GetPlayers())
            {
                player.SetPosition(warpInfo.Item1.X, warpInfo.Item1.Y);
            }
        }

        public void AddObjQueue(IGameObject gameObject)
        {
            gameObjectManager.AddQueue(gameObject);
        }

        public void RemoveObjQueue(IGameObject gameObject)
        {
            gameObjectManager.RemoveQueue(gameObject);
        }

        // Bandaid solution NEEDS FIXED
        public void SetLevelState(int state)
        {
            this.levelState = state;
        }

        internal void setNextLevel(string nextLevel)
        {
            this.nextLevel = nextLevel;
        }

        public void resetPlayers()
        {
            foreach(IPlayer player in GetPlayers())
            {
                player.ResetState();
            }
        }
    }
}