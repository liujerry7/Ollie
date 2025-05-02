using UnityEngine;

public class GameStateInit : GameState
{
    private float stateDuration = 2f;

    public GameStateInit(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = stateDuration;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer <= 0)
            game.stateMachine.Transition(game.stateShuffle);
    }
}
