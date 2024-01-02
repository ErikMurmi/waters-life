using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

namespace Game
{
    public class GCTrebol : MonoBehaviour
    {
        public Estados Estado;
        public TextMeshProUGUI TubsUI;
        public TextMeshProUGUI PartesUI;

        public TextMeshProUGUI TrashScore;
        public TextMeshProUGUI PartesScore;
        public TextMeshProUGUI[] TextosInicio;
        public TextMeshProUGUI[] TextosFin;
        public GameObject ScorePanel;
        public GameObject trashGenerator;
        public GameObject tapGenerator;
        public GameObject Minigame;

        public GameObject HistoriaPanel;
        public TextController textController;
        public GameObject Player;

        public int TrashTotales { get { return trashTotales; } }
        private int trashTotales;
        public int TubTotales { get { return tubTotales; } }
        private int tubTotales;

        public TextMeshProUGUI trashScoreEnd;


        public float finalPosX;
        // Start is called before the first frame update
        void Start()
        {
            Estado = Estados.Inicio;
            textController = GameObject.Find("Historia").GetComponent<TextController>();
        }

        // Update is called once per frame
        void Update()
        {
            ComprobarEstado();
            
        }

        void ComprobarEstado()
        {
            switch (Estado)
            {
                case Estados.Inicio:
                    HistoriaPanel.SetActive(true);
                    textController.IniciarHistoria(TextosInicio);
                    Player.GetComponent<Animator>().Play("Hablando");
                    break;
                case Estados.Pausa:
                    desactivarGeneradores();
                    HistoriaPanel.SetActive(false);
                    TrashScore.text = trashTotales.ToString();
                    ScorePanel.SetActive(true);

                    trashScoreEnd.text = trashTotales.ToString();
                    break;
                case Estados.Fin:
                    HistoriaPanel.SetActive(true);
                    desactivarGeneradores();
                    textController.IniciarHistoria(TextosFin);
                    Player.GetComponent<PlayerWaterController>().Parar();
                    Player.GetComponent<Animator>().Play("Recomendacion");
                    break;
                case Estados.Jugando:
                    activarGeneradores();
                    HistoriaPanel.SetActive(false);
                    ScorePanel.SetActive(false);
                    Player.GetComponent<Animator>().Play("Correr");
                    break;
            }
        }

        void desactivarGeneradores(){
            TrashGenerator tg = trashGenerator.GetComponent<TrashGenerator>();
            tg.stop();
            TapGenerator tp = tapGenerator.GetComponent<TapGenerator>();
            tp.stop();
            BoxCollider2D bd = Player.GetComponent<BoxCollider2D>();
            bd.enabled = false;
        }

        void activarGeneradores(){
            trashGenerator.SetActive(true);
            tapGenerator.SetActive(true);
        }
        public void SumarTrash(int Trash)
        {
            trashTotales += Trash;
            TrashScore.text = trashTotales.ToString();
            Debug.Log("Basura Actual: " + trashTotales);
        }

        public void SumarTuberias(int Tubs)
        {
            tubTotales += Tubs;
            TubsUI.text = tubTotales.ToString();
            Debug.Log("Tubs Actuales: " + tubTotales);
        }

        public void irFin()
        {
            Player.transform.position = new Vector2(finalPosX, Player.transform.position.y);
        }

        public void showScore()
        {
            HistoriaPanel.SetActive(false);
            TrashScore.text = trashTotales.ToString();
            ScorePanel.SetActive(true);

            trashScoreEnd.text = trashTotales.ToString();
        }

        public void pausar()
        {
            //Si está pausado lo reanuda
            if(Estado == Estados.Pausa){
                Estado = Estados.Jugando;
            }else{//Sino, lo pausa
                Estado = Estados.Pausa;
            }
        }

        public void showMinigame(){
            CloseTaps ct = Minigame.GetComponent<CloseTaps>();
            ct.reiniciar();
            Minigame.SetActive(true);
        }

        public void reiniciar()
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }

        public void irZona2()
        {
            SceneManager.LoadScene("Zona2");
            int actualTrashScore = PlayerPrefs.GetInt("Trash",0);
            PlayerPrefs.SetInt("Trash",actualTrashScore+trashTotales);
        }

    }
}

