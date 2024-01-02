using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerWaterController : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rgbPlayer;

    private GCTrebol gameController;


    public float hSpeed;

    private bool rightMove;
    private bool leftMove;


    void Start()
    {
        rgbPlayer = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GCTrebol>();

    }

    // Update is called once per frame
    void Update()
    {
        //Límites de la screen x: -4.15    -4.40
        //Límite derecho x = 4.15   4.40

        if (gameController.Estado == Estados.Jugando)
        {

            //Permite que no se salga del mapa
            if(transform.position.x < -4.40f){
                transform.position = new Vector3(-4.40f, transform.position.y, transform.position.z);
            }

            if(transform.position.x > 4.40f){
                transform.position = new Vector3(4.40f, transform.position.y, transform.position.z);
            }


            if (rightMove){
                if(transform.position.x < 4.35f){
                    Debug.Log("Pos x:" + transform.position.x);
                    Player.GetComponent<SpriteRenderer>().flipX = false;
                    rgbPlayer.velocity = new Vector2(hSpeed * 1, rgbPlayer.velocity.y);
                }
            }
               
            else if (leftMove ){
                if(transform.position.x > -4.35f){
                    Debug.Log("Pos x:" + transform.position.x);
                    Player.GetComponent<SpriteRenderer>().flipX = true;
                    rgbPlayer.velocity = new Vector2(hSpeed * -1, rgbPlayer.velocity.y);
                }
            }
        }
    }

    public void moveRight(){
        rightMove = true;
    }

    public void moveLeft(){
        leftMove = true;
    }

    public void Parar()
    {
        rightMove = false;
        leftMove=false;
        rgbPlayer.velocity = new Vector2(0f, 0f);
    }


}
