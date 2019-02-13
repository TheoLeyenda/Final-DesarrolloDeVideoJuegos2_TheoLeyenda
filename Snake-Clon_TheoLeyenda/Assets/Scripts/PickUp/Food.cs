using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector2(Random.Range(-HeadSnake.headSnake.rangeTeleportFoodX, HeadSnake.headSnake.rangeTeleportFoodX), Random.Range(-HeadSnake.headSnake.rangeTeleportFoodY, HeadSnake.headSnake.rangeTeleportFoodY));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "limite")
        {
            spriteRenderer.enabled = false;
            transform.position = new Vector2(Random.Range(-HeadSnake.headSnake.rangeTeleportFoodX, HeadSnake.headSnake.rangeTeleportFoodX), Random.Range(-HeadSnake.headSnake.rangeTeleportFoodY, HeadSnake.headSnake.rangeTeleportFoodY));
        }
        if(collision.tag == "piso" || collision.tag == "pasto")
        {
            spriteRenderer.enabled = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "limite")
        {
            spriteRenderer.enabled = true;
        }
    }
}
