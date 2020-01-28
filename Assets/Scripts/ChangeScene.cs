using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
public class ChangeScene : MonoBehaviour
{
	public AudioSource factory;
    public Rigidbody2D Player;
    public int Level;
    public Transform New_Position;
    //[SerializeField] Transform SpawnPoint;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        factory = GetComponent <AudioSource> ();
        if(collision.CompareTag("Player"))
        {
			factory.Play();
			
            Player.position = New_Position.position;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        
        Player.position = CheckpointController.GetActiveCheckPointPosition();
    }
	
}
*/

public class ChangeScene : MonoBehaviour
{
	public Rigidbody2D Player;
	public int Level;
	public Transform New_Position;
	public GameObject Fact_doors;
	[SerializeField] private GameObject dement;
	[SerializeField] private GameObject completed;
	private Inventory inventory;
	
	private void Start()
	{
		inventory= GameObject.Find("Player").GetComponent<Inventory>();
	}
	
	void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
			if(Fact_doors.tag != "Factory_Doors")
			{
				Player.position = New_Position.position;
			}
			else if(Fact_doors.tag == "Factory_Doors" && inventory.isfull[1]!= true) 
			{
				dement.SetActive(true);
			}
			else if (Fact_doors.tag == "Factory_Doors" && inventory.isfull[1]==true) 
			{
				
				completed.SetActive(true);
				Player.position = New_Position.position; 
			}
			
            
        }
    }

    
}

