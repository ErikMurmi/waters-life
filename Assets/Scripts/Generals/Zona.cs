using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Zona : MonoBehaviour
{
    // Start is called before the first frame update
    public bool bloqueado = true;
    public int ZonaNum;
    public GameObject Lock;
    void Start()
    {
        actualizarEstado();
    }

    public void irZona()
    {
        actualizarEstado();
        if (!bloqueado)
            SceneManager.LoadScene("Zona"+ZonaNum);
        else
            Debug.Log("Mundo bloqueado");
    }

    void actualizarEstado()
    {
        int estado = PlayerPrefs.GetInt("Zona" + ZonaNum);
        Debug.Log("Zona: "+ estado);
        if (estado == 0)
        {
            Lock.SetActive(true);
            bloqueado = true;
        }
        else
        {
            Lock.SetActive(false);
            bloqueado = false;
        }
            

    }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.tag);
  }
}
