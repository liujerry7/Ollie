using Unity.Cinemachine;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    public Board board;
    public CinemachineCamera anchor;

    private int boardIdx = 2;

    public void MoveRight()
    {
        boardIdx = (boardIdx + 1) % board.spaces.Count;
        anchor.Follow = board.spaces[boardIdx].transform;
    }

    public void MoveLeft()
    {
        boardIdx = boardIdx == 0 ? board.spaces.Count - 1 : boardIdx - 1;
        anchor.Follow = board.spaces[boardIdx].transform;
    }
}
