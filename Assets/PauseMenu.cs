using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private GameObject optionsScene;
    [SerializeField] private GameObject background;


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

    public void Resume()
    {
        pauseMenu.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1f;
        isPauseMenuActive = false;
    }

    public void Pause()
    {
        background.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPauseMenuActive = true;
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsScene.SetActive(true);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        loadingScene.SetActive(true);
        SceneLoader.instance.LoadScene("MainMenu");
    }

    public void Back()
    {
        optionsScene.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
