using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprint0.Interfaces;


// Author:Bladen Siu
//this will manage every projectiles 
namespace Sprint0
{
    public class ProjectileManager
    {
        private List<IProjectile> projectiles;

        public ProjectileManager()
        {
            projectiles = new List<IProjectile>();
        }

        public void AddProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);
            Game1.Instance.GetLevel().AddGameObject(projectile);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var projectile in projectiles)
            {
                projectile.Update(gameTime);
            }
            projectiles.RemoveAll(p => !p.IsAlive);
        }

        /* Draws the sprite at a specified location */
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public IEnumerable<IProjectile> GetProjectiles()
        {
            return projectiles;
        }
    }
}
