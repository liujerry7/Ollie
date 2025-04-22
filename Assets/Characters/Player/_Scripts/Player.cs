using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    // private int moveIdx;
    // private float prevX;

    // private bool turnStarted = false;
    // private bool movePressed = false;

    // public override void StartTurn()
    // {
    //     turnStarted = true;
    //     movePressed = false;
    // }

    // public void Move(InputAction.CallbackContext context)
    // {
    //     if (context.performed && turnStarted && !movePressed)
    //     {
    //         moveIdx = Random.Range(1, 3);
    //         prevX = rb.transform.position.x;
    //         movePressed = true;
    //     }
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

    //     if (moveIdx != 0f)
    //     {
    //         if (rb.transform.position.x >= prevX + moveIdx * 10)
    //         {
    //             rb.linearVelocityX = 0f;
    //             rb.transform.position = new Vector2(prevX + moveIdx * 10, rb.transform.position.y);
    //             moveIdx = 0;
    //             turnStarted = false;
    //             OnMoveEnd?.Invoke(Mathf.FloorToInt(rb.transform.position.x / 10));
    //         } 
    //         else
    //         {
    //             rb.linearVelocityX = 4f;
    //         }
    //     }
    // }
}
