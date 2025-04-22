using UnityEngine;

public class CharacterStateMove : CharacterState
{
    private float destX;
    private float destThreshold = 0.1f;
    private float moveSpeed = 4f;

    public CharacterStateMove(Character newCharacter) : base(newCharacter)
    {
    }

    public void SetDestination(float newDestX)
    {
        destX = newDestX;
    }

    public override void Enter()
    {
        int dir = destX > character.transform.position.x ? 1 : -1;
        character.rb.linearVelocityX = dir * moveSpeed;
    }

    public override void Exit()
    {
        character.OnTurnEnd?.Invoke();
    }

    public override void FixedUpdate()
    {
        if (Mathf.Abs(character.transform.position.x - destX) <= destThreshold)
        {
            character.rb.linearVelocityX = 0f;
            character.transform.position = new Vector2(destX, character.transform.position.y);
            character.stateMachine.Transition(character.stateIdle);
        }
    }
}
