using HurricaneVR.Framework.Core.Player;
using MalbersAnimations;
using MalbersAnimations.Controller;
using UnityEngine;

public class MoveHorse : MonoBehaviour
{
    public GameObject Horse;
    public MalbersInput HorseInput;
    public MountHorse MountHorse;
    public Transform MountPosition;
    public HVRPlayerController Controller;
    public GameObject player;
    public MAnimal Animal;

    void Update()
    {
        if(MountHorse.IsMounted)
        {
            Controller.MoveSpeed = 0;
            Controller.SmoothTurnSpeed = 0;
            if(Animal.Sleep == true)
            {
                Animal.Sleep = false;
            }
            else
            {
                HorseInput.enabled = true;
            }
        }
        else
        {
            Animal.Sleep = true;

            Controller.MoveSpeed = 2f;
            Controller.SmoothTurnSpeed = 250f;
        }
    }
}
