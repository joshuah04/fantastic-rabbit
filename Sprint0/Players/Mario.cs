using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces.Player;
using Sprint0.Interfaces;
using Sprint0.MarioStates.PowerStates;
using Sprint0.MarioStates.DirectionStates;
using Sprint0.MarioStates.PoseStates;
using Sprint0.Sound;
using Sprint0.Constants;
using System.Reflection.Metadata.Ecma335;
using System.Net.Mime;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using Sprint0.PlayerStates.PoseStates;

namespace Sprint0.Players
{
    public class Mario : IPlayer, IGameObject, ICollidable
    {
        /* Mario's initial states */
        public IPlayerDirectionState CurrentDirection { get; private set; }
        public IPlayerPoseState CurrentPose { get; private set; }
        public IPlayerPowerState CurrentPower { get; private set; }

        /* Keeps track of previous state to see if a new sprite is needed */
        private string prevState;
        private string prevPower;
        private float animationDelay = MarioConstants.AnimationDelay;

        /* Keeps track of current sprite & physics */
        private ISprite MarioSprite;
        public Vector2 CurrentPosition { get; set; }
        public Vector2 CurrentVelocity { get; private set; }

        /* Keeps track of ground - will be removed when collision is working */
        public int OriginalY { get; private set; }
        public int PrevXPos { get; private set; }

        /* Potential use down the line */
        public int lives { get; private set; }

        private const float DamageCooldownTime = MarioConstants.DamageCooldownTime;

        private float elapsedCooldownTime;

        private bool isCooldownActive;

        private const float SuperInvulnerabilityDuration = MarioConstants.SuperInvulnerabilityDuration;

        private float invulnerabilityTimer;

        private bool isInvulnerable;

        public bool IsAlive { get; private set; }
        public bool Landed { get; private set; }
        public int SpriteColor { get; private set; }
        public int PlayerIndex { get; private set; }
        public Effect Shader { get; private set; }

        /* All possible colors Mario can take specifically */
        private string[] colors = MarioConstants.Colors;

        private const int deathPositionY = MarioConstants.DeathPositionY;
        private bool isDying;
        private float deathTimer;
        private const float DeathDelay = 1f;

        public Mario(int playerIndex)
        {
            //Game1.Instance.GetLevel().AddGameObject(this);
            PlayerIndex = playerIndex;

            /* Set Mario's initial states */
            CurrentDirection = new RightDirectionState(this);
            CurrentPose = new StandState(this);
            CurrentPower = new NormalPowerState(this);
            
            /* Set starting sprite to a right-facing, standing still, regular powered Mario */
            MarioSprite = SpriteFactory.Instance.getSpriteById("MarioRightStandNormal", animationDelay);
            prevState = "MarioRightStandNormal";
            prevPower = "Normal";

            /* Set starting position on screen */
            CurrentPosition = new Vector2(MarioConstants.InitialPositionX, MarioConstants.InitialPositionY);
            OriginalY = MarioConstants.InitialPositionY;
            PrevXPos = MarioConstants.InitialPositionX;

            /* No movement at first */
            CurrentVelocity = new Vector2(0, 0);

            // Mario is alive
            IsAlive = true;
            Landed = true;
            SpriteColor = 0;
            lives = MarioConstants.StartingLives;
            elapsedCooldownTime = 0f;
            isCooldownActive = false;
            isDying = false;
            deathTimer = 0f;
        }

        /* Sets Mario's direction: left or right */
        public void SetShader(ContentManager content)
        {
            Shader = content.Load<Effect>(GetColorName());
        }

        /* Sets Mario's direction: left or right */
        public void SetDirection(IPlayerDirectionState direction)
        {
            CurrentDirection = direction;
        }

        /* Sets Mario's pose */
        public void SetPose(IPlayerPoseState pose)
        {
            // Ignores pose changes when in the flag state
            if (CurrentPose.GetPoseState().Equals("Flag")) return;
            CurrentPose = pose;
        }

        public void OverridePose(IPlayerPoseState pose)
        {
            CurrentPose = pose;
        }

        /* Sets Mario's power state */
        public void SetPower(IPlayerPowerState power)
        {
            if (power.GetPowerState() == "Star")
            {
                isInvulnerable = true;
                invulnerabilityTimer = MarioConstants.SuperInvulnerabilityDuration;
            }
            CurrentPower = power;
        }

        public void SetVelocity(float xVelocity, float yVelocity)
        {
            CurrentVelocity = new Vector2(xVelocity, yVelocity);
        }

        public void SetLandedState(bool isLanded)
        {
            Landed = isLanded;
        }

        public void SetColor(int color)
        {
            SpriteColor = color;
        }

        public string GetColorName()
        {
            return MarioConstants.Colors[SpriteColor];
        }

        public void TakeDamage()
        {
            /* Check if cooldown for taking damage */
            if (isCooldownActive || isInvulnerable)
            {
                return;
            }

            // Proceed with damage logic
            if (CurrentPower.GetPowerState() == "Normal")
            {

                SoundManager.Instance.PlaySound("toadScreaming");
                CurrentPower = new DeadPowerState(this);
                isDying = true;
                deathTimer = 0f;
            }
            else if (CurrentPower.GetPowerState() == "Super")
            {
                CurrentPower = new NormalPowerState(this);
            }
            else if (CurrentPower.GetPowerState() == "Fire" || CurrentPower.GetPowerState() == "Doctor")
            {
                CurrentPower = new SuperPowerState(this);
            }

            /* Enable I-Frame */
            isCooldownActive = true;
            elapsedCooldownTime = 0f;
        }

