using HurricaneVR.Framework.ControllerInput;
using MalbersAnimations.Controller;
using System.Collections;
using UnityEngine;

public class JoustBehavior : MonoBehaviour
{
    public GameObject _startJoustText;
    public GameManager _gameManager;
    public MAnimal animal;
    public bool isJousting => _isJousting;
    public int totalPlayerScore;
    public bool canJoust;
    public FadeBehavior fadeBehavior;

    //private int _damageDealt;
    //private int _playerHealth;

    [SerializeField] private InJoustMenuBehavior _inJoustMenuBehavior;
    [SerializeField] private StartJoustArea _startJoustArea;

    private HorseBehavior _horseBehavior;
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

    public void OpenJoustMenu()
    {
        _gameManager.UpdateGameState(GameState.Pause);
        _horseBehavior.UpdateJoustRotation();
        _inJoustMenuBehavior.ToggleMenu();
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

    public IEnumerator StopTilt()
    {
        yield return new WaitForSeconds(2.5f);
        animal.LockMovement = true;
        yield return new WaitForSeconds(.5f);
        fadeBehavior.FadeOut();
        yield return new WaitForSeconds(1f);
        OpenJoustMenu();
        fadeBehavior.FadeIn();
    }
}