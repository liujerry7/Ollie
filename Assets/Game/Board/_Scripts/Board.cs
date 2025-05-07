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
        float leftPos = -20;
        int idx = Mathf.FloorToInt((pos - leftPos) / 10f);

        if (idx < 0) return spaces[0];
        if (idx >= spaces.Count) return spaces[spaces.Count - 1];

        return spaces[idx];
    }
}
