using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<BoardSpace> spaces;

    public void Randomize()
    {
        foreach (BoardSpace space in spaces)
            space.Randomize();
    }

    public BoardSpace GetBoardSpaceAt(float pos)
    {
        int idx = Mathf.FloorToInt(pos / 10f);

        if (idx < 0 || idx >= spaces.Count) return null;

        return spaces[idx];
    }
}
