using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public Property property;
    public List<Character> characters = new List<Character>();
    public GameObject sign;

    public PropertyTooltip tooltip => GetComponentInChildren<PropertyTooltip>(true);
    public SpriteRenderer spriteRenderer => GetComponentInChildren<SpriteRenderer>();

    public bool owned;
    public bool selected;

    public void AddCharacter(Character character)
    {
        characters.Add(character);

        if (property != null && property.title == "House")
            property.rent = 2 * Mathf.Pow(2, characters.Count);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.position = new Vector3((10f / (characters.Count + 1)) * (i + 1) + transform.position.x - 5, transform.position.y, character.transform.position.z);
        }
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);

        if (property != null && property.title == "House")
            property.rent = 2 * Mathf.Pow(2, characters.Count);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.position = new Vector3((10f / (characters.Count + 1)) * (i + 1) + transform.position.x - 5, transform.position.y, character.transform.position.z);
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
        tooltip.property = property;
    }

    public void Buy(Player player)
    {
        if (owned) return;

        player.money -= property.price;
        owned = true;
        sign.SetActive(true);
    }

    public void Sell(Player player)
    {
        if (!owned) return;

        player.money += Mathf.RoundToInt(property.price / 2);
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
