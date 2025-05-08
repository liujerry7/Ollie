using System.Collections.Generic;
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

    public void Randomize(List<Property> propertyList)
    {
        if (owned) return;

        int randIdx = Random.Range(0, propertyList.Count);
        property = Instantiate(propertyList[randIdx]);
        spriteRenderer.sprite = property.sprite;
    }

    public void Buy()
    {
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
