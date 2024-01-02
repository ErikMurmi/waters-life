using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class Llave : MonoBehaviour
{
    // Start is called before the first frame update
    public GCTrebol gctrebol;
    void Start()
    {
        gctrebol = GameObject.Find("GameController").GetComponent<GCTrebol>();
    }

    // Update is called once per frame
    void Update()
    {
               // gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            gctrebol.showMinigame();
        }
    }
}
