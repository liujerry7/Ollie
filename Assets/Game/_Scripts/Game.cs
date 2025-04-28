using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Board board;
    [SerializeField] private CinemachineCamera cameraAnchor;
    [SerializeField] private Hud hud;
    [SerializeField] private List<Character> characters;
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private int numNpcs;

    private int currTurn = -1;

    public void MoveCharacter()
    {
        int dice1 = Random.Range(1, 3);
        int dice2 = Random.Range(0, 3);
        int moveSpaces = dice1 + dice2;

        float moveDist = board.CalcSpacesDist(moveSpaces);
        float destX = characters[currTurn].transform.position.x + moveDist;
        float rightBound = board.GetRightBound();
        float overBounds = destX - rightBound;

        int overBoundsSpaces = board.CalcDistSpaces(overBounds);

        for (int i = 0; i <= overBoundsSpaces; i++)
        {
            board.RotatePropertiesRight();

            PropertySpace leftPropSpace = board.GetLeftPropertySpace();
            PropertySpace rightPropSpace = board.GetRightPropertySpace();

            foreach (Character character in characters)
            {
                if (character.transform.position.x < leftPropSpace.transform.position.x)
                {
                    character.transform.position = new Vector2(rightPropSpace.transform.position.x, character.transform.position.y);
                }
            }
        }

        characters[currTurn].MoveTo(destX);
        hud.HideActions();
    }

    public void EndTurn()
    {
        StartCoroutine(NextTurn());
    }

    public void BuyProperty()
    {
        Property currProperty = board.GetPropertyAt(characters[currTurn].transform.position.x);

        if (currProperty.owner == null)
        {
            currProperty.owner = characters[currTurn];
            characters[currTurn].money -= currProperty.price;
        }
    }

    private IEnumerator NextTurn()
    {
        currTurn = currTurn == characters.Count - 1 ? 0 : currTurn + 1;
        cameraAnchor.Follow = characters[currTurn].transform;

        hud.SetCharacter(characters[currTurn]);

        if (characters[currTurn] is Player)
        {
            hud.ShowActions();
        }
        else
        {
            hud.HideActions();
            yield return new WaitForSeconds(2);
            MoveCharacter();
        }
    }

    private void InitNpcs()
    {
        for (int i = 0; i < numNpcs; i++)
        {
            GameObject npcObject = Instantiate(npcPrefab, transform);
            Character npcCharacter = npcObject.GetComponent<Character>();

            characters.Add(npcCharacter);
        }
    }

    private void SetupCharacters()
    {
        foreach (Character character in characters)
        {
            character.transform.position = new Vector2(board.CalcSpacesDist(board.GetRandomSpace()), character.transform.position.y);
            character.OnMoveEnd += hud.ShowActions;
        }
    }

    private void Start()
    {
        InitNpcs();
        SetupCharacters();
        StartCoroutine(NextTurn());
    }

    private void Update()
    {
        Property currProperty = board.GetPropertyAt(characters[currTurn].transform.position.x);
        hud.SetProperty(currProperty);
    }
}
