using System.Collections;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Board board;
    public GameObject sprite;
    public TMP_Text payPopup => GetComponentInChildren<TMP_Text>(true);

    public int boardIdx = 0;
    public int strideLen = 5;
    public float strideDur = 1;

    public string type;

    private int strideCount = 0;
    private int strideStep = 1;
    private float strideTimer = 1;
    private bool frozen = false;

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

            if (strideStep > 0)
            {
                sprite.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                sprite.transform.localScale = new Vector3(-1, 1, 1);
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
}
