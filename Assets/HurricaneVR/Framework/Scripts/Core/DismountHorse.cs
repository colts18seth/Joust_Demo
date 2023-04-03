using UnityEngine;

public class DismountHorse : MonoBehaviour
{
    public CharacterController characterController;
    public Transform mountPosition;
    public MountHorse MountHorse;
    public GameObject player;
    private Vector3 currentPosition;

    [ContextMenu("Dismount Horse")]
    public void Dismount()
    {
        if(MountHorse.IsMounted != true) { return; }

        MountHorse.IsMounted = false;

        player.transform.parent = null;

        currentPosition = mountPosition.transform.position;

        player.transform.position = currentPosition + new Vector3( 1f, 0, 1f);
    }
}