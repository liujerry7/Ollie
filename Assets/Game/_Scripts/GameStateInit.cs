using UnityEngine;
using UnityEngine.UI;

public class GameStateInit : GameState
{
    private float stateDuration = 0.5f;

    public GameStateInit(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Time.timeScale = 1;

        game.gameOver.gameObject.SetActive(false);
        game.gameOver.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        game.tax = 1;
        game.player.money = 10;

        stateTimer = stateDuration;

        foreach(Character character in game.characters)
        {
            character.stateMachine.Init(character.statePatrol);
        }

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            boardSpace.owned = false;
        }
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer <= 0)
            game.stateMachine.Transition(game.stateShuffle);
    }
}
