using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> pressedKeyboardMappings;
        private Dictionary<Keys, ICommand> unpressedKeyboardMappings;
        private List<Keys> usedKeys;
        /* Track pressed keys for edge case where animation should continue after a different key is pressed */
        private List<Keys> pressedKeys;
        private KeyboardState oldState;

        public KeyboardController()
        {
            pressedKeyboardMappings = new Dictionary<Keys, ICommand>();
            unpressedKeyboardMappings = new Dictionary<Keys, ICommand>();
            usedKeys = new List<Keys>();
            pressedKeys = new List<Keys>();
            oldState = Keyboard.GetState();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            pressedKeyboardMappings.Add(key, command);
            if (!usedKeys.Contains(key)) usedKeys.Add(key);
        }

        public void RegisterUncommand(Keys key, ICommand command)
        {
            unpressedKeyboardMappings.Add(key, command);
            if (!usedKeys.Contains(key)) usedKeys.Add(key);
        }

        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();

            if (pressedKeys.Count > 0)
            {
                foreach (Keys key in pressedKeys)
                {
                    if (key == Keys.Z || key == Keys.N) break;
                    if (pressedKeyboardMappings.ContainsKey(key))
                    {
                        pressedKeyboardMappings[key].Execute();
                    }
                }
            }

            foreach (Keys key in usedKeys)
            {
                if (pressedKeyboardMappings.ContainsKey(key) && ((oldState.IsKeyUp(key) && newState.IsKeyDown(key))))
                {
                    pressedKeyboardMappings[key].Execute();
                    if (!pressedKeys.Contains(key)) pressedKeys.Add(key);
                }
                else if (oldState.IsKeyDown(key) && newState.IsKeyUp(key))
                {
                    unpressedKeyboardMappings[key].Execute();
                    if (pressedKeys.Contains(key)) pressedKeys.Remove(key);
                }
            }
            oldState = newState;
        }
    }

}