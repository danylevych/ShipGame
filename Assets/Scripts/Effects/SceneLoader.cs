using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingScreen;
    //[SerializeField]
    //private GameObject whichIsBack;
    [SerializeField]
    private Slider loading;

    public void LoadScene(string sceneName)
    {
        //whichIsBack.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsynchronously(sceneName));
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
