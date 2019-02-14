using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public static GameManager InstanceGameManager;
    public int namberLevel;
    public int scoreRequired;
    [HideInInspector]
    public int score;
    public GameObject[] doors;
	void Start () {
        InstanceGameManager = this;
    }
	
	// Update is called once per frame
	void Update () {
        CheckLevel();

    }
    public void CheckLevel()
    {
        switch(namberLevel)
        {
            case 1:
                if(score >= scoreRequired)
                {
                    doors[0].GetComponent<SpriteRenderer>().color = Color.green;
                    doors[0].tag = "pasto";
                }
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
