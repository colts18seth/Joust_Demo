using HurricaneVR.Framework.Core.Player;
using MalbersAnimations.Controller;
using Unity.VisualScripting;
using UnityEngine;

public class HorseBehavior : MonoBehaviour
{
    public CharacterController characterController;
    public HVRPlayerController Controller;
    public JoustBehavior joustBehavior;
    public Transform mountPosition;
    public HVRCameraRig CameraRig;
    public Transform horseTarget;
    public GameObject leftHand;
    public GameObject player;
    public Camera playerHead;
    public Rigidbody rb;
    public MAnimal _animal;
    public float MountHeight;
    public bool IsMounted = false;


    private void Start()
    {
        HandleGameStateChanged(GameManager.Instance.State);
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    private void Update()
    {
        UpdateHeight();
    }

    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.FreeRoam:
                _animal.LockMovement = true;
                Controller.MoveSpeed = 2f;
                Controller.SmoothTurnSpeed = 250f;
                _animal.LockHorizontalMovement = false;
                break;
            case GameState.MountedFreeRoam:
                _animal.LockMovement = false;
                Controller.MoveSpeed = 0;
                Controller.SmoothTurnSpeed = 0;
                _animal.LockHorizontalMovement = false;
                break;
            case GameState.Joust:
                _animal.LockMovement = false;
                _animal.LockHorizontalMovement = true;
                break;
            case GameState.Pause:
                _animal.LockMovement = true;
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }

    [ContextMenu("Mount Horse")]
    public void MountHorseMethod()
    {
        if (IsMounted) { return; }

        IsMounted = true;

        HandleGameStateChanged(GameState.MountedFreeRoam);

        leftHand.SetActive(false);

        MountPositionandRotation();

        player.transform.SetParent(gameObject.transform);
    }

    [ContextMenu("Dismount Horse")]
    public void Dismount()
    {
        if (!IsMounted) { return; }

        IsMounted = false;

        HandleGameStateChanged(GameState.FreeRoam);

        leftHand.SetActive(true);

        player.transform.position = mountPosition.transform.position + new Vector3(1, 0.5f, 0);

        player.transform.parent = null;
    }

    public void UpdateJoustRotation()
    {        
        transform.position = new Vector3(-0.5f, 0f, -5.5f);
        Vector3 direction = horseTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
        MountPositionandRotation();
    }

    public void MountPositionandRotation()
    {
        var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = mountPosition.position - playerHead.transform.position;
        player.transform.position += distanceDiff;

        characterController.height = MountHeight;
    }

    private void UpdateHeight()
    {
        if (!IsMounted)
        {
            characterController.height = Mathf.Clamp(CameraRig.AdjustedCameraHeight, Controller.MinHeight, CameraRig.AdjustedCameraHeight);
            characterController.center = new Vector3(0, characterController.height * .5f + characterController.skinWidth, 0f);
            return;
        }
        characterController.height = MountHeight;
    }
}