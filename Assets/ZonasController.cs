using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Zonas
{
  public class ZonasController : MonoBehaviour
  {
    public static int zonaActual;
    public List<Zona> zonas;
    public Button unlockerBtn;
    public Button irZonaBtn;
    public Button iqBtn;
    public Button trBtn;
    public TextMeshProUGUI unlockerTxt;
    public TextMeshProUGUI irZonaTxt;
    public Text estado;
    private NivelesController nivelesController;
    private string[] zonasName = {"Iq","Tr" };

    public void setZonaActual(int zona)
    {
      zonaActual = zona;
    }
    
    private void Awake()  
    {
      zonaActual = -1;
      initZonas();
      refreshEstado();
    }

    public void refreshEstado()
    {
      estado.text = $" prefs\nZona1: {PlayerPrefs.GetInt("Zona1", 0)} \n Zona2: {PlayerPrefs.GetInt("Zona2", 0)}" +
        $"\nzonaActual: {zonaActual}";
    }

    private void Start()
    {
      nivelesController  = new NivelesController();
    }

    public void showUnlocker(int zona)
    {
      if (zonas[zona-1].isLocked)
      {
          unlockerBtn.gameObject.SetActive(true);
          unlockerTxt.text = $"Desbloquear zona {zonas[zona-1].nombre}";
      }
      else
      {
          irZonaBtn.gameObject.SetActive(true);
          irZonaTxt.text = $"Explorar zona {zonas[zona-1].nombre}";
      }
      
    }

    public void hideUnlocker()
    {
      unlockerBtn.gameObject.SetActive(true);
      zonaActual = -1;
    }

    public void scanZoneQR()
    {
      nivelesController.irQR();
    }
    
    public void irZona()
    {
      nivelesController.cargarZona(zonasName[zonaActual-1]);
    }

    public void resetEstado()
    {
      PlayerPrefs.SetInt("Zona1", 0);
      PlayerPrefs.SetInt("Zona2", 0);
      initZonas();
      refreshEstado();
    }

    private void initZonas()
    {
      zonas = new List<Zona>();
      zonas.Add(new Zona("Iñaquito", PlayerPrefs.GetInt("Zona1", 0)<1));
      zonas.Add(new Zona("Trebol", PlayerPrefs.GetInt("Zona2", 0) < 1));
    }
  }

  public class Zona{
    public string nombre;
    public bool isLocked;
    public Zona(string nombre, bool isLocked)
    {
      this.nombre = nombre;
      this.isLocked = isLocked;
    }
  }
}

