using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    private int id;
    public GameObject food;
    public static GameManager InstanceGameManager;
    public int namberLevel;
    public int scoreRequired;
    public int[] scoresRequireds;
    public BoxCollider2D[] collidersGameManager;
    private int phaseActuality;
    public GameObject meta;
    public GameObject[] foodFinalPhase;
    public GameObject[] colliderPhase1;
    public GameObject[] colliderPhase2;
    public GameObject[] colliderPhase3;
    public GameObject[] colliderPhase4;
    public GameObject[] colliderPhase5;
    [HideInInspector]
    public int score;
    public GameObject[] doors;
    [HideInInspector]
    public float minutes;
    [HideInInspector]
    public float seconds;
    public Text textScore;
    public Text textTime;
    public Text textActualityLevel;
    public Text textHaighScore;
    public bool InfinityLevel;
	void Start () {
        id = 0;
        seconds = 0;
        minutes = 0;
        phaseActuality = 1;
        InstanceGameManager = this;
        for (int i = 0; i < scoreRequired; i++)
        {
            Instantiate(food, Vector3.zero, Quaternion.identity);
        }
        textScore.text = "Puntaje: " + DataStructure.auxiliaryDataStructure.playerData.score;
        textTime.text = "Tiempo: " + (int)minutes + ":" + "0" + (int)seconds;
        textActualityLevel.text = "Nivel " + DataStructure.auxiliaryDataStructure.nextLevel.level;
        textHaighScore.text = "Puntuacion Maxima: " + DataStructure.auxiliaryDataStructure.haighScore;
        textHaighScore.gameObject.SetActive(false);
        if(DataStructure.auxiliaryDataStructure.haighScore > 0)
        {
            textHaighScore.gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (InfinityLevel == false)
        {
            CheckLevel();
        }
        TimeOnLevel();
    }
    public void TimeOnLevel()
    {
        if(seconds < 60)
        {
            seconds = seconds + Time.deltaTime;
            DataStructure.auxiliaryDataStructure.secondsInLevel = seconds;
        }
        if(seconds >= 60)
        {
            minutes++;
            seconds = 0;
            DataStructure.auxiliaryDataStructure.secondsInLevel = seconds;
            DataStructure.auxiliaryDataStructure.minutesInLevel = minutes;
        }
        if (seconds < 10)
        {
            textTime.text = "Tiempo: " + (int)minutes + ":" + "0" + (int)seconds;
        }
        if(seconds >= 10)
        {
            textTime.text = "Tiempo: " + (int)minutes + ":" + (int)seconds;
        }
    }
    public void CheckLevel()
    {
        switch(namberLevel)
        {
            case 1:
                if(score >= scoreRequired)
                {
                    doors[id].GetComponent<SpriteRenderer>().color = Color.green;
                    doors[id].tag = "puerta";
                }
                break;
            case 2:
                if (score >= scoreRequired)
                {
                    doors[id].GetComponent<SpriteRenderer>().color = Color.green;
                    doors[id].tag = "puerta";
                }
                break;
            case 3:
                int cant = 0;
                for (int i = 0; i < foodFinalPhase.Length; i++)
                {
                    if (foodFinalPhase[i].activeSelf == false)
                    {
                        cant++;
                    }
                }
                if (cant >= foodFinalPhase.Length)
                {
                    meta.GetComponent<SpriteRenderer>().color = Color.green;
                    meta.tag = "puerta final";
                }
                if (id < scoresRequireds.Length)
                {
                    if (score >= scoresRequireds[id])
                    {
                        phaseActuality++;
                        switch (phaseActuality)
                        {
                            case 1:
                                for(int i = 0; i< colliderPhase1.Length; i++)
                                {
                                    colliderPhase1[i].tag = "pasto";
                                }
                                for(int i = 0; i<colliderPhase2.Length; i++)
                                {
                                    colliderPhase2[i].tag = "rompe comida";
                                }
                                for(int i = 0; i< colliderPhase3.Length; i++)
                                {
                                    colliderPhase3[i].tag = "rompe comida";
                                }
                                for(int i = 0; i< colliderPhase4.Length; i++)
                                {
                                    colliderPhase4[i].tag = "rompe comida";
                                }
                                for(int i = 0; i< colliderPhase5.Length; i++)
                                {
                                    colliderPhase5[i].tag = "rompe comida";
                                }
                                break;
                            case 2:
                                for (int i = 0; i < colliderPhase1.Length; i++)
                                {
                                    colliderPhase1[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase2.Length; i++)
                                {
                                    colliderPhase2[i].tag = "pasto";
                                }
                                for (int i = 0; i < colliderPhase3.Length; i++)
                                {
                                    colliderPhase3[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase4.Length; i++)
                                {
                                    colliderPhase4[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase5.Length; i++)
                                {
                                    colliderPhase5[i].tag = "rompe comida";
                                }
                                break;
                            case 3:
                                for (int i = 0; i < colliderPhase1.Length; i++)
                                {
                                    colliderPhase1[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase2.Length; i++)
                                {
                                    colliderPhase2[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase3.Length; i++)
                                {
                                    colliderPhase3[i].tag = "pasto";
                                }
                                for (int i = 0; i < colliderPhase4.Length; i++)
                                {
                                    colliderPhase4[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase5.Length; i++)
                                {
                                    colliderPhase5[i].tag = "rompe comida";
                                }
                                break;
                            case 4:
                                for (int i = 0; i < colliderPhase1.Length; i++)
                                {
                                    colliderPhase1[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase2.Length; i++)
                                {
                                    colliderPhase2[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase3.Length; i++)
                                {
                                    colliderPhase3[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase4.Length; i++)
                                {
                                    colliderPhase4[i].tag = "pasto";
                                }
                                for (int i = 0; i < colliderPhase5.Length; i++)
                                {
                                    colliderPhase5[i].tag = "rompe comida";
                                }
                                break;
                            case 5:
                                for (int i = 0; i < colliderPhase1.Length; i++)
                                {
                                    colliderPhase1[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase2.Length; i++)
                                {
                                    colliderPhase2[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase3.Length; i++)
                                {
                                    colliderPhase3[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase4.Length; i++)
                                {
                                    colliderPhase4[i].tag = "rompe comida";
                                }
                                for (int i = 0; i < colliderPhase5.Length; i++)
                                {
                                    colliderPhase5[i].tag = "pasto";
                                }
                                break;
                        }
                        
                        doors[id].GetComponent<SpriteRenderer>().color = Color.green;
                        doors[id].tag = "puerta comun";

                        
                        if (id > 0 && id < scoresRequireds.Length-1)
                        {
                            for (int i = 0; i < (scoresRequireds[id] - scoresRequireds[id - 1]); i++)
                            {
                                Instantiate(food, Vector3.zero, Quaternion.identity);
                            }
                        }
                        if (id == 0)
                        {
                            for (int i = 0; i < scoresRequireds[id]; i++)
                            {
                                Instantiate(food, Vector3.zero, Quaternion.identity);
                            }
                        }
                        id++;
                    }
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (id >= doors.Length)
            {
                doors[doors.Length-1].GetComponent<SpriteRenderer>().color = Color.red;
                doors[doors.Length - 1].tag = "limite";
            }
            else
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[id - 1].GetComponent<SpriteRenderer>().color = Color.red;
                    doors[id - 1].tag = "limite";
                }
                collidersGameManager[id - 1].enabled = false;
            }
        }
    }
}
