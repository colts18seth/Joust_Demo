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
    public MAnimal _animal;
    public float MountHeight;
    public bool IsMounted = false;

    private void Update()
    {
        UpdateHeight();
    }

    [ContextMenu("Mount Horse")]
    public void MountHorseMethod()
    {
        if (IsMounted) { return; }

        leftHand.SetActive(false);

        var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = mountPosition.position - playerHead.transform.position;
        player.transform.position += distanceDiff;

        characterController.height = MountHeight;

        player.transform.SetParent(gameObject.transform);

        IsMounted = true;
    }

    [ContextMenu("Dismount Horse")]
    public void Dismount()
    {
        if (!IsMounted) { return; }

        leftHand.SetActive(true);

        player.transform.position = mountPosition.transform.position + new Vector3(1, 0.5f, 0);

        player.transform.parent = null;

        IsMounted = false;
    }

    public void UpdateJoustRotation()
    {
        _animal.LockHorizontalMovement = true;
        transform.position = new Vector3(-0.5f, 0f, -5.5f);
        Vector3 direction = horseTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
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