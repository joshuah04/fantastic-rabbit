using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0
{
    public class ScoreScreen : Screen
    {
        private SpriteFont font;
        private int Score;
        private int Lives;
        private int EnemiesKilled;
        private IPlayer player;
        private int coinCounter;
        private string remainingTime;

        public ScoreScreen(Rectangle screenSize, ScreenManager screenManager, IPlayer player)
            : base(screenSize)
        {
            this.player = player;
            Score = ScreenConstants.InitialScore;
            EnemiesKilled = ScreenConstants.InitialEnemiesKilled;
            remainingTime = "00:00"; // default time
            coinCounter = 0;
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>(ScreenConstants.FontPath);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, ScreenConstants.ScoreLabel + Score,
                new Vector2(ScreenSize.Width / 2 - ScreenConstants.ScorePositionX, ScreenConstants.LabelPositionY), Color.White);
            spriteBatch.DrawString(font, ScreenConstants.KilledLabel + EnemiesKilled,
                new Vector2(ScreenSize.Width / 2 - ScreenConstants.KilledPositionX, ScreenConstants.LabelPositionY), Color.White);
            spriteBatch.DrawString(font, ScreenConstants.LivesLabel + player.GetLives(),
                new Vector2(ScreenSize.Width / 2 - ScreenConstants.LivesPositionX, ScreenConstants.LabelPositionY), Color.White);
            spriteBatch.DrawString(font, ScreenConstants.CoinsLabel + GetCoins(),
                new Vector2(ScreenSize.Width / 2 - ScreenConstants.CoinsPositionX, ScreenConstants.LabelPositionY), Color.White);
            spriteBatch.DrawString(font, ScreenConstants.TimeLabel + remainingTime,
                new Vector2(ScreenSize.Width / 2 - ScreenConstants.TimePositionX, ScreenConstants.LabelPositionY), Color.White);

            spriteBatch.End();
        }

        public void Update(TimeSpan remainingTime)
        {
            /*
            Format the time as "mm:ss"
            */
            this.remainingTime = remainingTime.ToString(@"mm\:ss");
        }

        public void UpdateScore(int addScore)
        {
            Score += addScore;
        }

        public void MarioLives()
        {
            Lives--;
        }

        public void OneUp()
        {
            player.AddLife();
        }

        public void KillCount()
        {
            EnemiesKilled++;
        }

        public void AddCoinToScore()
        {
            coinCounter++;
        }

        public int GetCoins()
        {
            return coinCounter;
        }

        public void RemoveCoinFromScore(int coin)
        {
            coinCounter -= coin;
        }

        //public void ResetScoreScreen()
        //{
        //    Score = ScreenConstants.InitialScore;
        //    EnemiesKilled = ScreenConstants.InitialEnemiesKilled;
        //    remainingTime = "00:00"; // default time
        //    coinCounter = 0;
        //}
    }
}
