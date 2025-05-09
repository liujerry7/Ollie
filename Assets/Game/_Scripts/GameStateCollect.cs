public class GameStateCollect : GameState
{
    private float stateDuration = 2f;

    public GameStateCollect(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = stateDuration;

        foreach (Character character in game.mother.characters)
        {
            BoardSpace boardSpace = game.board.GetBoardSpaceAt(character.transform.position.x);

            if (boardSpace != null && boardSpace.owned)
            {
                game.StartCoroutine(game.hud.ShowPopup(character, boardSpace.property.rent));
                game.player.money += boardSpace.property.rent;

                if (boardSpace.property.title == "Factory")
                    boardSpace.property.rent *= 2f;

                if (boardSpace.property.title == "School")
                    boardSpace.property.rent++;
            }
        }

    }

    public override void Update()
    {
        base.Update();
        
        if (stateTimer <= 0)
            game.stateMachine.Transition(game.stateTax);
    }
}
