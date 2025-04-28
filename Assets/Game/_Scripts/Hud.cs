using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private TMP_Text propertyLabel;
    [SerializeField] private TMP_Text moneyLabel;
    [SerializeField] private TMP_Text turnLabel;
    [SerializeField] private GameObject hudActions;

    public void SetProperty(Property property)
    {
        propertyLabel.text = property.title;
    }

    public void SetCharacter(Character character)
    {
        moneyLabel.text = "$" + character.money;
        turnLabel.text = character.title + "'s turn";
    }

    public void ShowActions()
    {
        hudActions.SetActive(true);
    }

    public void HideActions()
    {
        hudActions.SetActive(false);
    }
}
