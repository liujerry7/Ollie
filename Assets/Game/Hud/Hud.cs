using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Button endTurnButton;
    public TMP_Text moneyLabel;

    public GameObject tooltipPrefab;
    public GameObject tooltipObj;

    public GameObject popupPrefab;

    public GameObject taxTitleCard;

    public Board board;

    public void ShowTooltip(BoardSpace boardSpace)
    {
        Vector2 offset = new Vector2(0, 350);

        tooltipObj = Instantiate(tooltipPrefab, transform);
        tooltipObj.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, boardSpace.transform.position) + offset;
        tooltipObj.GetComponentsInChildren<TMP_Text>()[0].text = boardSpace.property.title;
        tooltipObj.GetComponentsInChildren<TMP_Text>()[1].text = boardSpace.property.description;
        tooltipObj.GetComponentsInChildren<TMP_Text>()[2].text = "Rent: $" + boardSpace.property.rent;
        tooltipObj.GetComponentsInChildren<TMP_Text>()[3].text = "Price: $" + boardSpace.property.price;
    }

    public void HideTooltip()
    {
        Destroy(tooltipObj);
        tooltipObj = null;
    }

    public IEnumerator ShowPopup(Character character, float amount)
    {
        Vector2 offset = new Vector2(0, 50);
        GameObject popupObj = Instantiate(popupPrefab, transform);

        popupObj.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, character.transform.position) + offset;
        popupObj.GetComponent<TMP_Text>().text = "$" + amount;

        yield return new WaitForSeconds(2f);

        Destroy(popupObj);
    }

    private void Update()
    {
        moneyLabel.text = "$" + Player.instance.money;
    }
}
