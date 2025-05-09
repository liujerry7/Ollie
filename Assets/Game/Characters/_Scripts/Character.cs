using UnityEngine;

public class Character : MonoBehaviour
{
    public Board board;

    public int boardIdx = 0;
    public int strideLen = 5;
    public float strideDur = 1;

    private int strideCount = 0;
    private int strideStep = 1;
    private float strideTimer = 1;
    private bool frozen = false;

    public void Freeze()
    {
        frozen = true;
    }

    public void Unfreeze()
    {
        frozen = false;
    }

    public void Init()
    {
        strideStep = Random.Range(0f, 1f) > 0.5 ? 1 : -1;
        strideCount = Random.Range(0, strideLen);
    }

    private void FixedUpdate()
    {
        if (frozen) return;

        strideTimer -= Time.fixedDeltaTime;

        if (strideTimer <= 0)
        {
            board.spaces[boardIdx].RemoveCharacter(this);

            if (boardIdx + strideStep < 0)
            {
                strideStep = 1;
                strideCount = 5 - strideCount;
            }

            if (boardIdx + strideStep >= board.spaces.Count)
            {
                strideStep = -1;
                strideCount = 5 - strideCount;
            }

            boardIdx += strideStep;

            board.spaces[boardIdx].AddCharacter(this);

            strideCount++;

            if (strideCount >= strideLen)
            {
                strideStep = strideStep == 1 ? -1 : 1;
                strideCount = 0;
            }

            strideTimer = strideDur;
        }
    }

    // public Rigidbody2D rb => GetComponent<Rigidbody2D>();

    // public StateMachine<CharacterState> stateMachine;
    // public CharacterStatePatrol statePatrol;
    // public CharacterStateFreeze stateFreeze;

    // public bool frozen;

    // public void Freeze()
    // {
    //     stateMachine.Transition(stateFreeze);
    // }

    // public void Unfreeze()
    // {
    //     stateMachine.Transition(statePatrol);
    // }

    // private void Awake()
    // {
    //     stateMachine = new StateMachine<CharacterState>();
    //     statePatrol = new CharacterStatePatrol(this);
    //     stateFreeze = new CharacterStateFreeze(this);
    // }

    // private void Update()
    // {
    //     stateMachine.currState.Update();
    // }

    // private void FixedUpdate()
    // {
    //     stateMachine.currState.FixedUpdate();
    // }
}
