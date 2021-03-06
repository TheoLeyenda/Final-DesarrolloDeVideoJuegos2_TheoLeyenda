﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowDataLevelComplete : MonoBehaviour {

    // Use this for initialization
    public Text textScore;
    public Text textTime;
    public Text textLifes;
    void Start() {
        if (PlayerPrefs.GetInt("Guardado") == 1)
        {
            DataStructure.auxiliaryDataStructure.nextLevel.level++;
        }
        textScore.text = "Puntaje: "+DataStructure.auxiliaryDataStructure.playerData.score;
        if(DataStructure.auxiliaryDataStructure.secondsInLevel >= 10)
        {
            textTime.text = "Tiempo: " + (int)DataStructure.auxiliaryDataStructure.minutesInLevel + ":" + (int)DataStructure.auxiliaryDataStructure.secondsInLevel;
        }
        if(DataStructure.auxiliaryDataStructure.secondsInLevel < 10)
        {
            textTime.text = "Tiempo: " + (int)DataStructure.auxiliaryDataStructure.minutesInLevel + ":0" + (int)DataStructure.auxiliaryDataStructure.secondsInLevel;
        }
        textLifes.text = "Vidas Restantes: " + DataStructure.auxiliaryDataStructure.playerData.life;
	}
    public void NextLevel()
    {
        SceneManager.LoadScene("Pantalla de carga");
    }
}
