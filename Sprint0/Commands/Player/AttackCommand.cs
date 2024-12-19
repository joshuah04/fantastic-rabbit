using Sprint0.Interfaces.Player;
using Sprint0.Levels;

namespace Sprint0.Commands.Player
{
    public class AttackCommand : ICommand
    {
        private IPlayer player;
        private int playerIndex;
        private ProjectileManager projectileManager;

        public AttackCommand(IPlayer player, ProjectileManager projectileManager)
        {
            this.projectileManager = projectileManager;
            //this.playerIndex = player.PlayerIndex;
            this.player = player;
        }
        public void Execute()
        {
            //this.player = Game1.Instance.GetLevel().GetPlayers()[playerIndex];
            player.ShootProjectile(projectileManager);
        }
    }
}

