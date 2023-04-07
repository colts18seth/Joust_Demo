using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;

public class ResetView : MonoBehaviour
{
    public CharacterController CharacterController;
    public MountHorse MountHorse;
    public HVRCameraRig CameraRig;
    public GameObject player;
    public Transform mountPosition;
    public Camera playerHead;

    private void Update()
    {
        if (HVRInputManager.Instance.LeftController.MenuButtonState.JustActivated == true)
        {
            ResetViewMethod();
        }
    }

    public void ResetViewMethod()
    {
        if (MountHorse.IsMounted)
        {
            var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
            player.transform.Rotate(0, rotationAngleY, 0);

            var distanceDiff = mountPosition.position - playerHead.transform.position;
            player.transform.position += distanceDiff;
        }

        CharacterController.height = Mathf.Clamp(CameraRig.AdjustedCameraHeight, 0.3f, CameraRig.AdjustedCameraHeight);
        CharacterController.center = new Vector3(0, CharacterController.height * .5f + CharacterController.skinWidth, 0f);
    }
}
