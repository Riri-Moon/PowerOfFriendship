using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Load : MonoBehaviour

{
    public Rigidbody2D Player;
    public Transform SpawnPoint_Factory;
    // Start is called before the first frame update
    void Start()
    { 
        Player.position = SpawnPoint_Factory.position;        
    }

}

