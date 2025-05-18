using System.Collections.Generic;
using UnityEngine;

public class GameStateBuy : GameState
{
    public GameStateBuy(Game newGame) : base(newGame)
    {
    }

    private void Reroll()
    {
        if (game.player.money <= game.rerollCost) return;

        game.stateMachine.Transition(game.stateShuffle);
        game.player.money -= game.rerollCost;
        game.rerollCost *= 2;

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.owned && boardSpace.property.title == "Casino")
                boardSpace.property.rent *= 1.5f;
        }
    }

    private void EndBuy()
    {
        game.mother.FreezeCharacters();
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

        if (boardSpaceBuying.property.title == "Junkyard")
        {
            game.mother.numCharacters++;
            game.mother.SpawnCharacter(game.board);
        }

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.owned && boardSpace.property.title == "City Hall")
                boardSpace.property.rent *= 1.5f;
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
                boardSpace.Randomize(game.board.propertyList);

                foreach (BoardSpace remBoardSpace in game.board.spaces)
                {
                    if (remBoardSpace.owned && remBoardSpace.property.title == "University")
                        remBoardSpace.property.rent += 4;
                }
            }
        }
    }

    public override void Enter()
    {
        base.Enter();

        game.hud.endTurnButton.interactable = true;
        game.hud.rerollButton.interactable = true;
        game.hud.buyButton.interactable = true;
        game.hud.sellButton.interactable = true;

        game.hud.endTurnButton.onClick.AddListener(EndBuy);
        game.hud.rerollButton.onClick.AddListener(Reroll);
        game.hud.buyButton.onClick.AddListener(BuySpaces);
        game.hud.sellButton.onClick.AddListener(SellSpaces);
    }

    public override void Exit()
    {
        base.Exit();

        game.hud.endTurnButton.interactable = false;
        game.hud.rerollButton.interactable = false;
        game.hud.buyButton.interactable = false;
        game.hud.sellButton.interactable = false;

        game.hud.endTurnButton.onClick.RemoveAllListeners();
        game.hud.rerollButton.onClick.RemoveAllListeners();
        game.hud.buyButton.onClick.RemoveAllListeners();
        game.hud.sellButton.onClick.RemoveAllListeners();
    }

    public override void Update()
    {
        base.Update();

        Dictionary<BoardSpace, int> numCharsPerSpace = new Dictionary<BoardSpace, int>();

        foreach (Character character in game.mother.characters)
        {
            BoardSpace boardSpace = game.board.GetBoardSpaceAt(character.transform.position.x);

            if (numCharsPerSpace.ContainsKey(boardSpace))
                numCharsPerSpace[boardSpace]++;
            else
                numCharsPerSpace[boardSpace] = 1;
        }

        Dictionary<string, bool> propertyTypeOwnership = new Dictionary<string, bool>();

        int numHomes = 0;
        int numDiffTypeOwned = 0;

        foreach (BoardSpace boardSpace in game.board.spaces)
        {
            if (boardSpace.owned)
            {
                if (!propertyTypeOwnership.ContainsKey(boardSpace.property.type))
                {
                    propertyTypeOwnership[boardSpace.property.type] = true;
                    numDiffTypeOwned++;
                }
            }

            if (boardSpace.property.title == "House" && numCharsPerSpace.ContainsKey(boardSpace))
                boardSpace.property.rent = 2 * Mathf.Pow(2, numCharsPerSpace[boardSpace]);
            else if (boardSpace.property.title == "House")
                boardSpace.property.rent = 2;

            if (boardSpace.property.title == "Condo")
                boardSpace.property.rent = 2 * game.mother.characters.Count;

            if (boardSpace.owned && boardSpace.property.type == "Home")
                numHomes++;
        }

        for (int i = 0; i < game.board.spaces.Count; i++)
        {
            if (game.board.spaces[i].property.title == "Museum")
            {
                if (i == 0)
                    game.board.spaces[i].property.rent = 0;
                else
                    game.board.spaces[i].property.rent = game.board.spaces[i - 1].property.rent;
            }


            if (game.board.spaces[i].property.title == "Concert")
                game.board.spaces[i].property.rent = 2 * Mathf.Pow(3, numDiffTypeOwned);

            if (game.board.spaces[i].property.title == "Apartment")
                game.board.spaces[i].property.rent = 2 * Mathf.Pow(2, numHomes);

            if (game.board.spaces[i].property.title == "Lamp Post")
            {
                int numAdjOwned = 0;
                int j = i - 1;
                int k = i + 1;

                while (j >= 0 || k < game.board.spaces.Count)
                {
                    if (j >= 0 && game.board.spaces[j].owned)
                    {
                        numAdjOwned++;
                        j--;
                    }
                    else
                    {
                        j = -1;
                    }

                    if (k < game.board.spaces.Count && game.board.spaces[k].owned)
                    {
                        numAdjOwned++;
                        k++;
                    }
                    else
                    {
                        k = game.board.spaces.Count;
                    }
                }

                game.board.spaces[i].property.rent = Mathf.Pow(2, numAdjOwned);
            }
        }
    }
}
