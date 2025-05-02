using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb => GetComponent<Rigidbody2D>();

    public StateMachine<CharacterState> stateMachine;
    public CharacterStatePatrol statePatrol;
    public CharacterStateFreeze stateFreeze;

    public bool frozen;

    public void Freeze()
    {
        stateMachine.Transition(stateFreeze);
    }

    public void Unfreeze()
    {
        stateMachine.Transition(statePatrol);
    }

    private void Awake()
    {
        stateMachine = new StateMachine<CharacterState>();
        statePatrol = new CharacterStatePatrol(this);
        stateFreeze = new CharacterStateFreeze(this);
    }

    private void Start()
    {
        stateMachine.Init(statePatrol);
    }

    private void Update()
    {
        stateMachine.currState.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.currState.FixedUpdate();
    }
}
