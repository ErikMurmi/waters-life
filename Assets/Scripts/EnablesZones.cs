using UnityEngine.SceneManagement;
using UnityEngine;
using  TMPro;
using Zonas;
using UnityEngine.UI;

public class EnablesZones : MonoBehaviour
{
    public TextMeshProUGUI message;
    public GameObject msg_obj;
    public GameObject[] targets;
    public Text info;
  private void Awake()
  {
    initTargets();
  }

  private void initTargets()
  {
    foreach (GameObject target in targets)
    {
      target.SetActive(false);
    }
    targets[ZonasController.zonaActual-1].SetActive(true);
    info.text = $"Target disponible {ZonasController.zonaActual.ToString()}";
  }

  public void unlockZona(int Zona)
    {
        PlayerPrefs.SetInt("Zona"+Zona, 1);
        Debug.Log("TARGET ENCONTRADO");

    }

    public void goHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void showMessage(string msg){
        msg_obj.SetActive(true);
        message.text = $"¡¡¡¡ Has desbloqueado una nueva zona {msg} !!!!";
    }

}
