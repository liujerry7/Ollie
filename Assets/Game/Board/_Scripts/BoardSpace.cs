using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public Property property;
    public PropertyTooltip tooltip => GetComponentInChildren<PropertyTooltip>(true);
    public SpriteRenderer spriteRenderer => GetComponentInChildren<SpriteRenderer>();
    public List<Character> characters = new List<Character>();

    public bool owned;
    public bool selected;

    public void AddCharacter(Character character)
    {
        characters.Add(character);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.position = new Vector3((10f / (characters.Count + 1)) * (i + 1) + transform.position.x - 5, transform.position.y, 0);
        }
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.position = new Vector3((10f / (characters.Count + 1)) * (i + 1) + transform.position.x - 5, transform.position.y, 0);
        }
    }

    public void ClearCharacters()
    {
        characters.Clear();
    }

    public void Randomize(List<Property> propertyList)
    {
        if (owned) return;

        int randIdx = Random.Range(0, propertyList.Count);
        property = Instantiate(propertyList[randIdx]);
        spriteRenderer.sprite = property.sprite;
    }

    public void Buy(Player player)
    {
        if (owned) return;

        owned = true;
        player.money -= property.price;
    }

    public void Sell(Player player)
    {
        if (!owned) return;

        owned = false;
        player.money += Mathf.RoundToInt(property.price / 2);
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
