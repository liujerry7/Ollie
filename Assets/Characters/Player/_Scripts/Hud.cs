using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] Player player;

    private void Update()
    {
        GetComponentInChildren<TMP_Text>().text = "$" + player.money.ToString();
    }
}
