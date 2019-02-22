using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text textHaighScore;
    public Text textScore;
    public Text textTime;
    public Text textLife;
    public bool notShowData;

    private void Start()
    {
        if (notShowData == false)
        {
            if (DataStructure.auxiliaryDataStructure.playerData.score > DataStructure.auxiliaryDataStructure.haighScore)
            {
                DataStructure.auxiliaryDataStructure.haighScore = DataStructure.auxiliaryDataStructure.playerData.score;
            }
            textHaighScore.text = "Puntuacion Maxima: " + DataStructure.auxiliaryDataStructure.haighScore;
            textScore.text = "Tu Puntuacion: " + DataStructure.auxiliaryDataStructure.playerData.score;
            if (DataStructure.auxiliaryDataStructure.totalSeconds >= 10)
            {
                textTime.text = "Tiempo Jugado: " + (int)DataStructure.auxiliaryDataStructure.totalMinutes + ":" + (int)DataStructure.auxiliaryDataStructure.totalSeconds;
            }
            if (DataStructure.auxiliaryDataStructure.totalSeconds < 10)
            {
                textTime.text = "Tiempo Jugado: " + (int)DataStructure.auxiliaryDataStructure.totalMinutes + ":0" + (int)DataStructure.auxiliaryDataStructure.totalSeconds;
            }
            if (DataStructure.auxiliaryDataStructure.playerData.life >= 0)
            {
                textLife.text = "Vidas Restantes: " + DataStructure.auxiliaryDataStructure.playerData.life;
            }
            if (DataStructure.auxiliaryDataStructure.playerData.life < 0)
            {
                textLife.text = "Vidas Restantes: 0";
            }
            if (SceneManager.GetActiveScene().name == "GameOver")
            {
                textLife.text = "Vidas Restantes: 0";
            }
        }

    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        DataStructure.auxiliaryDataStructure.playerData.life = DataStructure.auxiliaryDataStructure.life;
        DataStructure.auxiliaryDataStructure.playerData.score = 0;
        DataStructure.auxiliaryDataStructure.seconds = 0;
        DataStructure.auxiliaryDataStructure.minutes = 0;
        DataStructure.auxiliaryDataStructure.totalSeconds = 0;
        DataStructure.auxiliaryDataStructure.totalMinutes = 0;
        DataStructure.auxiliaryDataStructure.minutesInLevel = 0;
        DataStructure.auxiliaryDataStructure.secondsInLevel = 0;
        DataStructure.auxiliaryDataStructure.nextLevel.level = 0;
        SceneManager.LoadScene("SplashScreen");
    }
}
