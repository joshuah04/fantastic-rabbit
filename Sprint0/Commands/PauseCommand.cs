﻿using Sprint0;
public class PauseCommand : ICommand
{
    private Game1 myGame;

    public PauseCommand(Game1 game)
    {
        this.myGame = game;
    }

    public void Execute()
    {
    }
}