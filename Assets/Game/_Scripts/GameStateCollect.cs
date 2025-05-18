using UnityEngine;

public class GameStateCollect : GameState
{
    private float stateDuration = 2f;

    public GameStateCollect(Game newGame) : base(newGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        game.rerollCost = 1;
        stateTimer = stateDuration;
        
        int numNewChars = 0;
        bool paid = false;

        foreach (Character character in game.mother.characters)
        {
            BoardSpace boardSpace = game.board.GetBoardSpaceAt(character.transform.position.x);

            if (boardSpace.owned)
            {
                paid = true;
                game.StartCoroutine(character.Pay(Mathf.RoundToInt(boardSpace.property.rent)));
                game.player.money += Mathf.RoundToInt(boardSpace.property.rent);

                if (boardSpace.property.title == "Factory")
                    boardSpace.property.rent *= 1.5f;

                if (boardSpace.property.title == "School")
                    boardSpace.property.rent++;

                if (boardSpace.property.title == "Hospital")
                    game.mother.numCharacters++;
            }
        }

        for (int i = 0; i < numNewChars; i++)
            game.mother.SpawnCharacter(game.board);

        if (paid)
            Speaker.instance.PlaySfxClip(game.paySfx, game.transform, 0.2f);
    }

    public override void Update()
    {
        base.Update();
        
        if (stateTimer <= 0)
            game.stateMachine.Transition(game.stateTax);
    }
}
