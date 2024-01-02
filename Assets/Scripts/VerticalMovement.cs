using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, -speed*Time.deltaTime, 0.0f);
    }
}
