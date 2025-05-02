using UnityEngine;

public class CharacterStateFreeze : CharacterState
{
    public CharacterStateFreeze(Character newCharacter) : base(newCharacter)
    {
    }

    public override void FixedUpdate()
    {
        character.rb.linearVelocityX = Mathf.Lerp(character.rb.linearVelocityX, 0f, Time.fixedDeltaTime);

        if (Mathf.Abs(character.rb.linearVelocityX) < 0.01f)
            character.frozen = true;
    }
}
