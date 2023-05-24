using HurricaneVR.Framework.ControllerInput;
using MalbersAnimations.Controller;
using System.Collections;
using TMPro;
using UnityEngine;

public class JoustBehavior : MonoBehaviour
{
    public EnemyBehavior EnemyBehavior;
    public GameObject _startJoustText;
    public GameManager _gameManager;
    public LanceSpawnerBehavior _lanceSpawnerBehavior;
    public MAnimal animal;
    public bool isJousting => _isJousting;
    public bool canJoust;
    public FadeBehavior fadeBehavior;
    public GameObject countdownTextObj;
    public GameObject tiltNumberObj;
    public GameObject totalScoreObj;
    public GameObject finalScoreObj;
    public int totalScore;
    private int currentTilt = 1;

    //private int _damageDealt;
    //private int _playerHealth;

    [SerializeField] private InJoustMenuBehavior _inJoustMenuBehavior;
    //public StartJoustArea _startJoustArea;

    private HorseBehavior _horseBehavior;
    //private GameObject _horse;
    private TextMeshProUGUI _countdownText;
    private TextMeshProUGUI _tiltNumberText;
    private TextMeshProUGUI _totalScoreText;
    private TextMeshProUGUI _finalScoreText;
    private float _startJoustTimer = 0;
    private bool _hasScored = false;
    private bool _isJousting = false;
    private GameObject[] _lances;
    //public bool _canJoust = false;

    private void Awake()
    {
        _horseBehavior = FindObjectOfType<HorseBehavior>();
        _startJoustText = GameObject.FindGameObjectWithTag("StartJoust");
        _startJoustText.SetActive(false);
        _countdownText = countdownTextObj.GetComponent<TextMeshProUGUI>();
        _tiltNumberText = tiltNumberObj.GetComponent<TextMeshProUGUI>();
        _totalScoreText = totalScoreObj.GetComponent<TextMeshProUGUI>();
        _finalScoreText = finalScoreObj.GetComponent<TextMeshProUGUI>();
        //canJoust = StartJoustArea.canJoust;
        //_horse = GameObject.FindGameObjectWithTag("Animal");
    }

    private void Update()
    {        
        if(StartJoustArea.canJoust && _horseBehavior.IsMounted && !_isJousting)
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
        _inJoustMenuBehavior.ToggleMenu(true);
    }
    
    public void OpenJoustMenuDone()
    {
        _gameManager.UpdateGameState(GameState.Pause);
        _horseBehavior.UpdateJoustRotation();
        _inJoustMenuBehavior.ToggleMenuDone(true);
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
            _totalScoreText.text = "Score: " + totalScore.ToString();
        }
    } 

    public void EndTiltWithoutScore()
    {
        if (EndJoustArea.endJoust && !_hasScored)
        {
            _lances = GameObject.FindGameObjectsWithTag("Lance");
            _lanceSpawnerBehavior.clearDebris(_lances);
            _totalScoreText.text = "Score: " + totalScore.ToString();
            StartCoroutine(StopTilt());
        }
    }

    public void handleTiltCount()
    {
        currentTilt += 1;
        _tiltNumberText.text = "Tilt " + currentTilt.ToString() + "/3";
    }

    private void handleJoustDone()
    {
        _finalScoreText.text = "Final Score: " + totalScore.ToString();
        totalScore = 0;
        _totalScoreText.text = "Score: " + totalScore.ToString();
        currentTilt = 1;
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
        if(currentTilt > 3)
        {
            handleJoustDone();
            OpenJoustMenuDone();
        }
        else
        {
            OpenJoustMenu();
        }
        fadeBehavior.FadeIn();
        EnemyBehavior.ResetJoustPosition();
        _hasScored = false;
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