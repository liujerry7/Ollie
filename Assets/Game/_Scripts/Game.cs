using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cameraAnchor;
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private int numNpcs;
    [SerializeField] private List<Character> characters;

    private Board board => GetComponentInChildren<Board>();

    private int turnIdx = 0;

    private void NextTurn()
    {
        turnIdx = turnIdx == characters.Count - 1 ? 0 : turnIdx + 1;
        characters[turnIdx].StartTurn();
        cameraAnchor.Follow = characters[turnIdx].transform;
    }

    private void Start()
    {
        for (int i = 0; i < numNpcs; i++)
        {
            GameObject npc = Instantiate(npcPrefab, transform);
            characters.Add(npc.GetComponent<Character>());
        }

        foreach (Character character in characters)
        {
            character.OnMoveEnd += (int propertyIdx) => board.PromptBuy(propertyIdx, character);
            character.OnTurnEnd += NextTurn;
        }

        board.PropertySkipped += NextTurn;

        characters[turnIdx].StartTurn();
        cameraAnchor.Follow = characters[turnIdx].transform;
    }
}
