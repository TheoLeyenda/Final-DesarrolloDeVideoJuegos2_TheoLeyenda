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
    //public Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator.enabled = false;
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
            //animator.enabled = false;
            spriteRenderer.enabled = false;
        }
        if(timeDisable > 0 && enterTimeDisable)
        {
            
            gameObject.tag = "pasto";
            timeDisable = timeDisable - Time.deltaTime;
            timeActive = 0;
        }
        if(timeDisable <= 0 && enterTimeDisable)
        {
            //animator.enabled = true;
            spriteRenderer.enabled = true;
            enterTimeDisable = false;
            enterTimeActive = true;
            timeActive = auxTimeActive;
        }
    }
        
}
