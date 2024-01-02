using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;
using keysLevel;

public class Desagues : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerKeysControl PKC ;
    private Button llaveDisponibleBtn;
    public GameObject RepairButton;
    private SpriteRenderer spriteRenderer;

    public Sprite normal;
    public Sprite mejorada;

    public GameController gcontroller;
    void Start()
    {
        GameObject Player =  GameObject.Find("Player");
        PKC = Player.GetComponent<PlayerKeysControl>();
        llaveDisponibleBtn = GameObject.Find("LlaveDisponible").GetComponent<Button>();
        gcontroller = GameObject.Find("GameController").GetComponent<GameController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && (PKC.hasKey))
            showRepair();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
            hideRepair();
    }

    public void showRepair(){
        RepairButton.SetActive(true);
    }

    public void hideRepair(){
        RepairButton.SetActive(false);  
    }

    public void upgrade(){
        spriteRenderer.sprite = mejorada;
        PKC.hasKey = false;
        llaveDisponibleBtn.interactable = false;
        Debug.Log("Is Upgraded");
        gcontroller.SumarTuberias(1);
    }

}
