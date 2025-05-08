using UnityEngine;

public class GameStateBuy : GameState
{
    public GameStateBuy(Game newGame) : base(newGame)
    {
    }

    private void StartBuy(BoardSpace boardSpaceBuying)
    {
        if (Player.instance.money < boardSpaceBuying.property.price || boardSpaceBuying.owned) return;

        boardSpaceBuying.Buy();

        int numApartments = 0;

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.owned && boardSpace.property.title == "Apartment")
                numApartments++;
        }

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.owned && boardSpace.property.title == "City Hall")
                boardSpace.property.rent++;


            if (boardSpace.owned && boardSpace.property.title == "Apartment")
                boardSpace.property.rent = Mathf.Pow(2, numApartments);
        }

    }

    private void EndBuy()
    {
        game.mother.FreezeCharacters();

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
            boardSpace.OnBuy.AddListener(() => StartBuy(boardSpace));
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

        if (game.mother.AreAllCharactersFrozen())
            game.stateMachine.Transition(game.stateCollect);
    }

}
