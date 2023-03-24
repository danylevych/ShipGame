using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    [SerializeField] private Slider loading;
    [SerializeField] private GameObject loadingScreen;

    public static string PreviousScene { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LoadScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsynchronously(sceneName));
    }

    public void LoadPreviousScene()
    {
        if (PreviousScene != null)
        {
            loadingScreen.SetActive(true);
            StartCoroutine(LoadSceneAsynchronously(PreviousScene));
        }
    }

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
