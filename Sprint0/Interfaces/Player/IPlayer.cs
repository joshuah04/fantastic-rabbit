using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces.Player
{
    public interface IPlayer
    {
        public bool Landed { get; }
        public Effect Shader { get; }
        public int PlayerIndex { get; }
        public int SpriteColor { get; }
        public IPlayerDirectionState CurrentDirection { get; }
        public IPlayerPoseState CurrentPose { get; }
        public IPlayerPowerState CurrentPower { get; }
        public Vector2 CurrentPosition { get; }
        public Vector2 CurrentVelocity { get; }

        public void SetDirection(IPlayerDirectionState direction);

        public void SetPose(IPlayerPoseState pose);

        public void SetPower(IPlayerPowerState power);

        public void SetVelocity(float xVelocity, float yVelocity);

        public void SetPosition(float xPosition, float yPosition);

        public void SetLandedState(bool isLanded);

        public void SetColor(int color);

        public void SetShader(ContentManager content);

        public string GetColorName();

        public void SetVertBouncePosition(int offset);

        public void SetHoriBouncePosition(int offset);

        public void ShootProjectile(ProjectileManager projectileManager);

        public void TakeDamage();

        public void Die();

        public int GetLives();

        public void AddLife();

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

        public void enterWarp(Rectangle rect);

        public void KillEnemy();

        public void OverridePose(IPlayerPoseState poseState);

        public void ResetState();
    }
}
