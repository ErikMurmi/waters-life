using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int valor = 1;
    private GameController gameController;
    private Rigidbody2D rgbEnemy;
    public float speed;
    public float startXPosition;
    public float endXPosition;
    public int movement = 1;



    void Start()
    {
        rgbEnemy = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameController.Estado == Estados.Jugando)
        {
            if (transform.position.x > endXPosition && movement==1)
            {
                movement = -1;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(transform.position.x < startXPosition && movement == -1)
            {
                movement = 1;
                GetComponent<SpriteRenderer>().flipX = true;
            }
                
            rgbEnemy.velocity = new Vector2(speed * movement, rgbEnemy.velocity.y);
        }
        else
        {
            Parar();
        }
    }

    public void Parar()
    {
        rgbEnemy.velocity = new Vector2(0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Debug.Log("True");
            
            gameController.SumarGotas(valor);
        }
    }
}
