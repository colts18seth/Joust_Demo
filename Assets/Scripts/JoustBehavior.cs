using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Player;
using MalbersAnimations.Controller;
using System.Collections;
using UnityEngine;

public class JoustBehavior : MonoBehaviour
{
    public GameObject _startJoustText;
    public bool isJousting => _isJousting;
    public GameManager _gameManager;
    public int totalPlayerScore;
    public bool canJoust;

    //private int _damageDealt;
    //private int _playerHealth;

    [SerializeField] private InJoustMenuBehavior _inJoustMenuBehavior;
    [SerializeField] private StartJoustArea _startJoustArea;

    private HorseBehavior _horseBehavior;
    private HVRScreenFade _screenFader;
    //private GameObject _horse;
    private float _startJoustTimer = 0;
    private bool _hasScored = false;
    private bool _isJousting = false;

    private void Awake()
    {
        _horseBehavior = FindObjectOfType<HorseBehavior>();
        _startJoustText = GameObject.FindGameObjectWithTag("StartJoust");
        _startJoustText.SetActive(false);
        //_horse = GameObject.FindGameObjectWithTag("Animal");
        if (!_screenFader)
        {
            var finder = FindObjectOfType<HVRGlobalFadeFinder>();
            if (finder)
            {
                _screenFader = finder.gameObject.GetComponent<HVRScreenFade>();
            }
        }
    }

    private void Update()
    {
        canJoust = _startJoustArea.canJoust;
        if(canJoust && _horseBehavior.IsMounted && !_isJousting)
        {
            _startJoustText.SetActive(true);
            if(HVRInputManager.Instance.RightController.PrimaryButtonState.Active == true )
            {
                _startJoustTimer += Time.deltaTime;
                if (_startJoustTimer >= 1f)
                {
                    _isJousting = true;
                    OpenJoustMenu();
                    _startJoustText.SetActive(false);
                    _startJoustTimer = 0;
                }
            }
            else if (_startJoustTimer > 0)
            {
                _startJoustTimer = 0;
            }
        }
    }

    private void OpenJoustMenu()
    {
        _gameManager.UpdateGameState(GameState.Pause);
        _inJoustMenuBehavior.ToggleMenu();
        _horseBehavior.UpdateJoustRotation();
    }

    public void AddScore(string tag)
    {
        if (!_hasScored)
        {
            _hasScored = true;
            int score = 0;

            if (tag == "Enemy 1")
            {
                score = 1;
            }
            else if (tag == "Enemy 2")
            {
                score = 2;
            }
            else if (tag == "Enemy 3")
            {
                score = 3;
            }

            totalPlayerScore += score;
        }
        Debug.Log("Score: " + totalPlayerScore);
    }

    public IEnumerator ReturnToJoustStart()
    {
        yield return new WaitForSeconds(3f);
        _gameManager.UpdateGameState(GameState.Pause);
        _screenFader.Fade(1, 5);

        yield return new WaitForSeconds(1f);
        OpenJoustMenu();
        _screenFader.Fade(0, 5);
    }
}