using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject infinityLevelMenu;
    private void Start()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);

    }
    public void InfinityLevelMenu()
    {
        mainMenu.SetActive(false);
        infinityLevelMenu.SetActive(true);
    }
    public void BackMenu()
    {
        creditsMenu.SetActive(false);
        infinityLevelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
    }
}
