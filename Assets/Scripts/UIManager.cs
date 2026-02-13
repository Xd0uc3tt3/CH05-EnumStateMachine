using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject OptionsUI;
    [SerializeField] private GameObject GameOverUI;

    public void ShowMainMenuUI()
    {
        HideAllUI();

        MainMenuUI.SetActive(true);
    }

    public void ShowGameplayUI()
    {
        HideAllUI();

        gameplayUI.SetActive(true);
    }

    public void ShowPausedUI()
    {
        HideAllUI();

        pausedUI.SetActive(true);
    }

    public void ShowOptionsUI()
    {
        HideAllUI();
        OptionsUI.SetActive(true);
    }

    public void HideAllUI()
    {
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        MainMenuUI.SetActive(false);
        OptionsUI.SetActive(false);
    }

}

