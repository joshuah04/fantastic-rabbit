using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Sprint0.Players;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Sprint0.Interfaces.Player;
using Sprint0.Interfaces;
using Sprint0.Commands.Player;
using Sprint0.Constants;
using System.Diagnostics;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        // Singleton design pattern
        private static Game1 instance = new Game1();
        public static Game1 Instance { get { return instance; } }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game level and camera
        private Level level;
        private Camera camera;
        private Color backgroundColor;

        #region SpriteFields
        // Sprite fields
        //public Vector2 MarioPosition { get; private set; }
        //public Mario Player { get; private set; }
        public Texture2D CharacterTexture { get; set; }
        public Texture2D EnemyTexture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public SpriteFont Font { get; private set; }
        #endregion

        // Player
        private IPlayer mario;
        private IPlayer toad;
        private List<IPlayer> playerList;

        // Controllers for player
        private KeyboardController keyboardController;

        // Projectile manager for handling projectiles
        public ProjectileManager ProjectileManager { get; private set; }

        // Background music and timer
        private Song backgroundMusic;
        private Song castleMusic;
        public TimeSpan musicDuration { get; private set; } // Public getter, private setter
        public TimeSpan elapsedTime { get; private set; }
        public TimeSpan remainingTime {  get; private set; }
        private bool musicFinished; // Flag to check if the music has finished

        // Camera view dimensions
        public static int Height { get; private set; }
        public static int Width { get; private set; }

        // Screens and UI
        private ScreenManager _screenManager;
        private ScoreScreen _score;
        
        // Level 1 path for resetting level
        private string levelPath = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? GameConstants.LevelFolderPathMac : GameConstants.LevelFolderPathWindows;
        private string levelName = "Level_1-1";

        public Game1()
        {
            // Graphics settings and content root directory
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = GameConstants.ContentRootDirectory;
            ProjectileManager = new ProjectileManager();
            camera = new Camera();
            Height = GameConstants.DefaultHeight;
            Width = GameConstants.DefaultWidth;
        }

        protected override void Initialize()
        {
            backgroundColor = Color.CornflowerBlue;

            // find better place to load spritefont but need to do it before level is initialized
            Font = Content.Load<SpriteFont>("Fonts//Font");

            // Initialize screens and score screen
            _screenManager = new ScreenManager(new Rectangle(0, 0, GameConstants.ScreenWidth, GameConstants.ScreenHeight));

            // Check for OS and set level path accordingly
            string path = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? GameConstants.LevelFolderPathMac : GameConstants.LevelFolderPathWindows;
            level = new Level();
            InitializeLevel(Content, path, levelName);

            // Initialize player and items
            mario = new Mario(0);
            toad = new Toad(1);
            playerList = new List<IPlayer> { mario, toad };
            /* Score is shared through Mario */
            _score = new ScoreScreen(new Rectangle(0, 0, GameConstants.ScreenWidth, GameConstants.ScreenHeight), _screenManager, mario);
            ProjectileManager = new ProjectileManager();

            // Set up keyboard controller and commands
            keyboardController = new KeyboardController();

            // Register commands for player movement and actions
            keyboardController.RegisterCommand(Keys.X, new ExitCommand(this));
            keyboardController.RegisterCommand(Keys.W, new JumpCommand(mario));
            keyboardController.RegisterCommand(Keys.A, new LeftCommand(mario));
            keyboardController.RegisterCommand(Keys.S, new CrouchCommand(mario));
            keyboardController.RegisterCommand(Keys.D, new RightCommand(mario));

            // Commands for stopping player movement after key release
            keyboardController.RegisterUncommand(Keys.W, new UnjumpCommand(mario));
            keyboardController.RegisterUncommand(Keys.A, new UnmoveCommand(mario));
            keyboardController.RegisterUncommand(Keys.S, new UncrouchCommand(mario));
            keyboardController.RegisterUncommand(Keys.D, new UnmoveCommand(mario));

            keyboardController.RegisterCommand(Keys.I, new JumpCommand(toad));
            keyboardController.RegisterCommand(Keys.J, new LeftCommand(toad));
            keyboardController.RegisterCommand(Keys.K, new CrouchCommand(toad));
            keyboardController.RegisterCommand(Keys.L, new RightCommand(toad));

            //// Commands for stopping player movement after key release
            keyboardController.RegisterUncommand(Keys.I, new UnjumpCommand(toad));
            keyboardController.RegisterUncommand(Keys.J, new UnmoveCommand(toad));
            keyboardController.RegisterUncommand(Keys.K, new UncrouchCommand(toad));
            keyboardController.RegisterUncommand(Keys.L, new UnmoveCommand(toad));


            // Reset and exit commands
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            keyboardController.RegisterUncommand(Keys.R, new NoCommand());
            keyboardController.RegisterCommand(Keys.Q, new ExitCommand(this));

            // Player attack commands
            keyboardController.RegisterCommand(Keys.Z, new AttackCommand(mario, ProjectileManager));
            keyboardController.RegisterUncommand(Keys.Z, new NoCommand());
            keyboardController.RegisterCommand(Keys.N, new AttackCommand(toad, ProjectileManager));
            keyboardController.RegisterUncommand(Keys.N, new NoCommand());

            // Add game objects to level
            level.AddGameObject((IGameObject)mario);
            level.AddGameObject((IGameObject)toad);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Load background music and start playing it
            backgroundMusic = Content.Load<Song>(GameConstants.BackgroundSongPath);
            castleMusic = Content.Load<Song>(GameConstants.CastleMusic);
            /*Change to 50% because its too loud currently*/
            MediaPlayer.Volume = 0.50f; 
            MediaPlayer.Play(backgroundMusic);
            musicDuration = TimeSpan.FromSeconds(GameConstants.BackgroundSongDurationSeconds);
            elapsedTime = TimeSpan.Zero;
            musicFinished = false;

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Load screen and score screen content
            _screenManager.LoadContent(Content);
            _score.LoadContent(Content);

            toad.SetPosition(toad.CurrentPosition.X + 10, toad.CurrentPosition.Y);
        }

        protected override void Update(GameTime gameTime)
        {
            if (_screenManager.CurrentState != GameState.Paused)
            {
                if (_screenManager.CurrentState == GameState.GameRunning && playerList.Count > 1)
                {
                    playerList.Remove(toad);
                    level.RemoveGameObject((IGameObject)toad);
                }

                // Update keyboard
                keyboardController.Update();

                // Update level and projectiles
                level.Update(gameTime);
                //ProjectileManager.Update(gameTime);

                // Update music timer
                if (MediaPlayer.State == MediaState.Playing)
                {
                    elapsedTime += gameTime.ElapsedGameTime;
                }
                else if (MediaPlayer.State == MediaState.Stopped)
                {
                    // Restart music and reset timer if it has finished
                    if (!musicFinished)
                    {
                        musicFinished = true;
                        //mario.Die();
                        playLevelMusic();
                        elapsedTime = TimeSpan.Zero;
                    }
                }

                // Calculate remaining time
                remainingTime = musicDuration - elapsedTime;
                _score.Update(remainingTime);

                // Update camera to follow player
                camera.Update(mario);
                // Update shader based on player's color state
                mario.SetShader(Content);
                toad.SetShader(Content);

                // Handle exit if in Exiting state
                if (_screenManager.CurrentState == GameState.Exiting)
                {
                    Exit();
                }

                _screenManager.Update(gameTime);
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // Draw game objects if in GameRunning state
            if (_screenManager.CurrentState == GameState.GameRunning || _screenManager.CurrentState == GameState.Multiplayer)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, transformMatrix: camera.TransformMatrix);
                mario.Draw(_spriteBatch);

                // Draw level and projectiles
                level.Draw(_spriteBatch);
                //ProjectileManager.Draw(_spriteBatch);
                _spriteBatch.End();

                // Draw score screen
                _score.Draw(_spriteBatch);
            }
            else
            {
                // Draw screens if not in GameRunning state
                _screenManager.Draw(_spriteBatch);
            }

            base.Draw(gameTime);
        }

        // Reset game by reinitializing and reloading content
        public void reset()
        {
            level.ClearObjects();
            level = new Level();
            this.Initialize();
            SetBackgroundColor(Color.CornflowerBlue);
        }

        private void playLevelMusic()
        {
            if (levelName == GameConstants.CastleLevel)
            {
                musicDuration = TimeSpan.FromSeconds(GameConstants.CastleMusicDurationSeconds);
                MediaPlayer.Play(castleMusic);
            }
            else
            {
                MediaPlayer.Play(backgroundMusic);
            }
        }

        public void InitializeLevel(ContentManager content, string path, string levelName)
        {
            string textureFile = path + levelName + GameConstants.LevelTextureFileSuffix;
            string contentFile = path + levelName + GameConstants.LevelFileExtension;
            // TODO: Change this to get the correct Sound file path
            string soundFolderPath = Path.Combine(GameConstants.SoundFolderRoot, GameConstants.levelOne);
            string soundXMLFileName = GameConstants.LevelSoundFolderName;

            level.Initialize(content, textureFile, contentFile, soundXMLFileName, soundFolderPath);
        }

        public Level GetLevel()
        {
            return level;
        }

        public void setLevel(string levelName)
        {
            level = new Level();
            foreach (IPlayer player in playerList)
            {
                level.AddGameObject((IGameObject)player);
            }
            MediaPlayer.Stop();
            this.levelName = levelName;
            InitializeLevel(Content, levelPath, levelName);
            playLevelMusic();
            elapsedTime = TimeSpan.Zero;
            musicFinished = false;

        }

        public ScoreScreen GetScoreScreen()
        {
            return _score;
        }

        // Trigger game over state
        public void TriggerGameOver()
        {
            level.ClearObjects();
            _screenManager.ChangeState(GameState.GameOver);
        }

        // Restart current level
        public void RestartLevel()
        {
            level.ClearObjects();
            level = new Level();
            InitializeLevel(Content, levelPath, levelName);
            foreach (IPlayer player in playerList)
            {
                level.AddGameObject((IGameObject)player);
            }
        }

        public void SetBackgroundColor(Color color)
        {
            this.backgroundColor = color;
        }

        public void SetCamera(int leftBound, int rightBound)
        {
            this.camera.SetBounds(leftBound, rightBound);
        }
        public void StopMusic()
        {
            MediaPlayer.Stop();
            musicFinished = true;
        }
    }
}


