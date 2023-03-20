using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject exitUI;


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