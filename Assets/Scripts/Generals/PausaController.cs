using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Krivodeling.UI.Effects;

public class PausaController : MonoBehaviour
{
  public GameObject PausaPanel;
  public GameObject BlurPanel;
  private UIBlur blurController;

  public void Start()
  {
    blurController = BlurPanel.GetComponent<UIBlur>();
  }
  public virtual void Pause()
  {
    PausaPanel.SetActive(true);
    blurController.BeginBlur(2);
  }

  public void Resume()
  {
    PausaPanel.SetActive(false);
    blurController.EndBlur(2);
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void irHome()
  {
    SceneManager.LoadScene("Home");
  }
}
