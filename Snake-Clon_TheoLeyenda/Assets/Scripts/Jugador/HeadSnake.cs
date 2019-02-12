using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSnake : MonoBehaviour {

	//definimos las direcciones en las que se movera la bibora.
    enum Direcction
    {
        up,
        down,
        left,
        right
    }
    private Direcction direcction;

    //tiempo en el que pasa un frame a otro frame (cuanto mas pequeño sea el numero de los frames mas dificil sera el juego)
    public float frameRate;
    //distancia en la que se mueve la serpiente. 
    private float step;

    //Dependiendo de la tecla que precione el juegador defino la siguiente direcion a la que ira la serpiente
    public void CheckMove()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direcction = Direcction.left;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            direcction = Direcction.right;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            direcction = Direcction.up;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            direcction = Direcction.down;
        }
    }
    //Muevo a la serpiente
    public void Movement()
    {
        //Verifico la direccion
        Vector3 nextPosition = Vector3.zero;
        if(direcction == Direcction.up)
        {
            nextPosition = Vector3.up;
        }
        if(direcction == Direcction.down)
        {
            nextPosition = Vector3.down;
        }
        if(direcction == Direcction.left)
        {
            nextPosition = Vector3.left;
        }
        if(direcction == Direcction.right)
        {
            nextPosition = Vector3.right;
        }
        //-----------------------------
        //la serpiente ira a la siguiente posicion tomando en cuenta la distancia a la que se mueve la serpiente
        nextPosition = nextPosition * step;
        //Muevo a la serpiente
        transform.position = transform.position + nextPosition;
    }
	void Start () {
        //defino la distancia del jugador a base del tamaño de su collider
        step = GetComponent<BoxCollider2D>().size.x;

        //Esta funcion invoca la funcion que este escrita en el primer parametro entre los intervalos del valor del segundo y tercer parametro 
        InvokeRepeating("Movement", frameRate, frameRate);
	}
	
	// Update is called once per frame
	void Update () {
        CheckMove();
	}
}
