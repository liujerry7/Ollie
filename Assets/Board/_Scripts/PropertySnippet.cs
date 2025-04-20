using TMPro;
using UnityEngine;

public class PropertySnippet : MonoBehaviour
{
    public Property property;

    private void Start()
    {
        TMP_Text[] labels = GetComponentsInChildren<TMP_Text>();
        labels[0].text = property.title;
        labels[1].text = "Rent: $" + property.rent.ToString();
        labels[2].text = "Price: $" + property.price.ToString();
    }
}
