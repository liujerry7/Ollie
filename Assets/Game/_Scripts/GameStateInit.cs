using UnityEngine;
using UnityEngine.UI;

public class GameStateInit : GameState
{
    public GameStateInit(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Time.timeScale = 1;

        game.gameOver.gameObject.SetActive(false);
        game.gameOver.GetComponentInChildren<Button>().onClick.RemoveAllListeners();

        game.board.Init();
        game.player.Init();
        game.cameraAnchor.Init();

        game.tax = 1;
        game.mother.numCharacters = 5;

        game.mother.SpawnCharacters(game.board);

        game.stateMachine.Transition(game.stateShuffle);
    }
}
