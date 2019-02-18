using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour {

    // Use this for initialization
    public SpriteRenderer spriteRenderer;
    private bool teleport;
    public bool notTeleport;

    private void Start()
    {
        teleport = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        
    }
    private void Update()
    {
        if(teleport && !notTeleport)
        {
            spriteRenderer.enabled = false;
            transform.position = new Vector2(Random.Range(-HeadSnake.headSnake.rangeTeleportFoodX, HeadSnake.headSnake.rangeTeleportFoodX), Random.Range(-HeadSnake.headSnake.rangeTeleportFoodY, HeadSnake.headSnake.rangeTeleportFoodY));
        }
        if(notTeleport)
        {
            spriteRenderer.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == "piso" || collision.tag == "pasto")
        {
            teleport = false;
            spriteRenderer.enabled = true;
        }
        else
        {
            teleport = true;
        }
        
    }
}
