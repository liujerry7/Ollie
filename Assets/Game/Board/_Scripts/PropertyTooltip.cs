using TMPro;
using UnityEngine;

public class PropertyTooltip : MonoBehaviour
{
    public Property property;

    private TMP_Text title => GetComponentsInChildren<TMP_Text>()[0]; 
    private TMP_Text description => GetComponentsInChildren<TMP_Text>()[1]; 
    private TMP_Text rent => GetComponentsInChildren<TMP_Text>()[2]; 
    private TMP_Text price => GetComponentsInChildren<TMP_Text>()[3]; 

    private void Update()
    {
        if (property == null) return;

        title.text = property.title;
        description.text = property.description;
        rent.text = "Rent: $" + property.rent;
        price.text = "Price: $" + property.price;
    }
}
