using System.Collections.Generic;

namespace Sprint0.Constants
{
    public static class ScreenConstants
    {
        /*EndGame*/
        public const string GameOverTexturePath = "Screen/gameover";
        public const string FontPath = "Fonts/Menu";
        public const string ReturnMessage = "Press Space to return to Main Menu";
        public const int ReturnMessageOffsetX = 200;
        public const int GameOverImageOffsetY = 40;
        public const int ReturnMessagePositionY = 20;

        /* Menu*/
        public const string MenuLogoTexturePath = "Screen/mario_bros_logo";
        public const string CursorTexturePath = "Screen/menu_mushroom";
        public const int MenuLogoPositionY = 60;
        public const int CursorOffsetX = 80;
        public const int MenuItemOffsetX = 45;

        public static readonly Dictionary<string, int> MenuItems = new Dictionary<string, int>
        {
            { "1 Player", 250 },
            { "2 Player", 290 },
            { "Exit Game", 330 }
        };

        /*Score*/
        public const string HeartTexturePath = "Screen/heart";

        public const string ScoreLabel = "Score: ";
        public const string CoinsLabel = "Coins: ";
        public const string KilledLabel = "Killed: ";
        public const string LivesLabel = "Lives: ";
        public const string TimeLabel = "Time: ";

        public const int ScorePositionX = 350;
        public const int KilledPositionX = 200;
        public const int LivesPositionX = 50;
        public const int CoinsPositionX = -100;
        public const int TimePositionX = -250;
        public const int LabelPositionY = 10;

        public const int InitialLives = 2;
        public const int InitialScore = 0;
        public const int InitialEnemiesKilled = 0;
        public const int HeartDistance = 30;
        public const int HeartStartOffsetX = 20;
        public const int HeartPositionY = 15;


    }
}
