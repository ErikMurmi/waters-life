using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
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
    public float movement = 0;
    public float CameraOffsetX =2.56f;
    public float CameraOffsetY =2.43f;
    public float CameraOffsetZ =-10f;

    private bool rightMove;
    private bool leftMove;
    private AudioSource audioSource;
  //Sonidos 

  public AudioClip MuerteClip;
  public AudioClip HablaClip;

    void Start()
    {
        rgbPlayer = GetComponent<Rigidbody2D>();
        saltoCollider = GetComponent<BoxCollider2D>();
        SaltosRestantes = numeroSaltos;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.Estado == Estados.Jugando)
        {
            
            if (rightMove){
                Player.GetComponent<SpriteRenderer>().flipX = false;
                rgbPlayer.velocity = new Vector2(speed * 1, rgbPlayer.velocity.y);
            }
               
            else if (leftMove ){
                Player.GetComponent<SpriteRenderer>().flipX = true;
                rgbPlayer.velocity = new Vector2(speed * -1, rgbPlayer.velocity.y);
            }
                
            
            if (enSuelo())
            {
                SaltosRestantes = numeroSaltos;
            }
            if (Input.GetKeyDown(KeyCode.Space) && SaltosRestantes > 0)
            {
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

    public void Saltar(){
        if(SaltosRestantes > 0){
            SaltosRestantes--;
            rgbPlayer.velocity = new Vector2(rgbPlayer.velocity.x/2,0f);   
            rgbPlayer.AddForce(Vector2.up * JumpForce,ForceMode2D.Impulse);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Finish":
                gameController.irFin();
            break;
            case "Recomendacion":
                gameController.Estado = Estados.Fin;
            break;
            case "Enemy":
              StartCoroutine("Morir");
            break;
            case "Respawn":
                gameController.updateRespawn(collision.gameObject.transform.position);
                Debug.Log("Respawn hit");
            break;
            default:
                Debug.Log("hit");
            break;
        }
    }

    
    IEnumerator Morir()
    {
        saltoCollider.enabled = false;
        audioSource.clip = MuerteClip;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        saltoCollider.enabled = true;
        gameController.respawnPlayer();
  }

}
