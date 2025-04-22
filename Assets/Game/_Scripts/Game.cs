using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private List<Character> characters;

    [Header("Board")]
    [SerializeField] private Board board;

    [Header("Camera")]
    [SerializeField] private CinemachineCamera cameraAnchor;

    [Header("Hud")]
    [SerializeField] private Hud hud;

    [Header("Gameplay")]
    private int turnIdx;

    private void StartTurn()
    {
        hud.SetCharacter(characters[turnIdx]);
        hud.ShowActions();

        characters[turnIdx].OnTurnEnd += StartTurn;
    }

    private void Start()
    {
        StartTurn();
    }
}
