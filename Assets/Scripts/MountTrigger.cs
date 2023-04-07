using HurricaneVR.Framework.ControllerInput;
using UnityEngine;

public class MountTrigger : MonoBehaviour
{
    private bool _canMount;
    public MountHorse MountHorse;
    public float mountTimer = 0;

    private void Update()
    {
        if (_canMount && !MountHorse.IsMounted)
        {
            if (HVRInputManager.Instance.RightController.SecondaryButtonState.Active == true)
            {
                mountTimer += Time.deltaTime;
                if (mountTimer >= 1f)
                {
                    MountHorse.MountHorseMethod();
                    mountTimer = 0;
                }
            }
            else if (mountTimer > 0)
            {
                mountTimer = 0;
            }
        }

        if (MountHorse.IsMounted)
        {
            if (HVRInputManager.Instance.RightController.SecondaryButtonState.Active == true)
            {
                mountTimer += Time.deltaTime;
                if (mountTimer >= 1f)
                {
                    MountHorse.Dismount();
                    mountTimer = 0;
                }
            }
            else if (mountTimer > 0)
            {
                mountTimer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canMount = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canMount = false;
        }
    }
}
