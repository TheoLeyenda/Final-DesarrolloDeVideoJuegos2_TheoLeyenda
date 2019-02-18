using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour {

    // Use this for initialization
    public float timeActive;
    public float timeDisable;
    private float auxTimeActive;
    private float auxTimeDisable;
    public bool enterTimeActive;
    private bool enterTimeDisable;
	void Start () {
        auxTimeActive = timeActive;
        auxTimeDisable = timeDisable;
        if (enterTimeActive == false)
        {
            enterTimeDisable = true;
        }

	}
	
	// Update is called once per frame
	void Update () {
        CheckTrap();
        Debug.Log(gameObject.tag);
	}
    public void CheckTrap()
    {
        if(timeActive > 0 && enterTimeActive)
        {
            gameObject.tag = "limite";
            timeActive = timeActive - Time.deltaTime;
            timeDisable = 0;
        }
        if(timeActive <= 0 && enterTimeActive)
        {
            enterTimeDisable = true;
            enterTimeActive = false;
            timeDisable = auxTimeDisable;
        }
        if(timeDisable > 0 && enterTimeDisable)
        {
            gameObject.tag = "pasto";
            timeDisable = timeDisable - Time.deltaTime;
            timeActive = 0;
        }
        if(timeDisable <= 0 && enterTimeDisable)
        {
            enterTimeDisable = false;
            enterTimeActive = true;
            timeActive = auxTimeActive;
        }
    }
        
}
