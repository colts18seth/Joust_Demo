using MalbersAnimations.Controller;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject enemyHorse;
    [SerializeField] private MAnimal mAnimal;
    private float lastHorsePosition;
    private Vector3 enemyStartingPosition;
    private Vector3 enemyHorseStartingPosition;

    private void Start()
    {
        HandleGameStateChanged(GameManager.Instance.State);
        GameManager.OnGameStateChanged += HandleGameStateChanged;
        enemyStartingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        enemyHorseStartingPosition = new Vector3(enemyHorse.transform.position.x, enemyHorse.transform.position.y, enemyHorse.transform.position.z);
        lastHorsePosition = enemyHorse.transform.position.x;
    }

    private void Update()
    {
        float childMovement = enemyHorse.transform.position.x - lastHorsePosition;
        transform.position = new Vector3 (-35.9412231f + childMovement, 1.73408031f, -6.9470005f);
        //Vector3(-35.9412231, 1.73408031, -6.9470005)
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
        transform.position = new Vector3(enemyStartingPosition.x, enemyStartingPosition.y, enemyStartingPosition.z);
        enemyHorse.transform.position = new Vector3(enemyHorseStartingPosition.x, enemyHorseStartingPosition.y, enemyHorseStartingPosition.z);
        lastHorsePosition = enemyHorseStartingPosition.x;
    }
}