using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float xBounds;

    void Start()
    {
        //Ejecuta el método generateTrash por primera vez a los 2 seg de iniciar el juego, luego repetidamente cada 5 segundos
        InvokeRepeating("generateTrash", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Genera basura cuando presionas c
        if (Input.GetKeyDown(KeyCode.C))
            generateTrash();
    }

    float getRandomPos()
    {
        //Posiciones aleatorias para la generación de la basura dentro de la interfaz de juego
        float pos = Random.Range(-xBounds, xBounds);
        //Console.log(pos);
        return pos;
    }

    void generateTrash()
    {
        
        int index = Random.Range(0,Prefabs.Length);
        Vector3 pos = new Vector3(getRandomPos(), transform.position.y, 0);
        Instantiate(Prefabs[index], pos,Prefabs[index].transform.rotation);
    }

    public void stop(){
        //Para la repetición de del InvokeRepeating
        CancelInvoke();
    }
}
