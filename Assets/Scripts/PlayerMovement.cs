using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Camera;
    private Rigidbody2D rgbPlayer;
    private BoxCollider2D saltoCollider;
    private GameController gameController;
    public LayerMask capaSuelo;
    
    public int numeroSaltos;
    public int SaltosRestantes;
    public float speed;
    public float JumpForce;
    public float CameraOffsetX =2.56f;
    public float CameraOffsetY =2.43f;
    public float CameraOffsetZ =-10f;

    void Start()
    {
        rgbPlayer = GetComponent<Rigidbody2D>();
        saltoCollider = GetComponent<BoxCollider2D>();
        SaltosRestantes = numeroSaltos;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.Estado == Estados.Jugando)
        {
            float movement = Input.GetAxis("Horizontal");
            if (movement > 0)
                Player.GetComponent<SpriteRenderer>().flipX = false;
            else if (movement < 0)
                Player.GetComponent<SpriteRenderer>().flipX = true;
            rgbPlayer.velocity = new Vector2(speed * movement, rgbPlayer.velocity.y);

            if (enSuelo())
            {
                SaltosRestantes = numeroSaltos;
            }
            if (Input.GetKeyDown(KeyCode.Space) && SaltosRestantes > 0)
            {
                SaltosRestantes--;
                Saltar();
            }
            //Seguimiento de camara
            Camera.transform.position = new Vector3(Player.transform.position.x + CameraOffsetX,
                                                    Player.transform.position.y + CameraOffsetY, CameraOffsetZ);
        }
    }


    bool enSuelo()
    {
        RaycastHit2D ryHit = Physics2D.BoxCast(saltoCollider.bounds.center, new Vector2(saltoCollider.bounds.size.x, saltoCollider.bounds.size.y),0f,Vector2.down,0.2f,capaSuelo);
        return ryHit.collider != null;
    }

    void Saltar(){
        rgbPlayer.velocity = new Vector2(rgbPlayer.velocity.x/2,0f);   
        rgbPlayer.AddForce(Vector2.up * JumpForce,ForceMode2D.Impulse);
    }

    public void Parar()
    {
        rgbPlayer.velocity = new Vector2(0f, 0f);
    }
}
