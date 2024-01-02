using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class HomeController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 CentroCamara;
    private Camera mainCamera;
    public TextMeshProUGUI gotas;
    public TextMeshProUGUI email;
    public TextMeshProUGUI trash;


    private void Awake()
    {

    }

    
    void Update()
    {
        gotas.text = PlayerPrefs.GetInt("Gotas",0).ToString();
        trash.text = PlayerPrefs.GetInt("Trash",0).ToString();
    }

    void Start()
    {
        mainCamera = Camera.main;
        CentroCamara = mainCamera.transform.position;
        updateEmail();
        
    }

 
    void updateEmail()
    {
        var currentUser = FirebaseAuth.DefaultInstance.CurrentUser;
        string email_str = "";
        if (currentUser != null)
        {
            email_str = currentUser.DisplayName;
        }

        email.text = email_str;
    }

    public void centerCamera()
    {
        mainCamera.transform.position = CentroCamara;
        PanZoom zoom = mainCamera.GetComponent<PanZoom>();
        mainCamera.orthographicSize = zoom.zoomOutMax - 5;
    }

    public void irScanner()
    {
        SceneManager.LoadScene("Scanner");
    }

}
