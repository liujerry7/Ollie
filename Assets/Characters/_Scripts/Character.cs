using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("Details")]
    public string title;

    [Header("Money")]
    public float money = 200;

    [Header("Movement")]
    public UnityAction OnMoveEnd;

    [Header("Body")]
    [HideInInspector] public Rigidbody2D rb => GetComponent<Rigidbody2D>();

    [Header("States")]
    [HideInInspector] public StateMachine<CharacterState> stateMachine;
    [HideInInspector] public CharacterStateIdle stateIdle;
    [HideInInspector] public CharacterStateMove stateMove;

    public virtual void MoveTo(float posX)
    {
        stateMove.SetDestination(posX);
        stateMachine.Transition(stateMove);
    }

    private void Awake()
    {
        stateMachine = new StateMachine<CharacterState>();
        stateIdle = new CharacterStateIdle(this);
        stateMove = new CharacterStateMove(this);

        stateMachine.Init(stateIdle);
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
