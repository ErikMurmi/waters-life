using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using TMPro;

public class TimerAgua : MonoBehaviour
{
    public float TimeLeft ;
    public bool TimerOn = false;
    public GCTrebol gameController;

    public TextMeshProUGUI TimerTxt;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GCTrebol>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.Estado == Estados.Jugando){
            if(TimeLeft > 0){
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }else{
                TimeLeft=0;
                updateTimer(TimeLeft);
                TimerOn = false;
                gameController.Estado = Estados.Fin;
            }
        }
        
    }

    void updateTimer(float currentTime){
        currentTime = Mathf.Round(currentTime * 100.0f) * 0.01f;
        TimerTxt.text = currentTime.ToString("00.00");
    }

    public void plusTimer(){
        TimeLeft = TimeLeft + 3f;
    }
}
