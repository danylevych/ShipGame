using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


// +=========================================+
// |                                         |
// |   This script open the loading scene.   |
// |                                         |
// +=========================================+

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    [SerializeField] private Slider loading;
    [SerializeField] private GameObject loadingScreen;

    public static string PreviousScene { get; set; }    // Consist of information, which scene was the previous.


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // ========================== Load Scene ==========================
    public void LoadScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsynchronously(sceneName));
    }
    // ================================================================


    // ======================== Load Prev Scene =======================
    public void LoadPreviousScene()
    {
        if (PreviousScene != null)
        {
            Invoke(nameof(LoadPreviousSceneDelayed), 0.3f);
        }
    }

    private void LoadPreviousSceneDelayed()
    {
        SceneManager.LoadScene(PreviousScene);
    }
    // ================================================================


    IEnumerator LoadSceneAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        while (!operation.isDone)
        {
            loading.value = operation.progress;
            yield return null;
        }
    }
}
