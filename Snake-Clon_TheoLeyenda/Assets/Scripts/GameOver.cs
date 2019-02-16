using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void BackToMainMenu()
    {
        DataStructure.auxiliaryDataStructure.playerData.life = DataStructure.auxiliaryDataStructure.life;
        DataStructure.auxiliaryDataStructure.playerData.score = 0;
        DataStructure.auxiliaryDataStructure.seconds = 0;
        DataStructure.auxiliaryDataStructure.minutes = 0;
        DataStructure.auxiliaryDataStructure.minutesInLevel = 0;
        DataStructure.auxiliaryDataStructure.secondsInLevel = 0;
        DataStructure.auxiliaryDataStructure.nextLevel.level = 0;
        SceneManager.LoadScene("SplashScreen");
    }
}
