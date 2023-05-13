using UnityEngine;
using UnityEngine.UI;

public class InJoustMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject inJoustMenuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameManager _gameManager;
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
        inJoustMenuScreen.SetActive(_isMenuOpen);
        settingsScreen.SetActive(false);
    }

    public void OnStartClicked()
    {
        ToggleMenu();
        _gameManager.UpdateGameState(GameState.Joust);
    }

    public void OnSettingsClicked()
    {
        inJoustMenuScreen.SetActive(false);
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
        inJoustMenuScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
}