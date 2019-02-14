using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "comida" || collision.tag == "comida destruible")
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.transform.position = new Vector2(Random.Range(-HeadSnake.headSnake.rangeTeleportFoodX, HeadSnake.headSnake.rangeTeleportFoodX), Random.Range(-HeadSnake.headSnake.rangeTeleportFoodY, HeadSnake.headSnake.rangeTeleportFoodY));
        }
    }
}
