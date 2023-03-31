using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;

public class MountHorse : MonoBehaviour
{
    [SerializeField] Transform mountPosition;
    [SerializeField] GameObject player;
    [SerializeField] GameObject horse;
    [SerializeField] Camera playerHead;
    [SerializeField] float MountHeight;

    public HVRCameraRig CameraRig;

    [ContextMenu("Mount Horse")]
    public void MountHorseMethod()
    {
        CameraRig.CameraYOffset = MountHeight;

        var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = mountPosition.position - playerHead.transform.position;
        player.transform.position += distanceDiff;

        player.transform.parent = horse.transform;
    }
}