        public void SetPosition(float newXPosition, float newYPosition)
        {
            CurrentPosition = new Vector2(newXPosition, newYPosition);
        }

        public void SetVertBouncePosition(int setback)
        {
            // Goal is for Mario to go back to a non-intersect position
            CurrentPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y + setback);
            SetVelocity(CurrentVelocity.X, 0);
        }

        public void SetHoriBouncePosition(int setback)
        {
            // Goal is for Mario to go back to a non-intersect position
            CurrentPosition = new Vector2(CurrentPosition.X + setback, CurrentPosition.Y);
            SetVelocity(0, CurrentVelocity.Y);
        }

        /* Update Mario with new states and physics based on user input */
        public void Update(GameTime gameTime)
        {
            // Handle Mario's death animation and logic
            if (isDying)
            {
                deathTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                MarioSprite = SpriteFactory.Instance.getSpriteById("DeadMario", animationDelay);
                if (deathTimer >= DeathDelay)
                {
                    Die();
                    isDying = false;
                }
                return;
            }

            // Update Mario's directional, pose, and power states
            CurrentDirection.Update();
            CurrentPose.Update(gameTime);
            CurrentPower.Update(gameTime);

            // If Mario falls off the level, trigger death logic
            if (CurrentPosition.Y >= deathPositionY)
            {
                Die();
                return;
            }

            // Handle invulnerability timer
            if (isInvulnerable)
            {
                invulnerabilityTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Reset invulnerability if the timer expires
                if (invulnerabilityTimer <= 0)
                {
                    isInvulnerable = false;

                    // Transition out of StarPowerState if active
                    if (CurrentPower is StarPowerState)
                    {
                        SetPower(GetPowerStateFromString(prevPower)); // Reset to the previous power state
                    }
                }
            }

            // Handle cooldown for taking damage
            if (isCooldownActive)
            {
                elapsedCooldownTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Reset cooldown state if the timer expires
                if (elapsedCooldownTime >= DamageCooldownTime)
                {
                    isCooldownActive = false;
                    elapsedCooldownTime = 0f;
                }
            }

            // Update Mario's sprite based on the current state
            string drawPower = CurrentPower.GetPowerState();
            StarPowerState power = CurrentPower as StarPowerState;

            // Special handling for Star Power state
            if (power != null)
            {
                drawPower = power.state;
            }

            // Compose the sprite key based on Mario's current state
            string compKey = "Mario" + CurrentDirection.GetDirectionState() + CurrentPose.GetPoseState() + drawPower;

            // Update Mario's sprite if the state has changed
            if (prevState != compKey)
            {
                MarioSprite = SpriteFactory.Instance.getSpriteById(compKey, animationDelay);
                prevState = compKey;
                prevPower = drawPower;
            }
            else
            {
                // Update sprite animation if state hasn't changed
                MarioSprite.Update(gameTime);
            }
        }


        /* Draw current Mario sprite */
        public void Draw(SpriteBatch spriteBatch)
        {
            MarioSprite.Draw(spriteBatch, CurrentPosition);
        }

        public void ShootProjectile(ProjectileManager projectileManager)
        {
            if (CurrentPower is FirePowerState)
            {
                IPlayerDirectionState direction = CurrentDirection;
                float fireballLifespan = MarioConstants.FireballLifespan;
                var fireball = new Projectile(CurrentPosition, direction, fireballLifespan);
                projectileManager.AddProjectile(fireball);
                SoundManager.Instance.PlaySound("fireball");
            }
        }

        public Rectangle GetHitBox()
        {
            return MarioSprite.GetDestinationRectangle(CurrentPosition);
        }

        public string GetCollisionClass()
        {
            if(CurrentPose is CrouchState)
            {
                return MarioConstants.CROUCH_COLLISION_CLASS;
            }
            if (CurrentPose is FlagState)
            {
                return MarioConstants.FLAG_COLLISION_CLASS;
            }
            if (isCooldownActive)
            {
                return "invulnerable";
            }
            return "player";
        }

        public void Die()
        {
            lives--;
            IsAlive = false;
            Landed = true;
            Game1.Instance.RestartLevel();
            Game1.Instance.GetLevel().resetPlayers();
            if (lives < 0)
            {
                Game1.Instance.TriggerGameOver();
                lives = MarioConstants.StartingLives;
            }
        }

        public void ResetState()
        {
            IsAlive = true;
            CurrentPower = new NormalPowerState(this);
            SetPosition(MarioConstants.RespawnPositionX, MarioConstants.RespawnPositionY);
        }

        public Boolean isMover()
        {
            return true;
        }

        public void enterWarp(Rectangle rect)
        {
            // TBD
        }

        public int GetLives()
        {
            return lives;
        }

        //one up powerup
        public void AddLife()
        {
            lives++;
        }
        public void KillEnemy()
        {
            isInvulnerable = true; // Enable invulnerability
            invulnerabilityTimer = SuperInvulnerabilityDuration; // Set the duration
        }


        private IPlayerPowerState GetPowerStateFromString(string stateKey)
        {
            return stateKey switch
            {
                "Normal" => new NormalPowerState(this),
                "Super" => new SuperPowerState(this),
                "Fire" => new FirePowerState(this),
                "Star" => new StarPowerState(this),
                "Doctor" => new DoctorPowerState(this),
                _ => new NormalPowerState(this) // default case, go back to normal
            };
        }
    }
}
