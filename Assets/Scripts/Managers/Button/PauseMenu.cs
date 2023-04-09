using UnityEngine;


// +=========================================+
// |                                         |
// | This script for the buttons in PauseMenu|
// |           in the Game scene.            |
// |                                         |
// +=========================================+

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private GameObject optionsScene;
    [SerializeField] private GameObject background;
    [SerializeField] private AudioSource buttonClick;
 
    public static bool isPauseMenuActive = false;


    void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseMenuActive)
            { 
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    // ========================== Resume Button =============================
    public void Resume()
    {
        buttonClick.Play();
        pauseMenu.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1f;
        isPauseMenuActive = false;
    }
    // =====================================================================


    // =========================== Pause Button =============================
    public void Pause()
    {
        buttonClick.Play();
        background.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPauseMenuActive = true;
    }
    // =====================================================================


    // ========================== Option Button ============================
    public void Options()
    {
        buttonClick.Play();
        pauseMenu.SetActive(false);
        optionsScene.SetActive(true);
    }
    // =====================================================================


    // =========================== Menu Button =============================
    public void Menu()
    {
        buttonClick.Play();
        Time.timeScale = 1f;
        Invoke(nameof(MenuDelayed), 0.3f);
    }

    private void MenuDelayed()
    {
        loadingScene.SetActive(true);
        SceneLoader.instance.LoadScene("MainMenu");
    }
    // =====================================================================


    // =========================== Back Button =============================
    public void Back()
    {
        buttonClick.Play();
        optionsScene.SetActive(false);
        pauseMenu.SetActive(true);
    }
    // =====================================================================
}
