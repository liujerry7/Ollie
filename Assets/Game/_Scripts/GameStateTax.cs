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
        game.hud.taxTitleCard.GetComponentInChildren<TMP_Text>().text = "TAX: $" + game.tax;
        stateTimer = stateDuration;
    }

    public override void Exit()
    {
        base.Exit();

        game.player.money -= game.tax;
        game.hud.taxTitleCard.SetActive(false);
        game.tax *= 2;

        if (game.player.money <= 0)
        {
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
