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
            SpawnCharacter(board);
    }

    public void DespawnCharacters(Board board)
    {
        foreach (Character character in characters)
            Destroy(character.gameObject);

        characters.Clear();
    }

    public void SpawnCharacter(Board board)
    {
        int randIdx = Random.Range(0, characterPrefabs.Count);
        GameObject characterPrefab = characterPrefabs[randIdx];
        GameObject characterObj = Instantiate(characterPrefab, transform);
        Character character = characterObj.GetComponent<Character>();

        float randX = Random.Range(board.GetLeftBound(), board.GetRightBound());

        character.transform.position = new Vector3(randX, character.transform.position.y, character.transform.position.z);
        character.Init();

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
