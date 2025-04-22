using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] public List<Property> properties;
    [SerializeField] public float propertyWidth = 10f;

    public int GetSize()
    {
        return properties.Count;
    }

    private void RenderProperties()
    {
        while (transform.childCount > 0) {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        int idx = 0;

        foreach (Property property in properties)
        {
            GameObject propertyUnitObject = new GameObject();
            propertyUnitObject.AddComponent<SpriteRenderer>();
            propertyUnitObject.GetComponent<SpriteRenderer>().sprite = property.sprite;
            propertyUnitObject.name = property.title;
            propertyUnitObject.transform.SetParent(transform);
            propertyUnitObject.transform.position = new Vector2(idx * 10f, 4);
            idx++;
        }
    }

    private void Start()
    {
        RenderProperties();
    }

    // public UnityAction PropertySkipped;

    // [SerializeField] private List<Property> properties;
    // [SerializeField] private GameObject buyButtonPrefab;
    // [SerializeField] private GameObject skipButtonPrefab;
    // [SerializeField] private GameObject propertySnippetPrefab;
    // [SerializeField] private AudioClip kachingSfx;

    // private GameObject propertySnippetObject;
    // private GameObject buyButtonObject;
    // private GameObject skipButtonObject;

    // public void PromptBuy(int propertyIdx, Character character)
    // {
    //     if (properties[propertyIdx].owner != null)
    //     {
    //         properties[propertyIdx].owner.money += properties[propertyIdx].rent;
    //         character.money -= properties[propertyIdx].rent;
    //         PropertySkipped?.Invoke();
    //         Speaker.instance.PlaySfxClip(kachingSfx, character.transform, 1);
    //         return;
    //     }

    //     propertySnippetObject = Instantiate(propertySnippetPrefab, transform);
    //     buyButtonObject = Instantiate(buyButtonPrefab, transform);
    //     skipButtonObject = Instantiate(skipButtonPrefab, transform);

    //     propertySnippetObject.transform.position = new Vector2(propertyIdx * 10, 8);
    //     propertySnippetObject.GetComponent<PropertySnippet>().property = properties[propertyIdx];

    //     buyButtonObject.transform.position = new Vector2(propertyIdx * 10 - 2, -4);
    //     buyButtonObject.GetComponentInChildren<Button>().onClick.AddListener(() => BuyProperty(propertyIdx, character));

    //     skipButtonObject.transform.position = new Vector2(propertyIdx * 10 + 2, -4);
    //     skipButtonObject.GetComponentInChildren<Button>().onClick.AddListener(SkipProperty);
    // }

    // private void BuyProperty(int propertyIdx, Character character)
    // {
    //     Destroy(propertySnippetObject);
    //     Destroy(buyButtonObject);
    //     Destroy(skipButtonObject);

    //     properties[propertyIdx].owner = character;
    //     character.money -= properties[propertyIdx].price;
    //     PropertySkipped?.Invoke();
    // }

    // private void SkipProperty()
    // {
    //     Destroy(propertySnippetObject);
    //     Destroy(buyButtonObject);
    //     Destroy(skipButtonObject);

    //     PropertySkipped?.Invoke();
    // }

    // private void Start()
    // {
    //     int idx = 0;

    //     foreach (Property property in properties)
    //     {
    //         GameObject propertyUnitObject = new GameObject();
    //         propertyUnitObject.AddComponent<SpriteRenderer>();
    //         propertyUnitObject.GetComponent<SpriteRenderer>().sprite = property.sprite;
    //         propertyUnitObject.name = property.title;
    //         propertyUnitObject.transform.SetParent(transform);
    //         propertyUnitObject.transform.position = new Vector2(idx * 10f, 4);
    //         idx++;
    //     }
    // }
}
