using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Property> propertyList;
    public List<BoardSpace> spaces;

    public void FreeSpaces()
    {
        foreach (BoardSpace space in spaces)
            space.owned = false;
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
