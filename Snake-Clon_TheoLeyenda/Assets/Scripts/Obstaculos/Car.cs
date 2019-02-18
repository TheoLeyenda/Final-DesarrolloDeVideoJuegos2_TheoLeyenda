using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public float angleRotation;
    public float diley;
    private float auxDiley;
	void Start () {
        auxDiley = diley;
        diley = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}
    public void Movement()
    {
        transform.position = transform.position + transform.up * Time.deltaTime * speed;
        if(diley > 0)
        {
            diley = diley - Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "punto curva")
        {
            if (diley <= 0)
            {
                transform.RotateAround(transform.position, Vector3.back, angleRotation);
            }
            diley = auxDiley;
        }
    }
}
