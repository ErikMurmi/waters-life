using System.Collections;
using System.Collections.Generic;
using keysLevel;
using UnityEngine;

public class testKEys : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            PlayerKeysControl nm = collision.gameObject.GetComponent<PlayerKeysControl>();
            nm.changeKeyState(true);
            Destroy(this.gameObject);
        }
    }
}
