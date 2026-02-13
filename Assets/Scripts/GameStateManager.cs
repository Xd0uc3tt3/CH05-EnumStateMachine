using UnityEngine;

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

    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;



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
                uiManager.ShowMainMenuUI();
                break;

            case GameState.Gameplay:
                Debug.Log("GameState Changed to GamePlay");
                uiManager.ShowGameplayUI();
                break;

            case GameState.Paused:
                Debug.Log("GameState Changed to Paused");
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


}
