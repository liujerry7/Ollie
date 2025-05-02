using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    public static EventBus instance;

    public UnityAction OnTurnStart;
    public UnityAction OnTurnEnd;

    private void Awake()
    {
        if (instance == null)
            instance = this; 
    }
}
