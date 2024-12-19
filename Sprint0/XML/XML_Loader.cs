using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection;
using Sprint0.Enemies;
using Sprint0.Constants;
using Sprint0.Interfaces;
using Sprint0.Blocks;
using Sprint0.Items;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Sprint0.GameEffects;
using Sprint0.Interfaces.Player;

namespace Sprint0.XML
{
    public class XML_Loader
    {
        private static XML_Loader instance = new XML_Loader();
        public static XML_Loader Instance { get { return instance; } }

        private Dictionary<String, ConstructorInfo[]> tileMappings;
        public XML_Loader() 
        {
            tileMappings = new Dictionary<String, ConstructorInfo[]>();
            tileMappings.Add("koopa", typeof(Koopa).GetConstructors());
            tileMappings.Add("goomba", typeof(Goomba).GetConstructors());
            tileMappings.Add("ghost", typeof(Ghost).GetConstructors());
            tileMappings.Add("brickBlock", typeof(BrickBlock).GetConstructors());
            tileMappings.Add("solidBlock", typeof(SolidBlock).GetConstructors());
            tileMappings.Add("questionBlock", typeof(QuestionBlock).GetConstructors());
            tileMappings.Add("shopBlock", typeof(ShopBlock).GetConstructors());
            tileMappings.Add("groundBlock", typeof(GroundBlock).GetConstructors());
            tileMappings.Add("smallPipe", typeof(SmallPipe).GetConstructors());
            tileMappings.Add("mediumPipe", typeof(MediumPipe).GetConstructors());
            tileMappings.Add("largePipe", typeof(LargePipe).GetConstructors());
            tileMappings.Add("emptyBlock", typeof(EmptyBlock).GetConstructors());
            tileMappings.Add("star", typeof(StarPower).GetConstructors());
            tileMappings.Add("fireflower", typeof(FireFlower).GetConstructors());
            tileMappings.Add("mushroom", typeof(Mushroom).GetConstructors());
            tileMappings.Add("oneup", typeof(OneUp).GetConstructors());
            tileMappings.Add("fireball", typeof(Projectile).GetConstructors());
            tileMappings.Add("brickDebris", typeof(BrickBlockDebris).GetConstructors());
            tileMappings.Add("coin", typeof(Coin).GetConstructors());
            tileMappings.Add("flagPole", typeof(FlagPole).GetConstructors());
            tileMappings.Add("backgroundDecor", typeof(BackgroundDecoration).GetConstructors());
            tileMappings.Add("leftPipe", typeof(LeftPipe).GetConstructors());
            tileMappings.Add("upConnectorPipe", typeof(UpConnectingPipe).GetConstructors());
            tileMappings.Add("castleBrick", typeof(CastleBrick).GetConstructors());
            tileMappings.Add("upPipe", typeof(UpPipe).GetConstructors());
            tileMappings.Add("lava", typeof(Lava).GetConstructors());
            tileMappings.Add("lavaBlock", typeof(LavaBlock).GetConstructors());
            tileMappings.Add("bridge", typeof(Bridge).GetConstructors());
            tileMappings.Add("stethoscope", typeof(Stethoscope).GetConstructors());
            tileMappings.Add("lavaBall", typeof(LavaBall).GetConstructors());
            tileMappings.Add("bowser", typeof(Bowser).GetConstructors());
            tileMappings.Add("piranhaPlant", typeof(PiranhaPlant).GetConstructors());
        }

        public void Load_Sprite_Data(ContentManager content, string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(fileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ERROR: File not found. " + ex.Message);
                return;
            }

            XmlNode spriteNodes = xmlDoc.SelectSingleNode("//spriteList");

            // Each sprite node has a key, textureName, rows, and columns
            foreach(XmlNode node in spriteNodes)
            {
                string key = node.Attributes["key"].InnerText;
                string textureName = node.Attributes["textureName"].InnerText;
                int rows = Convert.ToInt32(node.Attributes["rows"].InnerText);
                int columns = Convert.ToInt32(node.Attributes["columns"].InnerText);

                Texture2D texture = content.Load<Texture2D>(textureName);

                SpriteFactory.Instance.registerSprite(key, texture, rows, columns);
            }
        }

