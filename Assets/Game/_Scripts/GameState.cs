using UnityEngine;

public class GameState : State
{
    protected Game game;
    protected Character character;

    public GameState(Game newGame, Character newCharacter)
    {
        game = newGame;
        character = newCharacter;
    }
}
