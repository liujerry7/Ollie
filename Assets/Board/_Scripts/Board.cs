using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private List<Property> properties;
    [SerializeField] private GameObject propertySpacePrefab;
    [SerializeField] private float propertySpaceWidth = 10f;

    private List<PropertySpace> propertySpaces;

    public PropertySpace GetLeftPropertySpace()
    {
        return propertySpaces[0];
    }

    public PropertySpace GetRightPropertySpace()
    {
        return propertySpaces[propertySpaces.Count - 1];
    }

    public float GetSize()
    {
        return GetRightPropertySpace().transform.position.x - GetLeftPropertySpace().transform.position.x;
    }

    public Property GetPropertyAt(float pos)
    {
        return propertySpaces[CalcDistSpaces(pos - propertySpaces[0].transform.position.x)].property;
    }

    public int GetRandomSpace()
    {
        float randomPos = Random.Range(propertySpaces[0].transform.position.x, propertySpaces[propertySpaces.Count - 1].transform.position.x);
        return Mathf.RoundToInt(randomPos / propertySpaceWidth);
    }

    public float CalcSpacesDist(int numSpaces)
    {
        return numSpaces * propertySpaceWidth;
    }

    public int CalcDistSpaces(float dist)
    {
        return Mathf.FloorToInt(dist / propertySpaceWidth);
    }

    public float GetRightBound()
    {
        return propertySpaces[propertySpaces.Count - 1].transform.position.x - 2 * propertySpaceWidth;
    }

    public float GetLeftBound()
    {
        return propertySpaces[0].transform.position.x + 2 * propertySpaceWidth;
    }

    public void RotatePropertiesRight()
    {
        PropertySpace rightProperty = propertySpaces[propertySpaces.Count - 1];
        PropertySpace leftProperty = propertySpaces[0];

        leftProperty.transform.position = new Vector2(rightProperty.transform.position.x + propertySpaceWidth, leftProperty.transform.position.y);

        propertySpaces.Remove(leftProperty);
        propertySpaces.Add(leftProperty);
    }

    public void RotatePropertiesLeft()
    {
        PropertySpace rightProperty = propertySpaces[propertySpaces.Count - 1];
        PropertySpace leftProperty = propertySpaces[0];

        rightProperty.transform.position = new Vector2(leftProperty.transform.position.x - propertySpaceWidth, rightProperty.transform.position.y);

        propertySpaces.Remove(rightProperty);
        propertySpaces.Insert(0, rightProperty);
    }

    private void InitProperties()
    {
        propertySpaces = new List<PropertySpace>();

        for (int i = 0; i < properties.Count; i++)
        {
            GameObject propertySpaceObj = Instantiate(propertySpacePrefab, transform);
            PropertySpace propertySpace = propertySpaceObj.GetComponent<PropertySpace>();

            propertySpace.transform.position = new Vector2(propertySpaceWidth * i, 4);
            propertySpace.property = properties[i];

            propertySpaces.Add(propertySpace);
        }
    }

    private void Start()
    {
        InitProperties();
    }
}
