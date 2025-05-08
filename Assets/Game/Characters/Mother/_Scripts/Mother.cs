using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    public List<Character> characters;

    public GameObject characterPrefab;
    public int numCharacters = 5;

    public void SpawnCharacters()
    {
        for (int i = 0; i < numCharacters; i++)
        {
            GameObject characterObj = Instantiate(characterPrefab, transform);
            characterObj.transform.position = new Vector2(Random.Range(-40f, 40f), 0);

            Character character = characterObj.GetComponent<Character>();
            character.stateMachine.Init(character.statePatrol);
            characters.Add(character);
        }
    }

    public void DespawnCharacters()
    {
        foreach (Character character in characters)
        {
            Destroy(character.gameObject);
        }

        characters = new List<Character>();
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

    public bool AreAllCharactersFrozen()
    {
        bool allCharactersFrozen = true;

        foreach (Character character in characters)
        {
            if (!character.frozen)
            {
                allCharactersFrozen = false;
                break;
            }
        }

        return allCharactersFrozen;
    }
}
