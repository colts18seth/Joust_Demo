using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;

public class MountHorse : MonoBehaviour
{
    public Transform mountPosition;
    public GameObject player;
    public GameObject horse;
    public Camera playerHead;
    public CharacterController characterController;
    public HVRPlayerController Controller;
    public HVRCameraRig CameraRig;
    public float MountHeight;
    public bool IsMounted = false;

    private void Update()
    {
        if (HVRInputManager.Instance.LeftController.MenuButtonState.JustActivated == true)
        {
            ResetViewMethod();
        }
    }

    [ContextMenu("Mount Horse")]
    public void MountHorseMethod()
    {
        if (IsMounted == true) { return; }

        //player.SetActive(false);

        var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = mountPosition.position - playerHead.transform.position;
        player.transform.position += distanceDiff;

        characterController.height = MountHeight;

        player.transform.SetParent(horse.transform);

        //player.SetActive(true);

        IsMounted = true;
    }

    [ContextMenu("Dismount Horse")]
    public void Dismount()
    {
        if (IsMounted != true) { return; }

        player.transform.position = mountPosition.transform.position + new Vector3(1, 0.5f, 0);

        player.transform.parent = null;

        IsMounted = false;
    }

    public void ResetViewMethod()
    {
        if (IsMounted)
        {
            var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
            player.transform.Rotate(0, rotationAngleY, 0);

            var distanceDiff = mountPosition.position - playerHead.transform.position;
            player.transform.position += distanceDiff;
        }

        characterController.height = Mathf.Clamp(CameraRig.AdjustedCameraHeight, 0.3f, CameraRig.AdjustedCameraHeight);
        characterController.center = new Vector3(0, characterController.height * .5f + characterController.skinWidth, 0f);
    }
}