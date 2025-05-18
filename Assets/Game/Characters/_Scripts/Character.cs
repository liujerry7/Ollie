using System.Collections;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject sprite;
    public Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public TMP_Text payPopup => GetComponentInChildren<TMP_Text>(true);

    private float patrolSpeed;
    private float patrolOffset; 
    private bool frozen;

    public void Init()
    {
        patrolOffset = Random.Range(0, 2 * Mathf.PI);
        patrolSpeed = Random.Range(4f, 16f);
    }

    public IEnumerator Pay(float amount)
    {
        payPopup.text = "$" + Mathf.RoundToInt(amount);
        payPopup.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        payPopup.gameObject.SetActive(false);
    }

    public void Freeze()
    {
        frozen = true;
        rb.linearVelocityX = 0f;
    }

    public void Unfreeze()
    {
        frozen = false;
    }

    private void FixedUpdate()
    {
        if (frozen) return;

        rb.linearVelocityX = patrolSpeed * Mathf.Sin(Time.fixedTime + patrolOffset);

        if (rb.linearVelocityX > 0)
        {
            sprite.transform.localScale = new Vector3(1, 1, 1);
        }

        if (rb.linearVelocityX < 0)
        {
            sprite.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
