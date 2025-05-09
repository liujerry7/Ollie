using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAnchor : MonoBehaviour
{
    public Board board;
    public CinemachineCamera anchor;

    private int boardIdx;

    public void Init()
    {
        boardIdx = Mathf.FloorToInt(board.spaces.Count / 2);
        anchor.Follow = board.spaces[boardIdx].transform;
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            boardIdx = (boardIdx + 1) % board.spaces.Count;
            anchor.Follow = board.spaces[boardIdx].transform;
        }
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            boardIdx = boardIdx == 0 ? board.spaces.Count - 1 : boardIdx - 1;
            anchor.Follow = board.spaces[boardIdx].transform;
        }
    }
}
