using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        public Estados Estado;
        public TextMeshProUGUI GotasUI;
        public TextMeshProUGUI TubsUI;
        public TextMeshProUGUI PartesUI;
        public TextMeshProUGUI GotasScore;
        public TextMeshProUGUI TubsScore;
        public TextMeshProUGUI PartesScore;
        public TextMeshProUGUI[] TextosInicio;
        public TextMeshProUGUI[] TextosFin;
        public GameObject ScorePanel;

        public GameObject HistoriaPanel;
        public TextController textController;
        public GameObject Player;

        public int GotasTotales { get { return gotasTotales; } }
        private int gotasTotales;

        public int TrashTotales { get { return trashTotales; } }
        private int trashTotales;
        public int TubTotales { get { return tubTotales; } }
        private int tubTotales;
        public int PartesTotales { get { return partesTotales; } }
        private int partesTotales;
        public int tubMax;
        public int partsMax;

        public int level;
        public Vector2 actualRespawn;

        public float finalPosX;
        // Start is called before the first frame update
        void Start()
        {
            Estado = Estados.Inicio;
        }

        // Update is called once per frame
        void Update()
        {
            ComprobarEstado();
            
        }
        
        public void cargarInicio()
        {
          HistoriaPanel.SetActive(true);
          textController = GameObject.Find("Historia").GetComponent<TextController>();
          textController.IniciarHistoria(TextosInicio);
          Player.GetComponent<Animator>().Play("Hablando");
        }
        void ComprobarEstado()
        {
            switch (Estado)
            {
                case Estados.Inicio:
                    cargarInicio();
                    break;
                case Estados.Pausa:
                    break;
                case Estados.Fin:
                    HistoriaPanel.SetActive(true);
                    textController.IniciarHistoria(TextosFin);
                    Player.GetComponent<PlayerControl>().Parar();
                    Player.GetComponent<Animator>().Play("Recomendacion");
                    break;
                case Estados.Jugando:
                    HistoriaPanel.SetActive(false);
                    Player.GetComponent<Animator>().Play("Correr");
                    break;
            }
        }

        public void SumarGotas(int Gotas)
        {
            gotasTotales += Gotas;
            GotasUI.text = gotasTotales.ToString();
            Debug.Log("Gotas Actuales: " + gotasTotales);
        }


        public void SumarTrash(int Trash)
        {
            trashTotales += Trash;
            //GotasUI.text = gotasTotales.ToString();
            Debug.Log("Basura Actual: " + trashTotales);
        }

        public void SumarTuberias(int Tubs)
        {
            tubTotales += Tubs;
            TubsUI.text = tubTotales.ToString() + "/" + tubMax;
            Debug.Log("Tubs Actuales: " + tubTotales);
        }

        public void SumarParte()
        {
            partesTotales +=1;
            PartesUI.text = partesTotales.ToString() + "/" + partsMax;
            Debug.Log("Partes Actuales: " + partesTotales);
        }

        public void irFin()
        {
            Player.transform.position = new Vector2(finalPosX, Player.transform.position.y);
        }

        public void updateRespawn(Vector2 RespawnPos)
        {
            actualRespawn = RespawnPos;
        }

        public void showScore()
        {
            HistoriaPanel.SetActive(false);
            if(level ==1){
                TubsScore.text = TubTotales.ToString();
                GotasScore.text = GotasTotales.ToString();
            }
            else if(level ==2){
                GotasScore.text = GotasTotales.ToString();
                PartesScore.text = partesTotales.ToString();
            }
            ScorePanel.SetActive(true);

        }

        public void reiniciar()
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }

        public void irZona()
        {
            SceneManager.LoadScene("Zona1");
            int actualScore = PlayerPrefs.GetInt("Gotas",0);
            PlayerPrefs.SetInt("Gotas",actualScore+gotasTotales);
            int actualTrashScore = PlayerPrefs.GetInt("Trash",0);
            PlayerPrefs.SetInt("Trash",actualTrashScore+trashTotales);
        }

        public void respawnPlayer()
        {
            Player.transform.position = actualRespawn;
        }

    }

    public enum Estados
    {
        Jugando,
        Pausa,
        Fin,
        Inicio
    }
}

