using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject[] colliderPhase1;
    public GameObject[] colliderPhase2;
    public GameObject[] colliderPhase3;
    public GameObject[] colliderPhase4;
    public GameObject[] colliderPhase5;
    [HideInInspector]
    public int score;
    public GameObject[] doors;
	void Start () {
        id = 0;
        phaseActuality = 1;
        InstanceGameManager = this;
        for (int i = 0; i < scoreRequired; i++)
        {
            Instantiate(food, Vector3.zero, Quaternion.identity);
        }
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
                    doors[id].GetComponent<SpriteRenderer>().color = Color.green;
                    doors[id].tag = "pasto";
                }
                break;
            case 2:
                if (score >= scoreRequired)
                {
                    doors[id].GetComponent<SpriteRenderer>().color = Color.green;
                    doors[id].tag = "pasto";
                }
                break;
            case 3:
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
                        doors[id].tag = "pasto";
                        id++;
                        
                        if (id > 0)
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
