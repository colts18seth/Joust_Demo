using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;

public class ResetView : MonoBehaviour
{
    public CharacterController CharacterController;
    public MountHorse MountHorse;
    public HVRCameraRig CameraRig;

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
            MountHorse.MountHorseMethod();
        }

        CharacterController.height = Mathf.Clamp(CameraRig.AdjustedCameraHeight, 0.3f, CameraRig.AdjustedCameraHeight);
        CharacterController.center = new Vector3(0, CharacterController.height * .5f + CharacterController.skinWidth, 0f);
    }
}
