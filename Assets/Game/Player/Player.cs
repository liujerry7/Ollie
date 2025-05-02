using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float money = 10f;

    private void Awake()
    {
        if (instance == null)
            instance = this; 
    }
}
