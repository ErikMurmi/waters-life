using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloseTaps : MonoBehaviour
{
    // Start is called before the first frame update

    public int HitsLeft;
    public int HistsNeeded;
    public float TimeLeft ;
    public float time;
    public bool TimerOn = false;

    public TextMeshProUGUI Timer;
    public GameObject fail;
    public GameObject backgound;

    public TextMeshProUGUI KeyScoreText;
    public TimerAgua timerAguaController;

    void Start()
    {
        TimeLeft = time;
        HitsLeft = HistsNeeded;
        backgound.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft > 0){
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }else{
            Debug.Log("No cerraste la llave");
            TimeLeft=0;
            updateTimer(TimeLeft);
            TimerOn = false;
            backgound.SetActive(false);
            fail.SetActive(true);
            StartCoroutine("ExampleCoroutine");
            //this.gameObject.SetActive(false);
        }
    }

    void updateTimer(float currentTime){
        currentTime = Mathf.Round(currentTime * 100.0f) * 0.01f;
        Timer.text = currentTime.ToString();
    }

    public void closeTap(){
        if (HitsLeft>1)
            HitsLeft-=1;
        else{

            timerAguaController = GameObject.Find("Timer").GetComponent<TimerAgua>();

            int num = (int.Parse(KeyScoreText.text) + 1);

            timerAguaController.plusTimer();

            KeyScoreText.text = num.ToString();
            this.gameObject.SetActive(false);
            Debug.Log("Closed");
        }
            
    }

    public void reiniciar(){
        TimeLeft = time;
        HitsLeft = HistsNeeded;
        backgound.SetActive(true);
        fail.SetActive(false);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        fail.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
