using System;
using Microsoft.Xna.Framework;
using Sprint0.Enemies;

namespace Sprint0.Commands.Collision.EnemyBlockCollision
{
    public class GoombaDieCommand : ICommand
    {
        private Goomba goomba;
        private Rectangle rect;
        public GoombaDieCommand(Goomba goomba, Rectangle rect)
        {
            this.goomba = goomba;
            this.rect = rect;
        }
        public void Execute()
        {
            goomba.TakeDamage();
            //goomba.Die();
            Console.WriteLine("Gooooomba DIEE");
        }
    }
}