using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Hud hud;
    public Board board;
    public Player player;
    public List<Character> characters;

    public StateMachine<GameState> stateMachine;
    public GameStateInit stateInit;
    public GameStateShuffle stateShuffle;
    public GameStateBuy stateBuy;
    public GameStateCollect stateCollect;
    public GameStateTax stateTax;

    private void Awake()
    {
        stateMachine = new StateMachine<GameState>();
        stateInit = new GameStateInit(this);
        stateShuffle = new GameStateShuffle(this);
        stateBuy = new GameStateBuy(this);
        stateCollect = new GameStateCollect(this);
        stateTax = new GameStateTax(this);
    }

    private void Start()
    {
        stateMachine.Init(stateInit);
    }

    private void Update()
    {
        stateMachine.currState.Update();
    }
}
