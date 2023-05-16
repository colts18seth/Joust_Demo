using HurricaneVR.Framework.ControllerInput;
using MalbersAnimations.Controller;
using System.Collections;
using TMPro;
using UnityEngine;

public class JoustBehavior : MonoBehaviour
{
    public GameObject _startJoustText;
    public GameManager _gameManager;
    public MAnimal animal;
    public bool isJousting => _isJousting;
    public bool canJoust;
    public FadeBehavior fadeBehavior;
    public GameObject countdownTextObj;
    public GameObject tiltNumberObj;
    public GameObject totalScoreObj;
    public int totalScore;
    public int currentTilt;

    //private int _damageDealt;
    //private int _playerHealth;

    [SerializeField] private InJoustMenuBehavior _inJoustMenuBehavior;
    [SerializeField] private StartJoustArea _startJoustArea;

    private HorseBehavior _horseBehavior;
    //private GameObject _horse;
    private TextMeshProUGUI _countdownText;
    private TextMeshProUGUI _tiltNumberText;
    private TextMeshProUGUI _totalScoreText;
    private float _startJoustTimer = 0;
    private bool _hasScored = false;
    private bool _isJousting = false;

    private void Awake()
    {
        _horseBehavior = FindObjectOfType<HorseBehavior>();
        _startJoustText = GameObject.FindGameObjectWithTag("StartJoust");
        _startJoustText.SetActive(false);
        _countdownText = countdownTextObj.GetComponent<TextMeshProUGUI>();
        _tiltNumberText = tiltNumberObj.GetComponent<TextMeshProUGUI>();
        _totalScoreText = totalScoreObj.GetComponent<TextMeshProUGUI>();
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

            if (tag == "Enemy 1")
            {
                totalScore += 1;
            }
            else if (tag == "Enemy 2")
            {
                totalScore += 2;
            }
            _totalScoreText.text = totalScore.ToString();
        }
    } 

    public void handleTiltCount()
    {
        currentTilt = currentTilt < 3 ? currentTilt++ : 3;
        _tiltNumberText.text = "Tilt " + currentTilt.ToString() + "/3";
    }

    public IEnumerator StopTilt()
    {

        yield return new WaitForSeconds(2.5f);
        animal.LockMovement = true;
        yield return new WaitForSeconds(.5f);
        fadeBehavior.FadeOut();
        yield return new WaitForSeconds(1.5f);
        handleTiltCount();
        OpenJoustMenu();
        fadeBehavior.FadeIn();
    }

    public IEnumerator CountdownToJoust()
    {        
        int countdownValue = 3;

        while (countdownValue > 0)
        {
            _countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(1f);
            countdownValue--;
        }

        _countdownText.text = "Go!";
        _gameManager.UpdateGameState(GameState.Joust);
        yield return new WaitForSeconds(.5f);
        countdownTextObj.SetActive(false);
    }
}