using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructure : MonoBehaviour {

    // Use this for initialization
    // Use this for initialization
    public static DataStructure auxiliaryDataStructure;
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

    private float totalSeconds;
    private float totalMinutes;

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
        playerData.life = life;
        playerData.score = 0;
        nextLevel.level = 0;
    }
    public void AddTotalTime()
    {
        totalSeconds = totalSeconds + seconds;
        if(totalSeconds > 59)
        {
            totalMinutes++;
            totalSeconds = totalSeconds - 59;
        }
        totalMinutes = totalMinutes + minutes;
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
