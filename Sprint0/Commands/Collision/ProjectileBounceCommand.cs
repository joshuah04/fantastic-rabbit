using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class ProjectileBounceUpCommand : ICommand
    {
        private IProjectile projectile;
        private Rectangle rect;
        public ProjectileBounceUpCommand(IProjectile projectile, Rectangle rect)
        {
            this.projectile = projectile;
            this.rect = rect;
        }
        public void Execute()
        {
            int setback = -(rect.Height);
            this.projectile.SetVertBouncePosition(setback);
            //this.projectile.BounceUp();

        }
    }
}