        public void Load_Level_Data(String fileName, Level level)
        {
            /**
             * Level has a width and height.
             * Width: Number of columns of blocks / items / entities
             * Height: Number of rows of blocks / items / entities
             */

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(fileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ERROR: File not found. " + ex.Message);
                return;
            }

            XmlNode levelNode = xmlDoc.SelectSingleNode("//level");

            string color = levelNode.Attributes["color"].InnerText;
            level.ChangeLevelColor(color);

            int playerXPos = Convert.ToInt32(levelNode.Attributes["playerX"].InnerText);
            int playerYPos = Convert.ToInt32(levelNode.Attributes["playerY"].InnerText);

            List<IPlayer> playersList = level.GetPlayers();

            foreach (IPlayer player in playersList)
            {
                player.SetPosition(playerXPos, playerYPos);
                playerXPos -= 16;
            }

            int leftBound = Convert.ToInt32(levelNode.Attributes["leftBound"].InnerText);
            int rightBound = Convert.ToInt32(levelNode.Attributes["rightBound"].InnerText);

            level.setNextLevel(levelNode.Attributes["nextLevel"].InnerText);

            Game1.Instance.SetCamera(leftBound, rightBound);

            int curRow = 0;
            int curCol = 0;

            foreach(XmlNode row in levelNode.ChildNodes)
            {
                curCol = 0;
                foreach(XmlNode entity in row.ChildNodes)
                {
                    if (entity.Name.Equals("empty"))
                    {
                        curCol++;
                        continue;
                    }

                    List<object> parameters = new List<object>();
                    parameters.Add(new Vector2(curCol * TileConstants.TILE_SIZE, curRow * TileConstants.TILE_SIZE));
                    foreach(XmlAttribute attr in entity.Attributes)
                    {
                        parameters.Add(attr.InnerText);
                    }

                    ConstructorInfo correctConstructor = tileMappings[entity.Name].FirstOrDefault(c => c.GetParameters().Length == parameters.Count);

                    level.AddGameObject((IGameObject)correctConstructor.Invoke(parameters.ToArray()));

                    curCol++;
                }
                curRow++;
            }
            Load_Subworld_Data(xmlDoc, level);
        }

        public void Load_Subworld_Data(XmlDocument subWorldDoc, Level level)
        {
            XmlNode subworldNode = subWorldDoc.SelectSingleNode("//warpMappings");

            foreach(XmlNode warp in subworldNode.ChildNodes)
            {
                string warpName = warp.Attributes["warpName"].InnerText;
                int locationX = Convert.ToInt32(warp.Attributes["locationX"].InnerText);
                int locationY = Convert.ToInt32(warp.Attributes["locationY"].InnerText);
                int cameraLeft = Convert.ToInt32(warp.Attributes["cameraLeft"].InnerText);
                int cameraRight = Convert.ToInt32(warp.Attributes["cameraRight"].InnerText);
                string color = warp.Attributes["backgroundColor"].InnerText;
                level.GetSubWorldManager().AddWarpMapping(warpName, new Vector2(locationX, locationY), cameraLeft, cameraRight, color);
            }
        }

        public void Load_Keyboard_Data(String fileName, KeyboardController controller)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(fileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ERROR: File not found. " + ex.Message);
                return;
            }

            XmlNode keyboardNode = xmlDoc.SelectSingleNode("//keyboardNode");

            foreach (XmlNode commandNode in keyboardNode.ChildNodes)
            {
                // Add the freeze dried command into the keyboard
                Keys key = (Keys)Enum.Parse(typeof(Keys), commandNode.Attributes["key"].InnerText, true);

                Type commandType = Type.GetType(commandNode.Attributes["command"].InnerText);
                ConstructorInfo[] constructors = commandType.GetConstructors();

                List<object> parameters = new List<object>();

                if (commandNode.Attributes["playerIndex"] != null)
                {
                    parameters.Add(commandNode.Attributes["playerIndex"]);
                }

                ConstructorInfo correctConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == parameters.Count);

                if (commandNode.Name.Equals("command"))
                {
                    controller.RegisterCommand(key, (ICommand)correctConstructor.Invoke(parameters.ToArray()));
                }
                else if (commandNode.Name.Equals("uncommand"))
                {
                    controller.RegisterUncommand(key, (ICommand)(correctConstructor.Invoke(parameters.ToArray())));
                }
            }
        }

        public ICollidable CreateItem(string itemType, Vector2 position)
        {
            List<object> parameters = new List<object> { position };
            ConstructorInfo constructor = tileMappings[itemType].FirstOrDefault(c => c.GetParameters().Length == parameters.Count);
            return (ICollidable)constructor.Invoke(parameters.ToArray());
        }
    }
}
