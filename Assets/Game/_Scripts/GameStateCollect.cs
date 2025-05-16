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

        stateTimer = stateDuration;
        
        int numNewChars = 0;

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.owned)
            {

                foreach (Character character in boardSpace.characters)
                {
                    game.StartCoroutine(character.Pay(boardSpace.property.rent));
                    game.player.money += boardSpace.property.rent;

                    if (boardSpace.property.title == "Factory")
                        boardSpace.property.rent *= 1.5f;

                    if (boardSpace.property.title == "School")
                        boardSpace.property.rent++;

                    if (boardSpace.property.title == "Hospital")
                        numNewChars++;
                }
            }
        }

        for (int i = 0; i < numNewChars; i++)
        {
            int boardIdx = Random.Range(0, game.board.spaces.Count);
            game.mother.SpawnCharacter(game.board, boardIdx);
        }

        Speaker.instance.PlaySfxClip(game.paySfx, game.transform, 0.2f);
    }

    public override void Update()
    {
        base.Update();
        
        if (stateTimer <= 0)
            game.stateMachine.Transition(game.stateTax);
    }
}
