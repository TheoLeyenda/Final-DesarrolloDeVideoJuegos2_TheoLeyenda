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
    //dependiendo de que valor tome esta variable es el puntaje que se le sumara al jugador cuando agarre un pickup de comida
    private int addScore = 10;
    public GameObject[] lifesSprites;
    [HideInInspector]
    public int score;
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public float cameraSpeed;
    public bool originalMove;
    public GameObject cameraPlayer;
    [HideInInspector]
    public static HeadSnake headSnake;
    //private int cantOriginalVaperParts;
    //private Vector3 startPosition;
    [HideInInspector]
    public int life =3;
    private Direcction direcction;
    public float rangeTeleportFoodX;
    public float rangeTeleportFoodY;
    public GameObject vaperPartPrefab;
    public List<Transform> VaperParts;
    private List<Vector3> startPositionVaperParts;
    //tiempo en el que pasa un frame a otro frame (cuanto mas pequeño sea el numero de los frames mas dificil sera el juego puesto que la vivora se movera mas rapido)
    public float FPS;
    //distancia en la que se mueve la serpiente. 
    public float distanceOfMovement;
    private Vector3 lastPosition;

    private void Awake()
    {
        headSnake = this;
    }
    void Start () {
       
        DataStructure.auxiliaryDataStructure.SetPlayerValue();
        for (int i = 0; i < lifesSprites.Length; i++)
        {
            lifesSprites[i].SetActive(false);
        }
        for (int i = 0; i< life; i++)
        {
            lifesSprites[i].SetActive(true);
        }
        InitialMove();
        //cantOriginalVaperParts = VaperParts.Count;
        startPositionVaperParts = new List<Vector3>();
        //startPosition = transform.position;
        for(int i = 0; i<VaperParts.Count; i++)
        {
            startPositionVaperParts.Add(VaperParts[i].transform.position);
        }
        //defino la distancia del jugador a base del tamaño de su collider
        if (distanceOfMovement == 0)
        {
            distanceOfMovement = GetComponent<BoxCollider2D>().size.x;
        }

        //Esta funcion invoca la funcion que este escrita en el primer parametro entre los intervalos del valor del segundo y tercer parametro 
        InvokeRepeating("Movement", FPS, FPS);
        if (originalMove)
        {
            InvokeRepeating("UpdateCameraPlayerPosition", FPS, FPS);
        }
        score = DataStructure.auxiliaryDataStructure.playerData.score;
    }
    void Update()
    {
        CheckMove();
        CheckDead();
        
    }
    public void InitialMove()
    {
        if (up)
        {
            direcction = Direcction.up;
        }
        else if(down)
        {
            direcction = Direcction.down;
        }
        else if(left)
        {
            direcction = Direcction.left;
        }
        else if(right)
        {
            direcction = Direcction.right;
        }
        else if(!up && !down && !left && !right)
        {
            direcction = Direcction.up;
        }
    }
    public void UpdateCameraPlayerPosition()
    {
        cameraPlayer.transform.position = new Vector3(transform.position.x,transform.position.y, cameraPlayer.transform.position.z);
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
        nextPosition = nextPosition * distanceOfMovement;
        //Muevo a la serpiente
        transform.position = transform.position + nextPosition;
        if (!originalMove)
        {
            cameraPlayer.transform.position = cameraPlayer.transform.position + nextPosition * Time.deltaTime * (distanceOfMovement+cameraSpeed);
        }
        MoveVaperPars();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "comida")
        {
            score = score + addScore;
            DataStructure.auxiliaryDataStructure.playerData.score = DataStructure.auxiliaryDataStructure.playerData.score + addScore;
            GameManager.InstanceGameManager.textScore.text = "Puntaje: " +DataStructure.auxiliaryDataStructure.playerData.score;
            GameManager.InstanceGameManager.score++;
            //Agregamos una cola mas a cola para que la serpiente se alargue
            VaperParts.Add(Instantiate(vaperPartPrefab, VaperParts[VaperParts.Count - 1].transform.position, Quaternion.identity).transform);
            // teletrasportamos la comida cada vez que la chocamos
            collision.transform.position = new Vector2(Random.Range(-rangeTeleportFoodX, rangeTeleportFoodX), Random.Range(-rangeTeleportFoodY, rangeTeleportFoodY));

        }
        if (collision.gameObject.tag == "comida destruible")
        {
            score = score + addScore;
            DataStructure.auxiliaryDataStructure.playerData.score = DataStructure.auxiliaryDataStructure.playerData.score + addScore;
            GameManager.InstanceGameManager.textScore.text = "Puntaje: " + DataStructure.auxiliaryDataStructure.playerData.score;
            GameManager.InstanceGameManager.score++;
            VaperParts.Add(Instantiate(vaperPartPrefab, VaperParts[VaperParts.Count - 1].transform.position, Quaternion.identity).transform);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "limite")
        {
            //cada vez que morimos volvemos a cargar la escena en la que se encuentra el jugador
            life--;
            DataStructure.auxiliaryDataStructure.playerData.life = life;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "puerta")
        {
            DataStructure.auxiliaryDataStructure.playerData.score = DataStructure.auxiliaryDataStructure.playerData.score + 50;
            SceneManager.LoadScene("Pantalla de carga");
        }
        if(collision.gameObject.tag == "puerta comun")
        {
            DataStructure.auxiliaryDataStructure.playerData.score = DataStructure.auxiliaryDataStructure.playerData.score + 50;
        }
        if (collision.gameObject.tag == "puerta final")
        {
            SceneManager.LoadScene("Juego Completado");
        }
    }
}
