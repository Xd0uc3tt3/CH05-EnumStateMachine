using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Gameplay,
        Pause,
        Settings,
        GameOver
    }

    public GameState CurrentState { get; private set; }
}
