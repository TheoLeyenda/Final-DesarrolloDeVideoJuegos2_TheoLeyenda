using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject infinityLevelMenu;
    public GameObject continueGame;
    private void Start()
    {
        continueGame.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
        if(PlayerPrefs.GetInt("Guardado") == 1)
        {
            continueGame.SetActive(true);
        }
    }

    public void Continue()
    {
        DataStructure.auxiliaryDataStructure.nextLevel.level = PlayerPrefs.GetInt("Nivel");
        DataStructure.auxiliaryDataStructure.playerData.score = PlayerPrefs.GetInt("Puntaje");
        DataStructure.auxiliaryDataStructure.playerData.life = PlayerPrefs.GetInt("Vidas");
        DataStructure.auxiliaryDataStructure.playerData.x = PlayerPrefs.GetFloat("X");
        DataStructure.auxiliaryDataStructure.playerData.y = PlayerPrefs.GetFloat("Y");
        DataStructure.auxiliaryDataStructure.playerData.z = PlayerPrefs.GetFloat("Z");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void Play()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);

    }
    public void IslaSolitaria()
    {
        SceneManager.LoadScene("Isla Solitaria");
    }
    public void Laberinto()
    {
        SceneManager.LoadScene("Laberinto");
    }
    public void Clasico()
    {
        SceneManager.LoadScene("Clasico");
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
