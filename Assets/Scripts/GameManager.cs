using System;
using UnityEngine;

public enum GameState
{
    FreeRoam,
    MountedFreeRoam,
    Joust,
    Pause,
    Quit
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    public GameState State => _state;
    private GameState _state;
    [SerializeField] GameState _startState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateGameState(_startState);
    }

    public void UpdateGameState(GameState gameState)
    {
        //if (_state == gameState) { return; }
        _state = gameState;

        if (gameState == GameState.Quit)
        {
            HandleApplicationQuit();
        }

        OnGameStateChanged?.Invoke(gameState);
    }

    private void HandleApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}