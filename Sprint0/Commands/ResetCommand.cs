namespace Sprint0
{
    internal class ResetCommand : ICommand
    {
        private Game1 myGame;
        
        public ResetCommand (Game1 game)
        {
            this.myGame = game;
        }
        public void Execute()
        {
            myGame.reset();
        }
    }
}
