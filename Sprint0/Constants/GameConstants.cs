using System.IO;

namespace Sprint0.Constants
{
    public static class GameConstants
    {
        public const string ContentRootDirectory = "Content";
        public const int DefaultHeight = 400;
        public const int DefaultWidth = 800;

        public const string BackgroundSongPath = "Sound//Level_1-1//mario";
        public const int BackgroundSongDurationSeconds = 184;

        public const string LevelFolderPathWindows = "Content\\Levels\\";
        public const string LevelFolderPathMac = "Content//Levels//";
        public const string LevelFileExtension = ".xml";
        public const string LevelTextureFileSuffix = "_Textures.xml";
        public const string LevelSoundFolderName = "Sounds.xml";
        public const string SoundFolderRoot = "Content/Sound";

        public const int ScreenWidth = 800;
        public const int ScreenHeight = 600;

        public const string BlackStarShader = "BlackStar";
        public const int InitialLives = 3;

        public const int CoinScore = 200;
        public const int EnemyScore = 100;

        public const string CastleLevel = "Level_8-4";
        public const string CastleMusic = "Sound//Level_1-1//castle";
        public const int CastleMusicDurationSeconds = 69;

        public const string levelOne = "Level_1-1";
    }
}
