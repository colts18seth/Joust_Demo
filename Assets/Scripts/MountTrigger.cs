using HurricaneVR.Framework.ControllerInput;
using UnityEngine;

public class MountTrigger : MonoBehaviour
{
    public bool canMount => _canMount;

    private GameObject _dismountHorseText;
    private GameObject _mountHorseText;
    private HorseBehavior _horseBehavior;
    private float _dismountTextTimer = 0;
    private float _mountTimer = 0;
    private bool _canMount = false;

    private void Awake()
    {
        _horseBehavior = FindObjectOfType<HorseBehavior>();
        _mountHorseText = GameObject.FindGameObjectWithTag("MountText");
        _dismountHorseText = GameObject.FindGameObjectWithTag("DismountText");
        _mountHorseText.SetActive(false);
        _dismountHorseText.SetActive(false);
    }

    private void Update()
    {
        if (_canMount && !_horseBehavior.IsMounted)
        {
            _mountHorseText.SetActive(true);
            if (HVRInputManager.Instance.RightController.SecondaryButtonState.Active == true)
            {
                _mountTimer += Time.deltaTime;
                if (_mountTimer >= 1f)
                {
                    _horseBehavior.MountHorseMethod();
                    _mountTimer = 0;
                }
            }
            else if (_mountTimer > 0)
            {
                _mountTimer = 0;
            }
        }

        if (_horseBehavior.IsMounted)
        {
            _mountTimer += Time.deltaTime;
            _dismountHorseText.SetActive(true);
            if (_mountTimer >= 3f)
            {
                _dismountHorseText.SetActive(false);
            }

            if (HVRInputManager.Instance.RightController.SecondaryButtonState.Active == true)
            {
                _dismountTextTimer += Time.deltaTime;
                if (_dismountTextTimer >= 1f)
                {
                    _dismountHorseText.SetActive(false);
                    _horseBehavior.Dismount();
                    _dismountTextTimer = 0;
                }
            }
            else if (_dismountTextTimer > 0)
            {
                _dismountTextTimer = 0;
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
            _mountHorseText.SetActive(false);
        }
    }
}