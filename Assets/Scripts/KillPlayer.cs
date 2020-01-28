using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KillPlayer : MonoBehaviour
{
    GameObject Drop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
		
        Drop = GameObject.FindGameObjectWithTag("Drop");



        if (collision.transform.CompareTag("Player"))
        {

            collision.transform.position = CheckpointController.GetActiveCheckPointPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		
        if (collision.transform.CompareTag("Road"))
        {


            Destroy(Drop);
            Debug.Log("Destroyed");
        }
   
        if (collision.transform.CompareTag("Player"))
        {
           
            collision.transform.position = CheckpointController.GetActiveCheckPointPosition();
        }
    }
}
