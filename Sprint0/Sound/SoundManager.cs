using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Sprint0.Constants;

namespace Sprint0.Sound
{
    public class SoundManager
    {
        public static SoundManager instance = new SoundManager();
        public static SoundManager Instance { get { return instance; } }

        private Dictionary<string, SoundEffect> soundEffects;

        private SoundManager()
        {
            soundEffects = new Dictionary<string, SoundEffect>();
        }

        public void LoadSoundData(ContentManager content, string levelFolder, string xmlFileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string xmlPath = Path.Combine(levelFolder, xmlFileName);
            try
            {
                xmlDoc.Load(xmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            XmlNode soundNodes = xmlDoc.SelectSingleNode(SoundConstants.SoundListNode);
            foreach (XmlNode node in soundNodes)
            {
                string key = node.Attributes[SoundConstants.SoundKeyAttribute].InnerText;
                string soundFileName = SoundConstants.DefaultSoundFolder + node.Attributes[SoundConstants.SoundFileNameAttribute].InnerText;

                try
                {
                    SoundEffect soundEffect = content.Load<SoundEffect>(soundFileName);
                    soundEffects[key] = soundEffect;
                    Console.WriteLine("Loaded sound: " + key);
                }
                catch (ContentLoadException ex)
                {
                    Console.WriteLine($"Error loading sound '{soundFileName}': {ex.Message}");
                }
            }
        }

        public void PlaySound(string key)
        {
            if (soundEffects.TryGetValue(key, out SoundEffect soundEffect))
            {
                soundEffect.Play();
            }
            else
            {
                Console.WriteLine(SoundConstants.SoundLoadErrorMessage + key);
            }
        }
    }
}
