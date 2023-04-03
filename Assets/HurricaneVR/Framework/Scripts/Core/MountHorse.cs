using UnityEngine;

public class MountHorse : MonoBehaviour
{
    [SerializeField] Transform mountPosition;
    [SerializeField] GameObject player;
    [SerializeField] GameObject horse;
    [SerializeField] Camera playerHead;
    public CharacterController characterController;
    public float MountHeight;
    public bool IsMounted = false;

    [ContextMenu("Mount Horse")]
    public void MountHorseMethod()
    {
        player.SetActive(false);

        var rotationAngleY = mountPosition.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = mountPosition.position - playerHead.transform.position;
        player.transform.position += distanceDiff;

        characterController.height = MountHeight;

        player.transform.SetParent(horse.transform);

        player.SetActive(true);

        IsMounted = true;
    }
}