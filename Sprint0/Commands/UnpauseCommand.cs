namespace Sprint0.Commands
{
    internal class UnpauseCommand : ICommand
    {
        private Game1 myGame;

        public UnpauseCommand(Game1 game)
        {
            this.myGame = game;
        }
        public void Execute()
        {
        }
    }
}


