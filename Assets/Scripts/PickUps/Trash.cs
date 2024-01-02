using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class Trash : MonoBehaviour
{
    
    public int valor;

    public GCTrebol gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GCTrebol>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            gameController.SumarTrash(valor);
            Destroy(this.gameObject);
        }
    }
}
