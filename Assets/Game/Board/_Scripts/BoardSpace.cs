using UnityEngine;
using UnityEngine.Events;

public class BoardSpace : MonoBehaviour
{
    public Property property;

    public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    public UnityEvent OnBuy;

    public bool owned;

    public void Randomize()
    {
        if (owned) return;

        int randIdx = Random.Range(0, PropertiesList.instance.properties.Count);
        property = PropertiesList.instance.properties[randIdx];
        spriteRenderer.sprite = property.sprite;
    }

    public void Buy()
    {
        if (Player.instance.money >= property.price)
        {
            owned = true;
            Player.instance.money -= property.price;
        }
    }

    private void OnMouseDown()
    {
        OnBuy?.Invoke();
    }

}
