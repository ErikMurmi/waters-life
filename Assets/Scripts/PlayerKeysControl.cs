using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace keysLevel{
    public class PlayerKeysControl : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject Player;
        public GameObject Camera;
        private Rigidbody2D rgbPlayer;

        private GameController gameController;

        public float speed;
        public float JumpForce;
        public Button llaveDisponible;
        public bool hasKey = false;

        void Start()
        {
            rgbPlayer = GetComponent<Rigidbody2D>();
            gameController = GameObject.Find("GameController").GetComponent<GameController>();

        }

        public void Parar()
        {
            rgbPlayer.velocity = new Vector2(0f, 0f);
        }

        public void changeKeyState(bool state){
            hasKey = state;
            llaveDisponible.interactable = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            switch (collision.tag)
            {
                case "Llave":
                    hasKey = true;
                    break;
                case "Finish":
                    gameController.irFin();
                    break;
                case "Recomendacion":
                    gameController.Estado = Estados.Fin;
                    break;
                case "Enemy":
                    gameController.respawnPlayer();
                    break;
                case "Respawn":
                    gameController.updateRespawn(collision.gameObject.transform.position);
                    Debug.Log("Respawn hit");
                    break;
            }
        }
    }


}

