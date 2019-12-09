using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionPickup : MonoBehaviour
    
{
    public Inventory inventory;
    public GameObject itemButton;

    public void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            for(int i=0; i< inventory.slots.Length; i++)
            {
                if(Input.GetKeyDown(KeyCode.Space) && inventory.isfull[i] == false)
                {
                    inventory.isfull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
