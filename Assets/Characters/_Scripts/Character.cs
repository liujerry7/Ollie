using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("Actions")]
    public UnityAction OnTurnEnd;
    public UnityAction<int> OnMoveEnd;

    [Header("Money")]
    public float money = 200;

    [Header("Body")]
    [HideInInspector] public Rigidbody2D rb => GetComponent<Rigidbody2D>();

    [Header("States")]
    [HideInInspector] public StateMachine<CharacterState> stateMachine;

    public virtual void StartTurn()
    {
    }

    private void FixedUpdate()
    {
        
    }
}
