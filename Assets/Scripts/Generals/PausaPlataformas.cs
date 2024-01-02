using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PausaPlataformas : PausaController
{
  public ToggleGroup controles;
  private const string IZQ = "LeftControl";
  private const string DER = "Derecha";
  public void changeControlsPosition()
    {
      Toggle selectedToggle = controles.ActiveToggles().FirstOrDefault();
      Debug.Log(selectedToggle.gameObject.tag);
      //if(selectedToggle.gameObject.CompareTag("LeftControl"));
     }
  public override void Pause()
  {
    base.Pause();
    PausaPanel.SetActive(true);
  }

}
