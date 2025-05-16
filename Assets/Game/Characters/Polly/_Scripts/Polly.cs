using UnityEngine;

public class Polly : MonoBehaviour
{
    public float patrolSpeed = 4f;

    private float patrolOffset;

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    public void Init()
    {
        patrolOffset = Random.Range(0, 2 * Mathf.PI);
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = patrolSpeed * Mathf.Sin(Time.fixedTime + patrolOffset);
    }
}
