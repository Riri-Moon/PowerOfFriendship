using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Rigidbody2D Player;
    [SerializeField] Transform SpawnPoint;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            DontDestroyOnLoad(Player);
            //collision.transform.position = SpawnPoint.position; 

            SceneManager.LoadScene(1);
            OnLevelWasLoaded(1);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        
        Player.position = SpawnPoint.position;
    }
}
