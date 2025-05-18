using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public Property property;
    public GameObject sign;

    public PropertyTooltip tooltip => GetComponentInChildren<PropertyTooltip>(true);
    public SpriteRenderer spriteRenderer => GetComponentInChildren<SpriteRenderer>();

    public bool owned;
    public bool selected;

    public float GetWidth()
    {
        return spriteRenderer.bounds.size.x;
    }

    public void Randomize(List<Property> propertyList)
    {
        if (owned) return;

        int randIdx = Random.Range(0, propertyList.Count);
        property = Instantiate(propertyList[randIdx]);
        spriteRenderer.sprite = property.sprite;
        tooltip.property = property;
    }

    public void Buy(Player player)
    {
        if (owned || player.money < property.price)
        {
            Unselect();
            return;
        }

        player.money -= property.price;
        owned = true;
        sign.SetActive(true);
    }

    public void Sell(Player player)
    {
        if (!owned)
        {
            Unselect();
            return;
        }

        player.money += Mathf.RoundToInt(property.price / 3);
        owned = false;
        sign.SetActive(false);
    }

    public void Select()
    {
        if (selected) return;
        
        Vector3 spritePos = spriteRenderer.transform.position;
        spriteRenderer.transform.position = new Vector3(spritePos.x, spritePos.y + 2, spritePos.z);
        selected = true;
    }

    public void Unselect()
    {
        if (!selected) return;
        
        Vector3 spritePos = spriteRenderer.transform.position;
        spriteRenderer.transform.position = new Vector3(spritePos.x, spritePos.y - 2, spritePos.z);
        selected = false;
    }

    private void OnMouseEnter()
    {
        tooltip.property = property;
        tooltip.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        tooltip.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (selected) Unselect();
        else Select();
    }
}
