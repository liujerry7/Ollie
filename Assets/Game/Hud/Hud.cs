using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Button endTurnButton;
    public Button buyButton;
    public Button sellButton;
    public TMP_Text moneyLabel;

    public GameObject taxTitleCard;

    public Board board;
    public Player player;

    private void Update()
    {
        moneyLabel.text = "$" + Mathf.RoundToInt(player.money);
    }
}
