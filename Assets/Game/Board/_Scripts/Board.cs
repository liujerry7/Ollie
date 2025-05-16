using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Property> propertyList = new List<Property>();
    public List<BoardSpace> spaces = new List<BoardSpace>();

    public GameObject boardSpacePrefab;

    public int numInitSpaces;

    public void Init()
    {
        foreach (BoardSpace space in spaces)
        {
            Destroy(space.gameObject);
        }

        spaces.Clear();

        for (int i = 0; i < numInitSpaces; i++)
        {
            GameObject boardSpaceObj = Instantiate(boardSpacePrefab, transform);
            BoardSpace boardSpace = boardSpaceObj.GetComponent<BoardSpace>();

            boardSpaceObj.transform.position = new Vector3((i - Mathf.FloorToInt(numInitSpaces / 2)) * 10f, boardSpaceObj.transform.position.y, boardSpaceObj.transform.position.z);
            boardSpace.owned = false;

            spaces.Add(boardSpace);
        }
    }

    public void Randomize()
    {
        foreach (BoardSpace space in spaces)
            space.Randomize(propertyList);
    }

    public BoardSpace GetBoardSpaceAt(float pos)
    {
        float leftPos = spaces[0].transform.position.x;
        int idx = Mathf.RoundToInt((pos - leftPos) / 10f);

        if (idx < 0) return spaces[0];
        if (idx >= spaces.Count) return spaces[spaces.Count - 1];

        return spaces[idx];
    }
}
