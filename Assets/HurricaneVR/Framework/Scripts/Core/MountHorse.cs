using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Player;
using HurricaneVR.Framework.Core;
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
    public float _mountTimer;

    private void Update()
    {
        if (!IsMounted)
        {
            if (HVRInputManager.Instance.RightController.SecondaryButtonState.Active == true)
            {
                _mountTimer += Time.deltaTime;
                if (_mountTimer >= 1f)
                {
                    //_mountHorse.MountHorseMethod();
                    _mountTimer = 0;
                }
            }
            else if (_mountTimer > 0)
            {
                _mountTimer = 0;
            }
        }
    }

    [ContextMenu("Mount Horse")]
    public void MountHorseMethod()
    {
        if (IsMounted == true) { return; }

        var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = mountPosition.position - playerHead.transform.position;
        player.transform.position += distanceDiff;

        characterController.height = MountHeight;

        player.transform.SetParent(horse.transform);

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
}