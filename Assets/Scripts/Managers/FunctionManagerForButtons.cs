using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionManagerForButtons : MonoBehaviour
{
    public void EndGameBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainPlay()
    {
        SceneManager.LoadScene("Game");
    }


    public void MainOption()
    {
        // SceneManager.LoadScene("Game");
    }

    public void MainExit()
    {
        Application.Quit();
    }
}