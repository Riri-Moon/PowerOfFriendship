using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Rigidbody2D Player;
    //[SerializeField] Transform SpawnPoint;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            DontDestroyOnLoad(Player);
            //collision.transform.position = SpawnPoint.position; 

            SceneManager.LoadScene(2);
            OnLevelWasLoaded(2);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        
        Player.position = CheckpointController.GetActiveCheckPointPosition();
    }
}
