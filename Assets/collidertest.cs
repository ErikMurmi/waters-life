using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidertest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
    Debug.Log(other.gameObject.tag);
    }
}
