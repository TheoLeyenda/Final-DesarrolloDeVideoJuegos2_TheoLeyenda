using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public GameObject pauseMenu;
    public GameObject UI_Player;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Nivel",DataStructure.auxiliaryDataStructure.nextLevel.level);
        PlayerPrefs.SetInt("Puntaje", DataStructure.auxiliaryDataStructure.playerData.score);
        PlayerPrefs.SetInt("Vidas", DataStructure.auxiliaryDataStructure.life);
        PlayerPrefs.SetFloat("X", HeadSnake.headSnake.transform.position.x);
        PlayerPrefs.SetFloat("Y", HeadSnake.headSnake.transform.position.y);
        PlayerPrefs.SetFloat("Z", HeadSnake.headSnake.transform.position.z);
        PlayerPrefs.SetInt("Direcion", (int)HeadSnake.headSnake.GetDirection());
        PlayerPrefs.SetInt("Guardado", 1);
        PlayerPrefs.SetInt("Primera", 1);
    }
        
}
