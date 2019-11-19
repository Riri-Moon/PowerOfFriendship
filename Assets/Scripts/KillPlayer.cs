using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
          //  System.Threading.Thread.Sleep(1000);
            collision.transform.position = SpawnPoint.position; 
        }
    }
}
