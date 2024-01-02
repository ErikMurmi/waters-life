using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Zona3D : MonoBehaviour
{
    
    public bool bloqueado = true;
    public int ZonaNum;
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
            bloqueado = true;
        }
        else
        {
            bloqueado = false;
        }
    }

  private void OnTriggerEnter(Collider other)
  {
    Zonas.ZonasController zc = GameObject.Find("ZonasController").GetComponent<Zonas.ZonasController>();
    zc.showUnlocker(ZonaNum);
    zc.setZonaActual(ZonaNum);
    zc.refreshEstado();
  }

  private void OnTriggerExit(Collider other)
  {
    Zonas.ZonasController zc = GameObject.Find("ZonasController").GetComponent<Zonas.ZonasController>();
    zc.hideUnlocker();
    zc.refreshEstado();
  }
}
