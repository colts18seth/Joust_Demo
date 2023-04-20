using HurricaneVR.Framework.ControllerInput;
using UnityEngine;

public class MountTrigger : MonoBehaviour
{
    private bool _canMount;
    public MountHorse MountHorse;
    public float mountTimer = 0;
    public float dismountTextTimer = 0;
    public GameObject mountHorseText;
    public GameObject dismountHorseText;

    private void Awake()
    {
        mountHorseText = GameObject.FindGameObjectWithTag("MountText");
        dismountHorseText = GameObject.FindGameObjectWithTag("DismountText");
        mountHorseText.SetActive(false);
        dismountHorseText.SetActive(false);
    }

    private void Update()
    {
        if (_canMount && !MountHorse.IsMounted)
        {
            mountHorseText.SetActive(true);
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
            dismountTextTimer += Time.deltaTime;
            dismountHorseText.SetActive(true);
            if (dismountTextTimer >= 3f)
            {
                dismountHorseText.SetActive(false);
            }

            if (HVRInputManager.Instance.RightController.SecondaryButtonState.Active == true)
            {
                mountTimer += Time.deltaTime;
                if (mountTimer >= 1f)
                {
                    dismountHorseText.SetActive(false);
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
            mountHorseText.SetActive(false);
            _canMount = false;
        }
    }
}
