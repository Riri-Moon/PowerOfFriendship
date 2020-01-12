using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonFollow : MonoBehaviour
{

    public GameObject Source;
    public Rigidbody2D Player;
    Vector3 offset;
    Vector3 offset2;


    private void Update()
    {
        Clicked();
    }


    private void Clicked()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            offset2.Set(0, (transform.position.y + 10f), 0);
             offset = (transform.position) - Player.transform.position;
            Source.transform.position = Player.transform.position + (offset+offset2);
            
        }
    }
}
