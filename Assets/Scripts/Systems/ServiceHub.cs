using UnityEngine;

[DefaultExecutionOrder(-100)]
public class ServiceHub : MonoBehaviour
{
    // SERVICE HUB PATTERN
    // Provides a centralized registry for game-wide systems (UI, Player, Audio).
    // This eliminates the need for expensive 'Find' calls and reduces 
    // tight coupling by giving scripts a single point of contact for dependencies.

    // Note: This does create a "God Object" which can have downsides if overused.
    // But is a simple useful pattern for beginner programmers for small to mid-sized projects.

    // The static instance that makes this globally accessible

    public static ServiceHub Instance { get; private set; }

    public GameStateManager GameStateManager;
    public UIManager UIManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



}
