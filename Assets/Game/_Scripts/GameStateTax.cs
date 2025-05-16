using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateTax : GameState
{
    private float stateDuration = 2f;

    public GameStateTax(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        game.hud.taxTitleCard.SetActive(true);
        game.hud.taxTitleCard.GetComponentInChildren<TMP_Text>().text = "TAX: $" + game.tax.amount;
        stateTimer = stateDuration;
    }

    public override void Exit()
    {
        base.Exit();

        game.player.money -= game.tax.amount;
        game.hud.taxTitleCard.SetActive(false);
        game.tax.Inflate();

        if (game.player.money <= 0)
        {
            foreach (BoardSpace boardSpace in game.board.spaces)
                boardSpace.GetComponent<BoxCollider2D>().enabled = false;

            game.gameOver.gameObject.SetActive(true);
            game.gameOver.GetComponentInChildren<Button>().onClick.AddListener(() => game.stateMachine.Transition(game.stateInit));
            Time.timeScale = 0;
        }

    }

    public override void Update()
    {
        base.Update();

        if (stateTimer <= 0)
        {
            game.stateMachine.Transition(game.stateShuffle);
        }
    }
}
