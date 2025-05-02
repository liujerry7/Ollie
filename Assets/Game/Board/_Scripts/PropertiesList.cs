using System.Collections.Generic;
using UnityEngine;

public class PropertiesList : MonoBehaviour
{
    public static PropertiesList instance;

    public List<Property> properties;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
