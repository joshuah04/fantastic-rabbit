namespace Sprint0
{
    public class ExitCommand : ICommand
    {
        private Game1 myGame;
        /* Constructor */
        public ExitCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            /* Exits program */
            myGame.Exit();
        }
    }
}
