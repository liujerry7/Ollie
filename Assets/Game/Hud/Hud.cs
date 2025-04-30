using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Button moveButton;

    private void Start()
    {
        moveButton.gameObject.SetActive(false);
    }
}
