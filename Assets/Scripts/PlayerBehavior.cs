/*using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] XRRayInteractor[] _teleportationInteractors;
    private ActionBasedControllerManager[] _actionBasedControllerManagers;
    private DynamicMoveProvider _dynamicMoveProvider;
    private GrabMoveProvider[] _grabMoveProviders;

    private void Awake()
    {
        _actionBasedControllerManagers = GetComponentsInChildren<ActionBasedControllerManager>();
        _dynamicMoveProvider = GetComponentInChildren<DynamicMoveProvider>();
        _grabMoveProviders = GetComponentsInChildren<GrabMoveProvider>();
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

    public bool ToggleSnapTurn()
    {
        foreach (var controllerManager in _actionBasedControllerManagers)
        {
            controllerManager.smoothTurnEnabled = !controllerManager.smoothTurnEnabled;
        }

        return !_actionBasedControllerManagers[0].smoothTurnEnabled;
    }

    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                AllowPlayerMovement(false);
                break;
            case GameState.Play:
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
        _dynamicMoveProvider.moveSpeed = canMove ? 1 : 0;
        foreach (var grabMoveProvider in _grabMoveProviders)
        {
            grabMoveProvider.enabled = canMove;
        }
        foreach (var teleportationInteractor in _teleportationInteractors)
        {
            teleportationInteractor.enabled = canMove;
        }
    }
}*/