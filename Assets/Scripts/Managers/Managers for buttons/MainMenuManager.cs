using UnityEngine;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject exitUI;
    [SerializeField] private GameObject loadingScene;

    public void Play()
    {
        loadingScene.SetActive(true);
        SceneLoader.instance.LoadScene("Game");
    }

    public void Option()
    {
        loadingScene.SetActive(true);
        SceneLoader.PreviousScene = "MainMenu";
        SceneLoader.instance.LoadScene("Option");
    }

    public void Exit()
    {
        exitUI.SetActive(true);
    }

    public void PressedYes()
    {
        Application.Quit();
    }

    public void PressedNo()
    {
        exitUI.SetActive(false);
    }
}