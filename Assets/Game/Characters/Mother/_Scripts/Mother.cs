using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    public List<Character> characters;

    public List<GameObject> characterPrefabs;
    public int numCharacters = 5;

    public void Init(Board board)
    {
        numCharacters = 5;

        DespawnCharacters(board);
        SpawnCharacters(board);
    }

    public void SpawnCharacters(Board board)
    {
        for (int i = 0; i < numCharacters; i++)
        {
            int boardIdx = Random.Range(0, board.spaces.Count);
            SpawnCharacter(board, boardIdx);
        }
    }

    public void DespawnCharacters(Board board)
    {
        foreach (BoardSpace boardSpace in board.spaces)
        {
            boardSpace.ClearCharacters();
        }

        foreach (Character character in characters)
        {
            Destroy(character.gameObject);
        }

        characters.Clear();
    }

    public void SpawnCharacter(Board board, int boardIdx)
    {
        int randIdx = Random.Range(0, characterPrefabs.Count);
        GameObject characterPrefab = characterPrefabs[randIdx];
        GameObject characterObj = Instantiate(characterPrefab, transform);
        Character character = characterObj.GetComponent<Character>();

        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -1);
        character.board = board;
        character.boardIdx = boardIdx;

        character.Init();

       board.spaces[boardIdx].AddCharacter(character);

       characters.Add(character);
    }

    public void FreezeCharacters()
    {
        foreach (Character character in characters)
            character.Freeze();
    }

    public void UnfreezeCharacters()
    {
        foreach (Character character in characters)
            character.Unfreeze();
    }
}
