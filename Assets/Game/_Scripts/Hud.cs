using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private TMP_Text turnLabel;
    [SerializeField] private TMP_Text moneyLabel;
    [SerializeField] private Button moveButton;

    private Character character;

    public void SetCharacter(Character activeCharacter)
    {
        character = activeCharacter;
    }

    public void ShowActions()
    {
        moveButton.gameObject.SetActive(true);
        moveButton.onClick.AddListener(character.Move);
        moveButton.onClick.AddListener(HideActions);
    }

    public void HideActions()
    {
        moveButton.gameObject.SetActive(false);
        moveButton.onClick.RemoveListener(character.Move);
        moveButton.onClick.RemoveListener(HideActions);
    }

    private void Awake()
    {
        moveButton.gameObject.SetActive(false);
    }
}
