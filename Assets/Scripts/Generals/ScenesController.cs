using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesController : MonoBehaviour
{
  public static void cargarIniaquito(string nivel)
  {
    SceneManager.LoadScene($"Iniaquito-{nivel}");
  }
}
