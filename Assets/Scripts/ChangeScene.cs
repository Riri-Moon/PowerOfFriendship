using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Rigidbody2D Player;
    public int Level;
    public Transform New_Position;
    //[SerializeField] Transform SpawnPoint;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            Player.position = New_Position.position;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        
        Player.position = CheckpointController.GetActiveCheckPointPosition();
    }
}
