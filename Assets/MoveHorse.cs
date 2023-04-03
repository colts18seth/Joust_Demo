using HurricaneVR.Framework.Core.Player;
using MalbersAnimations;
using UnityEngine;

public class MoveHorse : MonoBehaviour
{
    public GameObject Horse;
    public MalbersInput HorseInput;
    public MountHorse MountHorse;
    public Transform MountPosition;
    public HVRPlayerController Controller;
    public GameObject player;

    void Update()
    {
        if(MountHorse.IsMounted)
        {
            Controller.MoveSpeed = 0;

            player.transform.position = MountPosition.transform.position;


            HorseInput.enabled = true;

        }
        else
        {
            HorseInput.enabled = false;

            Controller.MoveSpeed = 1.8f;

        }
    }
}
