using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject creditsMenu;
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
    public void BackMenu()
    {
        creditsMenu.SetActive(false);
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
