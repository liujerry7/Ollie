using UnityEngine;

public class GameStateBuy : GameState
{
    public GameStateBuy(Game newGame) : base(newGame)
    {
    }

    private void EndBuy()
    {
        foreach (Character character in game.characters)
            character.Freeze();

        foreach (BoardSpace boardSpace in game.board.spaces)
            boardSpace.OnBuy.RemoveAllListeners();

        game.hud.endTurnButton.interactable = false;
        game.hud.endTurnButton.onClick.RemoveAllListeners();
    }

    public override void Enter()
    {
        base.Enter();

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            boardSpace.OnBuy.AddListener(boardSpace.Buy);
            boardSpace.OnHoverEnter.AddListener(() => game.hud.ShowTooltip(boardSpace));
            boardSpace.OnHoverExit.AddListener(game.hud.HideTooltip);
        }

        game.hud.endTurnButton.interactable = true;
        game.hud.endTurnButton.onClick.AddListener(EndBuy);
    }

    public override void Exit()
    {
        base.Exit();

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            boardSpace.OnHoverEnter.RemoveAllListeners();
            boardSpace.OnHoverExit.RemoveAllListeners();
        }
    }

    public override void Update()
    {
        base.Update();

        bool allCharactersFrozen = true;

        foreach (Character character in game.characters)
        {
            if (!character.frozen)
            {
                allCharactersFrozen = false;
                break;
            }
        }

        if (allCharactersFrozen)
            game.stateMachine.Transition(game.stateCollect);
    }

}
