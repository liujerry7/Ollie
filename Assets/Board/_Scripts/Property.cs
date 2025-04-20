using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Property")]
public class Property : ScriptableObject
{
    [SerializeField] public string title;
    [SerializeField] public string type;
    [SerializeField] public float rent;
    [SerializeField] public float price;
    [SerializeField] public Sprite sprite;

    [HideInInspector] public Character owner;
}
