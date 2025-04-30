using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public string title;
    public float money = 100;
    public int boardIdx = 0;

    public Board board;
    public UnityAction OnMoveEnd;
    public Rigidbody2D rb => GetComponent<Rigidbody2D>();

    public virtual void Play()
    {
    }

    public virtual IEnumerator Move()
    {
        int moveSpaces = Random.Range(1, 4);

        for (int i = 0; i < moveSpaces; i++)
        {
            boardIdx = (boardIdx + 1) % board.spaces.Count;

            float targetX = board.spaces[boardIdx].transform.position.x;

            Vector2 targetPos = new Vector2(targetX, rb.position.y);

            rb.MovePosition(targetPos);

            yield return new WaitForSeconds(1f);
        }

        Rest();
        OnMoveEnd?.Invoke();
    }

    private void Rest()
    {
        if (board.spaces[boardIdx].owner == null)
        {
            board.spaces[boardIdx].Buy(this);
        }
        else
        {
            board.spaces[boardIdx].ChargeRent(this);
        }
    }
}
