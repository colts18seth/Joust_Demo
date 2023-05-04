using HurricaneVR.Framework.Core.Player;
using MalbersAnimations;
using MalbersAnimations.Controller;
using UnityEngine;

public class MoveHorse : MonoBehaviour
{
    public GameObject Horse;
    public MalbersInput HorseInput;
    public HorseBehavior horseBehavior;
    public Transform MountPosition;
    public HVRPlayerController Controller;
    public GameObject player;
    public MAnimal Animal;
    public Rigidbody rb;

    private void Start()
    {
        Animal.LockMovement = true;
    }

    void Update()
    {
        if(horseBehavior.IsMounted)
        {            
            if(Animal.LockMovement)
            {
                Animal.LockMovement = false;
                Controller.MoveSpeed = 0;
                Controller.SmoothTurnSpeed = 0;
            }
        }
        else
        {
            if (!Animal.LockMovement)
            {
                Animal.LockMovement = true;

                Controller.MoveSpeed = 2f;
                Controller.SmoothTurnSpeed = 250f;
            }
        }
    }
}