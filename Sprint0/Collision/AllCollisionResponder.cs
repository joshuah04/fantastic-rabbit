using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Sprint0.Interfaces;
using System.Runtime.InteropServices;

// handle collision between objects based on xml file
namespace Sprint0.Collision
{
    public class AllCollisionResponder
    {
        private static AllCollisionResponder instance = new AllCollisionResponder();
        public static AllCollisionResponder Instance { get { return instance; } }

        // tuple dictionary for collision response from xml file, <(Object1, Object2, Side), (Command1, Command2)>
        private Dictionary<(string, string, string), (string, string)> objCollisionDict;

        public AllCollisionResponder()
        {
            objCollisionDict = new Dictionary<(string, string, string), (string, string)>();

            // read xml file to create dictionary
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                using (XmlReader reader = XmlReader.Create("Content//Collision//CollisionMapping.xml"))
                {
                    CreateDictionary(reader);
                }
            }
            else
            {
                using (XmlReader reader = XmlReader.Create("Content\\Collision\\CollisionMapping.xml"))
                {
                    CreateDictionary(reader);
                }
            }
        }

        public void CreateDictionary(XmlReader reader)
        {
            objCollisionDict.Clear();
            reader.MoveToContent();

            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name == "obj")
                {
                    string objString = reader.ReadElementContentAsString();
                    string[] content = objString.Split(',');
                    string obj1 = content[0];
                    string obj2 = content[1];
                    string side = content[2];
                    string cmd1 = content[3];
                    string cmd2 = content[4];

                    var key = (obj1, obj2, side);
                    var value = (cmd1, cmd2);
                    objCollisionDict.Add(key, value);
                }
            }
        }

        // handle collision based on collision objects and execute corresponding commands for each object
        public void CollisionResponder(ICollidable obj1, ICollidable obj2, string side, Rectangle rect)
        {
            var key = (obj1.GetCollisionClass(), obj2.GetCollisionClass(), side);

            if (objCollisionDict.TryGetValue(key, out var commands))
            {
                //if (obj1.GetCollisionClass() == "player")
                //{
                //    ExecutePlayerCommand(obj1, rect, commands.Item1);
                //    ExecuteCommand(obj2, rect, commands.Item2);
                //}
                //else
                //{
                ExecuteCommand(obj1, obj2, rect, commands.Item1);
                ExecuteCommand(obj2, obj1, rect, commands.Item2);
               // }
            }
        }

        public void ExecuteCommand(IGameObject obj1, IGameObject obj2, Rectangle rect, string cmd)
        {
            // get command type 
            Type cmdType = Type.GetType(cmd);

            // define contructor parameters
            // THIS NEEDS TO USE THE GetCollisionClass() METHOD TO DETERMINE THE TYPE
            Type[] constructorType1 = { obj1.GetType(), typeof(Rectangle) };
            Type[] constructorType2 = { obj1.GetType(), obj2.GetType(), typeof(Rectangle) };

            // get constructor info based on parameters
            ConstructorInfo constructorInfo1 = cmdType.GetConstructor(constructorType1);
            ConstructorInfo constructorInfo2 = cmdType.GetConstructor(constructorType2);

            if (constructorInfo1 != null)
            {
                // Then we know that the command takes only one obj
                // instantiate command object using constructor
                ICommand command = (ICommand)constructorInfo1.Invoke(new object[] { obj1, rect });
                command.Execute();
            }
            
            if (constructorInfo2 != null)
            {
                // Then we know that the command takes two objs
                ICommand command = (ICommand)constructorInfo2.Invoke(new object[] { obj1, obj2, rect });
                command.Execute();
            }

            // impossible that both are null
        }
    }
}