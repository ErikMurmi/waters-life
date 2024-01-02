using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParallaxEffect : MonoBehaviour
{

    public float parallaxMultiplier;

    private Transform cameraTransform;

    private Vector3 previousCameraPosition;
    
    private float spriteHeight, startPositionx, startPositiony, startPositionz;

    void Start()
    {
        //Alto del componente
        //spriteHeight = GetComponent<TilemapRenderer>().bounds.size.y;
        
        //Posición inicial
        startPositionx = transform.position.x;
        startPositiony = transform.position.y;
        startPositionz = transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Cuánto se movió la camara en el eje x
        /*float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * parallaxMultiplier;*/

        //Cuánto se movió la capa respecto a la cámara
        /*float moveAmount = cameraTransform.position.x * (1 - parallaxMultiplier);*/

        
        //Debug.Log("New Position Y: " + newPositionY);
        transform.Translate(new Vector3(0, -0.005f , 0));
        float newPositionY = transform.position.y;
        //actualiza la posición de la cámara
        //previousCameraPosition = cameraTransform.position;   startPosition + spriteHeight

        if(newPositionY <= -18.68){
            transform.position = new Vector3(startPositionx, 12.87f, startPositionz);
            //startPosition += 25;
        }
    }
}
