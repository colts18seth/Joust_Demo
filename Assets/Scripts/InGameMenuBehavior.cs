using UnityEngine;
using UnityEngine.UI;

public class InGameMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenuScreen;
    [SerializeField] private GameObject settingsScreen;
    //[SerializeField] private Text snapTurnButtonText;

    //private PlayerBehavior _playerBehavior;
    private bool _isMenuOpen = false;

    /*private void Start()
    {
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
    }*/

    public void ToggleMenu()
    {
        _isMenuOpen = !_isMenuOpen;
        inGameMenuScreen.SetActive(_isMenuOpen);
        settingsScreen.SetActive(false);
    }

    public void OnSettingsClicked()
    {
        inGameMenuScreen.SetActive(false);
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
        inGameMenuScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
}