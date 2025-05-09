using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Button endTurnButton;
    public Button buyButton;
    public Button sellButton;
    public TMP_Text moneyLabel;

    public GameObject popupPrefab;
    public GameObject taxTitleCard;

    public Board board;
    public Player player;

    public IEnumerator ShowPopup(Character character, float amount)
    {
        Vector2 offset = new Vector2(0, 150);
        GameObject popupObj = Instantiate(popupPrefab, transform);

        popupObj.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, character.transform.position) + offset;
        popupObj.GetComponent<TMP_Text>().text = "$" + amount;

        yield return new WaitForSeconds(2f);

        Destroy(popupObj);
    }

    private void Update()
    {
        moneyLabel.text = "$" + player.money;
    }
}
