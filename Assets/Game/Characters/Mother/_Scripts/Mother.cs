using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    public List<Character> characters;

    public GameObject characterPrefab;
    public int numCharacters = 1;

    public void SpawnCharacters(Board board)
    {
        for (int i = 0; i < numCharacters; i++)
        {
            GameObject characterObj = Instantiate(characterPrefab, transform);
            Character character = characterObj.GetComponent<Character>();

            int boardSpaceIdx = Random.Range(0, board.spaces.Count);

            character.board = board;
            character.boardIdx = boardSpaceIdx;
            character.Init();

            board.spaces[boardSpaceIdx].AddCharacter(character);

            characters.Add(character);
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
