using UnityEngine;

public class Npc : Character
{
    public override void Play()
    {
        StartCoroutine(Move());
    }

    // private int moveIdx;
    // private float prevX;

    // public override void StartTurn()
    // {
    //     prevX = rb.transform.position.x;
    //     moveIdx = Random.Range(1, 3);
    // }

    // private void Start()
    // {
    //     money = 200f;
    // }

    // private void FixedUpdate()
    // {
    //     if (rb.transform.position.x >= 40)
    //     {
    //         rb.transform.position = new Vector2(0f, rb.transform.position.y);
    //     }

    //     if (moveIdx != 0)
    //     {
    //         if (rb.transform.position.x >= prevX + moveIdx * 10)
    //         {
    //             rb.linearVelocityX = 0f;
    //             rb.transform.position = new Vector2(prevX + moveIdx * 10, rb.transform.position.y);
    //             moveIdx = 0;
    //             OnMoveEnd?.Invoke(Mathf.FloorToInt(rb.transform.position.x / 10));
    //         } 
    //         else
    //         {
    //             rb.linearVelocityX = 4f;
    //         }
    //     }
    // }
}
