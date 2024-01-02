using UnityEngine.SceneManagement;
using UnityEngine;

public class NivelesController : MonoBehaviour
{

  public void cargarZona(string zona)
  {
    SceneManager.LoadScene($"{zona}-Niveles");
  }
  public void cargarIniaquito(string nivel)
  {
    SceneManager.LoadScene($"Iniaquito-{nivel}");
  }

  public void cargarNivel(string Zona, string Nivel)
  {
    SceneManager.LoadScene(Zona + "-" + Nivel);
  }

  public void cargarTrebol()
  {
    SceneManager.LoadScene("Trebol");
  }

  public void irHome()
  {
    SceneManager.LoadScene("Home");
  }

  public  void irQR()
  {
    SceneManager.LoadScene("Scanner");
  }


}
