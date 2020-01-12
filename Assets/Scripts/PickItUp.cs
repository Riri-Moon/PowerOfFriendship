using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItUp : MonoBehaviour

    
{
    private Inventory inventory;
    public GameObject itemButton;
	public GameObject slot_docuemnt;
	public GameObject document_1;
    bool picked_battery=false;
    string component;
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
                component = itemButton.tag;
                Debug.Log(component);
                if(component == "Pick_Battery" && inventory.isfull[2]==false)
                {
                    inventory.isfull[2] = true;
                    gameObject.transform.localScale += new Vector3(2, 2, 2);
                    Instantiate(itemButton, inventory.slots[2].transform, false);
                    Destroy(gameObject);
                }
                else if (component == "Document1" && inventory.isfull[3] == false)
                {
                    inventory.isfull[3] = true;
                    gameObject.transform.localScale += new Vector3(2, 2, 2);
                    Instantiate(itemButton, inventory.slots[3].transform, false);
                    Destroy(gameObject);
					document_1.SetActive(true);
					slot_docuemnt.SetActive(true);
				
					

                }
                else if (component == "Pick_Key" && inventory.isfull[1] == false)
                {
                    inventory.isfull[1] = true;
                    gameObject.transform.localScale += new Vector3(2, 2, 2);
                    Instantiate(itemButton, inventory.slots[1].transform, false);
                    Destroy(gameObject);

                }

                /*
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
                */
            }
        }   catch (Exception e)
        {
          
        }
    }
}
