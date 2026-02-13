using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused

}

public class GameStateManager : MonoBehaviour
{

    private UIManager uiManager;
    private PlayerInputActions inputActions;

    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;


    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Pause.performed += OnPausePressed;
    }

    private void OnDisable()
    {
        inputActions.Player.Pause.performed -= OnPausePressed;
        inputActions.Disable();
    }

    private void Start()
    {
        uiManager = ServiceHub.Instance.UIManager;
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState)
        {
            return;
        }

        previousState = currentState;
        currentState = newState;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        switch (newState)
        {
            case GameState.Init:
                Debug.Log("GameState Changed to Init");
                SetState(GameState.MainMenu);
                break;

            case GameState.MainMenu:
                Debug.Log("GameState Changed to MainMenu");
                Time.timeScale = 1f;
                uiManager.ShowMainMenuUI();
                break;

            case GameState.Gameplay:
                Debug.Log("GameState Changed to GamePlay");
                Time.timeScale = 1f;
                uiManager.ShowGameplayUI();
                break;

            case GameState.Paused:
                Debug.Log("GameState Changed to Paused");
                Time.timeScale = 0f;
                uiManager.ShowPausedUI();
                break;

            default:
                break;


        }
    }

    public void GoToGameplay()
    {
        SetState(GameState.Gameplay);
    }



    private void OnPausePressed(InputAction.CallbackContext context)
    {
        Debug.Log("Pause pressed!");
        TogglePause();
    }

    public void TogglePause()
    {
        if (currentState == GameState.Gameplay)
        {
            SetState(GameState.Paused);
        }
        else if (currentState == GameState.Paused)
        {
            SetState(GameState.Gameplay);
        }
    }


}
