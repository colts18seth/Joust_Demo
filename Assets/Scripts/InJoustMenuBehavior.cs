using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InJoustMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _inJoustMenuScreen;
    [SerializeField] private GameObject _settingsScreen;
    [SerializeField] private GameManager _gameManager;
    public GameObject countdownTextObj;
    //[SerializeField] private Text snapTurnButtonText;

    //private PlayerBehavior _playerBehavior;
    private bool _isMenuOpen = false;
    public JoustBehavior _joustBehavior;

    private void Awake()
    {
        _inJoustMenuScreen.SetActive(false);
        _settingsScreen.SetActive(false);
        countdownTextObj.SetActive(false);
    }

    /*private void Start()
    {
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
    }*/

    public void ToggleMenu()
    {
        _isMenuOpen = !_isMenuOpen;
        _inJoustMenuScreen.SetActive(_isMenuOpen);
        _settingsScreen.SetActive(false);
    }

    public void OnStartClicked()
    {
        ToggleMenu();
        countdownTextObj.SetActive(true);
        StartCoroutine(_joustBehavior.CountdownToJoust());
    }

    public void OnSettingsClicked()
    {
        _inJoustMenuScreen.SetActive(false);
        _settingsScreen.SetActive(true);
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
        _inJoustMenuScreen.SetActive(true);
        _settingsScreen.SetActive(false);
    }
}