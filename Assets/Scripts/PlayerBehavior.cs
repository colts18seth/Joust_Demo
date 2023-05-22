using HurricaneVR.Framework.Core.Player;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private HVRPlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<HVRPlayerController>();
    }

    private void Start()
    {
        HandleGameStateChanged(GameManager.Instance.State);
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.FreeRoam:
                AllowPlayerMovement(true);
                break;
            case GameState.Pause:
                AllowPlayerMovement(false);
                break;
            default:
                break;
        }
    }

    private void AllowPlayerMovement(bool canMove)
    {
        _playerController.MoveSpeed = canMove ? 2 : 0;
    }
}