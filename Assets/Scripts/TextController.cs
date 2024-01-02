using Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    private TextMeshProUGUI[] Textos;
    //Controlador de historia para llaves
    public bool Zona1;
    public GameController gameController;
    public GCTrebol gctrebol;
    public int TextoActual = 0;

    void Start()
    {
        if(Zona1){
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }else{
            gctrebol = GameObject.Find("GameController").GetComponent<GCTrebol>();
        }
        
    }
    
    public void IniciarHistoria(TextMeshProUGUI[] txts)
    {
        Textos = txts;
        Textos[TextoActual].gameObject.SetActive(true);
    }

    public void CambiarTexto()
    {
        bool enRango = TextoActual < Textos.Length - 1;
        if(Zona1){
            if (enRango)
            {
                Textos[TextoActual].gameObject.SetActive(false);
                TextoActual++;
                Textos[TextoActual].gameObject.SetActive(true);
            }
            else if(!enRango && gameController.Estado == Estados.Fin)
            {
                gctrebol.showScore();
            }
            else {
                Textos[TextoActual].gameObject.SetActive(false);
                TextoActual = 0;
                gameController.Estado = Estados.Jugando;
                
            }
        }else{
            if (enRango)
            {
                Textos[TextoActual].gameObject.SetActive(false);
                TextoActual++;
                Textos[TextoActual].gameObject.SetActive(true);
            }
            else if(!enRango && gctrebol.Estado == Estados.Fin)
            {
                gctrebol.showScore();
            }
            else {
                Textos[TextoActual].gameObject.SetActive(false);
                TextoActual = 0;
                gctrebol.Estado = Estados.Jugando;  
            }
        }
        
    }
}
