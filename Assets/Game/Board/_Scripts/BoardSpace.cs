using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public string title;
    public string description;
    public float price;
    public float rent;

    public Character owner;

    public void Buy(Character character)
    {
        character.money -= price;
        owner = character;
    }

    public void ChargeRent(Character character)
    {
        character.money -= rent;
        owner.money += rent;
    }
}
