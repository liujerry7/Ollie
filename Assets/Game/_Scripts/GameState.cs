using UnityEngine;

public class GameState : State
{
    protected Game game;

    public GameState(Game newGame)
    {
        game = newGame;
    }
}
