using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadSnake : MonoBehaviour {

	//definimos las direcciones en las que se movera la bibora.
    enum Direcction
    {
        up,
        down,
        left,
        right
    }
    [HideInInspector]
    public static HeadSnake headSnake;
    //private int cantOriginalVaperParts;
    private Vector3 startPosition;
    [HideInInspector]
    public int life =3;
    private Direcction direcction;
    public float rangeTeleportFoodX;
    public float rangeTeleportFoodY;
    public GameObject vaperPartPrefab;
    public List<Transform> VaperParts;
    private List<Vector3> startPositionVaperParts;
    //tiempo en el que pasa un frame a otro frame (cuanto mas pequeño sea el numero de los frames mas dificil sera el juego)
    public float frameRate;
    //distancia en la que se mueve la serpiente. 
    public float step;
    private Vector3 lastPosition;

    private void Awake()
    {
        headSnake = this;
    }
    void Start () {
       
        DataStructure.auxiliaryDataStructure.SetPlayerValue();
        //cantOriginalVaperParts = VaperParts.Count;
        startPositionVaperParts = new List<Vector3>();
        startPosition = transform.position;
        for(int i = 0; i<VaperParts.Count; i++)
        {
            startPositionVaperParts.Add(VaperParts[i].transform.position);
        }
        //defino la distancia del jugador a base del tamaño de su collider
        if (step == 0)
        {
            step = GetComponent<BoxCollider2D>().size.x;
        }

        //Esta funcion invoca la funcion que este escrita en el primer parametro entre los intervalos del valor del segundo y tercer parametro 
        InvokeRepeating("Movement", frameRate, frameRate);
	}
    void Update()
    {
        CheckMove();
        CheckDead();
    }
    public void CheckDead()
    {
        if (life < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void MoveVaperPars()
    {
        for (int i = 0; i < VaperParts.Count; i++)
        {
            //temp guardara la posicion de la cola actual
            Vector3 temp = VaperParts[i].transform.position;
            //le asigno a la cola actual la ultima pocicion que toco la cabeza o el segmento previo que tiene la serpiente
            VaperParts[i].position = lastPosition;
            //y guardo la posicion de este segmento en lastPosition para que el segmento que le sigue a este pueda adquirir el lastPosition actualizado
            //con la posision de este segmento.
            lastPosition = temp;
        }
    }
    //Dependiendo de la tecla que precione el juegador defino la siguiente direcion a la que ira la serpiente
    public void CheckMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direcction = Direcction.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direcction = Direcction.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direcction = Direcction.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direcction = Direcction.down;
        }
    }
    //Muevo a la serpiente
    public void Movement()
    {
        //Verifico la direccion
        lastPosition = transform.position;
        Vector3 nextPosition = Vector3.zero;
        if (direcction == Direcction.up)
        {
            nextPosition = Vector3.up;
        }
        if (direcction == Direcction.down)
        {
            nextPosition = Vector3.down;
        }
        if (direcction == Direcction.left)
        {
            nextPosition = Vector3.left;
        }
        if (direcction == Direcction.right)
        {
            nextPosition = Vector3.right;
        }
        //-----------------------------
        //la serpiente ira a la siguiente posicion tomando en cuenta la distancia a la que se mueve la serpiente
        nextPosition = nextPosition * step;
        //Muevo a la serpiente
        transform.position = transform.position + nextPosition;
        MoveVaperPars();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "limite")
        {
            //cada vez que morimos volvemos a cargar la escena en la que se encuentra el jugador
            life--;
            DataStructure.auxiliaryDataStructure.playerData.life = life;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(collision.gameObject.tag == "comida")
        {
            // teletrasportamos la comida cada vez que la chocamos
            collision.transform.position = new Vector2(Random.Range(-rangeTeleportFoodX, rangeTeleportFoodX), Random.Range(-rangeTeleportFoodY, rangeTeleportFoodY));
            VaperParts.Add(Instantiate(vaperPartPrefab, VaperParts[VaperParts.Count - 1].transform.position, Quaternion.identity).transform);
        }
    }
}
