using UnityEngine;

public class DismountHorse : MonoBehaviour
{
    public CharacterController characterController;
    public Transform mountPosition;
    public MountHorse MountHorse;
    public GameObject player;

    [ContextMenu("Dismount Horse")]
    public void Dismount()
    {
        if(MountHorse.IsMounted != true) { return; }

        Debug.Log("mountPosition.position: " + mountPosition.position);
        Debug.Log("mountPosition.localPosition: " + mountPosition.localPosition);

        player.transform.parent = null;

        player.transform.position = mountPosition.transform.position + new Vector3( mountPosition.localPosition.x + 1, 0, 0);

        MountHorse.IsMounted = false;
    }
}