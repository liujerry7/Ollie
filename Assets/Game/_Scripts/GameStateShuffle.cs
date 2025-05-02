using UnityEngine;

public class GameStateShuffle : GameState
{
    private float stateDuration = 3f;
    private float randomizeTimer;
    private float randomizePeriod = 0.25f;

    public GameStateShuffle(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = stateDuration;
        randomizeTimer = randomizePeriod;

        foreach (Character character in game.characters)
            character.Unfreeze();
    }

    public override void Update()
    {
        base.Update();

        randomizeTimer -= Time.deltaTime;

        if (randomizeTimer <= 0)
        {
            game.board.Randomize();
            randomizeTimer = randomizePeriod;
        } 

        if (stateTimer <= 0)
        {
            game.stateMachine.Transition(game.stateBuy);
        }
    }
}
