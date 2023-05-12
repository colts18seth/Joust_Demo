using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private Text snapTurnButtonText;

    //private PlayerBehavior _playerBehavior;

    private void Start()
    {
        //_playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    public void OnStartClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void OnSettingsClicked()
    {
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(true);
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
        mainMenuScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
}