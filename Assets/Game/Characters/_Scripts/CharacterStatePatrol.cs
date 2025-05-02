using UnityEngine;

public class CharacterStatePatrol : CharacterState
{
    private float maxSpeed = 10f;
    private float patrolOffset;

    public CharacterStatePatrol(Character newCharacter) : base(newCharacter)
    {
    }

    public override void Enter()
    {
        patrolOffset = Random.Range(0, 2 * Mathf.PI);
        character.frozen = false;
    }

    public override void FixedUpdate()
    {
        character.rb.linearVelocityX = maxSpeed * Mathf.Sin(stateTimer + patrolOffset);
    }
}
