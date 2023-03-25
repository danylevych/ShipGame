using UnityEngine;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject exitUI;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private AudioSource buttonClick;

    public void Play()
    {
        buttonClick.Play();
        Invoke(nameof(PlayPriv), 0.3f);
    }

    private void PlayPriv()
    {
        loadingScene.SetActive(true);
        SceneLoader.instance.LoadScene("Game");
    }


    public void Option()
    {
        buttonClick.Play();
        Invoke(nameof(OptionPriv), 0.3f);
    }

    private void OptionPriv()
    {
        loadingScene.SetActive(true);
        SceneLoader.PreviousScene = "MainMenu";
        SceneLoader.instance.LoadScene("Option");
    }

    public void Exit()
    {
        buttonClick.Play();
        exitUI.SetActive(true);
    }

    public void PressedYes()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void PressedNo()
    {
        buttonClick.Play();
        exitUI.SetActive(false);
    }
}