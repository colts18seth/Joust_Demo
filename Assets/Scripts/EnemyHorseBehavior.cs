using MalbersAnimations.Controller;
using UnityEngine;

public class EnemyHorseBehavior : MonoBehaviour
{
    [SerializeField] private MAnimal mAnimal;

    private Vector3 startingPosition;

    private void Start()
    {
        HandleGameStateChanged(GameManager.Instance.State);
        GameManager.OnGameStateChanged += HandleGameStateChanged;
        startingPosition = transform.position;
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
                mAnimal.LockMovement = true;
                break;
            case GameState.MountedFreeRoam:
                mAnimal.LockMovement = true;
                break;
            case GameState.Joust:
                mAnimal.LockMovement = false;
                mAnimal.LockHorizontalMovement = true;
                break;
            case GameState.Pause:
                mAnimal.LockMovement = true;
                break;
            default:
                break;
        }
    }

    public void ResetJoustPosition()
    {
        transform.position = startingPosition;
    }
}