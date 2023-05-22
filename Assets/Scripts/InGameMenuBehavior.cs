using HurricaneVR.Framework.ControllerInput;
using UnityEngine;

public class InGameMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _inGameMenuScreen;
    [SerializeField] private GameObject _inGameSettingsScreen;
    [SerializeField] private GameManager _gameManager;
    //[SerializeField] private Text snapTurnButtonText;
    private PlayerBehavior _playerBehavior;

    private void Update()
    {
        if (HVRInputManager.Instance.RightController.MenuButtonState.Active == true)
        {
            ToggleMenu(true);
            Debug.Log("clicked");
        }
    }

    private void Awake()
    {
        _inGameMenuScreen.SetActive(false);
        _inGameSettingsScreen.SetActive(false);
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    public void ToggleMenu(bool isOpen)
    {
        _inGameSettingsScreen.SetActive(false);
        _inGameMenuScreen.SetActive(isOpen);
    }

    public void OnResumeClicked()
    {
        ToggleMenu(false);
    }

    public void OnSettingsClicked()
    {
        _inGameMenuScreen.SetActive(false);
        _inGameSettingsScreen.SetActive(true);
    }

    public void OnQuitClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.Quit);
    }

    public void OnToggleSnapTurnClicked()
    {
        //bool isSnapTurnOn = _playerBehavior.ToggleSnapTurn();

        /*if (isSnapTurnOn)
        {
            snapTurnButtonText.text = "Toggle Snap Turn: On";
        }
        else
        {
            snapTurnButtonText.text = "Toggle Snap Turn: Off";
        }*/
    }

    public void OnSettingsBackClicked()
    {
        _inGameSettingsScreen.SetActive(false);
        _inGameMenuScreen.SetActive(true);
    }
}