using UnityEngine;

public class InJoustMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _inJoustMenuScreen;
    [SerializeField] private GameObject _settingsScreen;
    [SerializeField] private GameObject _inJoustMenuDoneScreen;
    [SerializeField] private GameManager _gameManager;
    public GameObject countdownTextObj;
    //[SerializeField] private Text snapTurnButtonText;

    //private PlayerBehavior _playerBehavior;
    public JoustBehavior _joustBehavior;

    private void Awake()
    {
        _inJoustMenuScreen.SetActive(false);
        _inJoustMenuDoneScreen.SetActive(false);
        _settingsScreen.SetActive(false);
        countdownTextObj.SetActive(false);
    }

    /*private void Start()
    {
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
    }*/

    public void ToggleMenu(bool isOpen)
    {
        if(isOpen)
        {
            _inJoustMenuDoneScreen.SetActive(false);
            _settingsScreen.SetActive(false);
            _inJoustMenuScreen.SetActive(isOpen);
        }
        else
        {
            _inJoustMenuDoneScreen.SetActive(false);
            _settingsScreen.SetActive(false);
            _inJoustMenuScreen.SetActive(isOpen);
        }
        
    }
    
    public void ToggleMenuDone(bool isOpen)
    {
        if(isOpen)
        {
            _inJoustMenuScreen.SetActive(false);
            _settingsScreen.SetActive(false);
            _inJoustMenuDoneScreen.SetActive(isOpen);
        }
        else
        {
            _inJoustMenuScreen.SetActive(false);
            _settingsScreen.SetActive(false);
            _inJoustMenuDoneScreen.SetActive(isOpen);
        }
        
    }

    public void OnStartClicked()
    {
        ToggleMenu(false);
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