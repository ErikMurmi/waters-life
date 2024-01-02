using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaCoin : MonoBehaviour
{
    public int valor = 1;
    private GameController gameController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Debug.Log("True");
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
            gameController.SumarGotas(valor);
            Destroy(this.gameObject);
        }
    }
}
