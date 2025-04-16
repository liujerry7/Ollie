using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private float moveDist;
    private float prevX;

    public void Move()
    {
        prevX = rb.transform.position.x;
        moveDist = Random.Range(1, 1);
    }

    private void FixedUpdate()
    {
        if (moveDist != 0f)
        {
            if (rb.transform.position.x >= prevX + moveDist * 10)
            {
                rb.linearVelocityX = 0f;
                moveDist = 0f;
            } 
            else
            {
                rb.linearVelocityX = 4f;
            }
        }
    }
}
