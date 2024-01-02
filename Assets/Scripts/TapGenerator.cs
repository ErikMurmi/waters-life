using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGenerator : MonoBehaviour
{
    public Sprite[] Sprites;
    public GameObject Prefab;
    public float[] xPositions;
    private SpriteRenderer sp;

    void Start()
    {
        InvokeRepeating("generateTap", 4.0f, 5.0f);
        sp = Prefab.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            generateTap();
    }

    int getRandomPos()
    {
        int pos = Random.Range(0, xPositions.Length);
        //Console.log(pos);
        return pos;
    }

    void generateTap()
    {

        int posIndex = getRandomPos();
        Vector3 pos = new Vector3(xPositions[posIndex], transform.position.y, 0);
        //Prefab.gameObject.GetComponent<SpriteRenderer>() = SpriteRenderer[posIndex];
        //ChangeSprite(SpriteRenderer[posIndex])
        sp.sprite = Sprites[posIndex];
        Instantiate(Prefab,pos,Prefab.transform.rotation);
    }

    public void stop(){
        CancelInvoke();
    }
}
