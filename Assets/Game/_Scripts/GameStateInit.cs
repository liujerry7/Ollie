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

        foreach (BoardSpace boardSpace in game.board.spaces)
            boardSpace.GetComponent<BoxCollider2D>().enabled = true;

        game.board.Init();
        game.player.Init();
        game.cameraAnchor.Init();
        game.mother.Init(game.board);

        game.tax = new GameTax();
        game.rerollCost = 1;

        game.stateMachine.Transition(game.stateShuffle);
    }
}
