using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Property")]
public class Property : ScriptableObject
{
    public string title;
    public string description;
    public float price;
    public float rent;

    public Sprite sprite;
}
