using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataStructure : MonoBehaviour {

    // Use this for initialization
    // Use this for initialization
    public static DataStructure auxiliaryDataStructure;
    public float haighScore;
    public int life;
    [HideInInspector]
    public float secondsInLevel;
    [HideInInspector]
    public float minutesInLevel;
    [HideInInspector]
    public PlayerData playerData;
    [HideInInspector]
    public NextLevel nextLevel;
    [HideInInspector]
    public float seconds;
    [HideInInspector]
    public float minutes;
    [HideInInspector]
    public float totalSeconds;
    [HideInInspector]
    public float totalMinutes;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (auxiliaryDataStructure == null)
        {
            auxiliaryDataStructure = this;
        }
        else if (auxiliaryDataStructure != null)
        {
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        haighScore = 0;
        playerData.life = life;
        playerData.score = 0;
        nextLevel.level = 0;
    }
    private void Update()
    {
        AddTotalTime();
    }
    public void AddTotalTime()
    {
        if (totalSeconds < 60)
        {
            totalSeconds = totalSeconds + Time.deltaTime;
        }
        if(totalSeconds >= 60)
        {
            totalMinutes++;
            totalSeconds = 0; 
        }
    }
    public struct NextLevel
    {
        public int level;
    }
    public struct PlayerData
    {
        public int life;
        public int score;
    }
    public void SetPlayerData()
    {
        playerData.life = HeadSnake.headSnake.life;
        playerData.score = HeadSnake.headSnake.score;
    }
    public void SetPlayerValue()
    {
        HeadSnake.headSnake.life = playerData.life;
        HeadSnake.headSnake.score = playerData.score;
    }
}
