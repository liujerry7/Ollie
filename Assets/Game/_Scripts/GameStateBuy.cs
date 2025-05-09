using UnityEngine;

public class GameStateBuy : GameState
{
    public GameStateBuy(Game newGame) : base(newGame)
    {
    }

    private void EndBuy()
    {
        game.mother.FreezeCharacters();

        game.hud.endTurnButton.interactable = false;
        game.hud.buyButton.interactable = false;
        game.hud.sellButton.interactable = false;

        game.hud.endTurnButton.onClick.RemoveAllListeners();
        game.hud.buyButton.onClick.RemoveAllListeners();
        game.hud.sellButton.onClick.RemoveAllListeners();

        game.stateMachine.Transition(game.stateCollect);
    }


    private void BuySpaces()
    {
        float totalPrice = 0;

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.selected)
                totalPrice += boardSpace.property.price;
        }

        if (game.player.money < totalPrice) return;

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.selected)
                BuySpace(boardSpace);
        }
    }

    private void BuySpace(BoardSpace boardSpaceBuying)
    {
        boardSpaceBuying.Buy(game.player);
        boardSpaceBuying.Unselect();

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


    private void SellSpaces()
    {
        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.selected)
            {
                boardSpace.Sell(game.player);
                boardSpace.Unselect();
            }
        }
    }

    public override void Enter()
    {
        base.Enter();

        game.hud.endTurnButton.interactable = true;
        game.hud.buyButton.interactable = true;
        game.hud.sellButton.interactable = true;
        game.hud.endTurnButton.onClick.AddListener(EndBuy);
        game.hud.buyButton.onClick.AddListener(BuySpaces);
        game.hud.sellButton.onClick.AddListener(SellSpaces);
    }
}
