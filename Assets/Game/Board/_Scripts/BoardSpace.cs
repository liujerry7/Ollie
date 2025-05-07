using UnityEngine;
using UnityEngine.Events;

public class BoardSpace : MonoBehaviour
{
    public Property property;

    public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    public UnityEvent OnBuy;
    public UnityEvent OnHoverEnter;
    public UnityEvent OnHoverExit;

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
        if (Player.instance.money < property.price || owned) return;
        
        owned = true;
        Player.instance.money -= property.price;
    }

    private void OnMouseEnter()
    {
        OnHoverEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        OnHoverExit?.Invoke();
    }

    private void OnMouseDown()
    {
        OnBuy?.Invoke();
    }
}
