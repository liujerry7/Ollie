using UnityEngine;

public class GameStateTax : GameState
{
    public float tax = 1f;
    public float stateDuration = 2f;

    public GameStateTax(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.instance.money -= tax;
        stateTimer = stateDuration;

        if (Player.instance.money <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public override void Exit()
    {
        base.Exit();

        tax *= 2;
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
