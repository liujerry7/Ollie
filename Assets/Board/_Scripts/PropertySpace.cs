using UnityEngine;

public class PropertySpace : MonoBehaviour
{
    public Property property;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = property.sprite;
    }
}
