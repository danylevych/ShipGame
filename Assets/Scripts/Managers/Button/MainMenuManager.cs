using UnityEngine;


// +=========================================+
// |                                         |
// | This script for the buttons in MainMenu.|
// |                                         |
// +=========================================+

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject exitUI;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private AudioSource buttonClick;

    // This is a variable, that counting the user clicks and open Easter Egg.
    private static int clickCounter = 0;


    private void Awake()
    {
        clickCounter = PlayerPrefs.GetInt("CountClicks", 0);
    }


    // ========================== Play Button ==============+=============
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
    // ===================================================================


    // ========================= Option Button ==========================
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
    // ===================================================================


    // ========================== Exit Button ============================
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
    // ===================================================================


    // ======================== EasterEgg Button =========================
    public void EasterEgg()
    {
        buttonClick.Play();

        if (clickCounter == 10)
        {
            PlayerPrefs.SetInt("CountClicks", 10);
            loadingScene.SetActive(true);
            SceneLoader.PreviousScene = "MainMenu";
            SceneLoader.instance.LoadScene("Info");
        }
        else
        {
            clickCounter++;
        }
    }
    // ===================================================================
}