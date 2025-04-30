using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Hud hud;
    [SerializeField] private Board board;
    [SerializeField] private CinemachineCamera cameraAnchor;
    [SerializeField] private List<Character> characters;

    private int turnIdx = 1;

    private void StartTurn()
    {
        cameraAnchor.Follow = characters[turnIdx].transform;
        characters[turnIdx].Play();
    }

    private void EndTurn()
    {
        turnIdx = (turnIdx + 1) % characters.Count;
        StartTurn();
    }

    private void Start()
    {
        foreach (Character character in characters)
            character.OnMoveEnd += EndTurn;

        StartTurn();
    }

    // public void MoveCharacter()
    // {
    //     int dice1 = Random.Range(1, 3);
    //     int dice2 = Random.Range(0, 3);
    //     int moveSpaces = dice1 + dice2;

    //     float moveDist = board.CalcSpacesDist(moveSpaces);
    //     float destX = characters[turnIdx].transform.position.x + moveDist;
    //     float rightBound = board.GetRightBound();
    //     float overBounds = destX - rightBound;

    //     int overBoundsSpaces = board.CalcDistSpaces(overBounds);

    //     for (int i = 0; i <= overBoundsSpaces; i++)
    //     {
    //         board.RotatePropertiesRight();

    //         PropertySpace leftPropSpace = board.GetLeftPropertySpace();
    //         PropertySpace rightPropSpace = board.GetRightPropertySpace();

    //         foreach (Character character in characters)
    //         {
    //             if (character.transform.position.x < leftPropSpace.transform.position.x)
    //             {
    //                 character.transform.position = new Vector2(rightPropSpace.transform.position.x, character.transform.position.y);
    //             }
    //         }
    //     }

    //     characters[turnIdx].MoveTo(destX);
    //     hud.HideActions();
    // }

    // public void EndTurn()
    // {
    //     StartCoroutine(NextTurn());
    // }

    // public void BuyProperty()
    // {
    //     Property currProperty = board.GetPropertyAt(characters[turnIdx].transform.position.x);

    //     if (currProperty.owner == null)
    //     {
    //         currProperty.owner = characters[turnIdx];
    //         characters[turnIdx].money -= currProperty.price;
    //     }
    // }

    // private IEnumerator NextTurn()
    // {
    //     turnIdx = turnIdx == characters.Count - 1 ? 0 : turnIdx + 1;
    //     cameraAnchor.Follow = characters[turnIdx].transform;

    //     hud.SetCharacter(characters[turnIdx]);

    //     if (characters[turnIdx] is Player)
    //     {
    //         hud.ShowActions();
    //     }
    //     else
    //     {
    //         hud.HideActions();
    //         yield return new WaitForSeconds(2);
    //         MoveCharacter();
    //     }
    // }

    // private void SetupCharacters()
    // {
    //     foreach (Character character in characters)
    //     {
    //         character.transform.position = new Vector2(board.CalcSpacesDist(board.GetRandomSpace()), character.transform.position.y);
    //         character.OnMoveEnd += hud.ShowActions;
    //     }
    // }

    // private void Start()
    // {
    //     SetupCharacters();
    //     StartCoroutine(NextTurn());
    // }

    // private void Update()
    // {
    //     Property currProperty = board.GetPropertyAt(characters[turnIdx].transform.position.x);
    //     hud.SetProperty(currProperty);
    // }
}
