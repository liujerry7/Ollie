using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Button endTurnButton;
    public TMP_Text moneyLabel;

    private void Update()
    {
        moneyLabel.text = "$" + Player.instance.money;
    }
}
