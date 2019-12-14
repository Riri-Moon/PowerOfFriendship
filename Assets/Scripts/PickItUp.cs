using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItUp : MonoBehaviour

    
{
    private Inventory inventory;
    public GameObject itemButton;
    public bool  Coll;
    battery x;
    public void Start() 
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log(inventory.slots.Length);

                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isfull[i] == false)
                    {
                        inventory.isfull[i] = true;
                        gameObject.transform.localScale += new Vector3(2, 2, 2);
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }   catch (Exception e)
        {
           
        }
    }
}
