using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    public GameObject Drop;
    public float Rate;
    float next = 0.0f;
    public Transform From;




    void Update()
    {   
        if(Time.time > next)
        {
            next = Time.time + Rate;
            Instantiate(Drop, From.transform.position, Quaternion.identity);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Road"))
        {
            Destroy(Drop);
        }
    }
}
