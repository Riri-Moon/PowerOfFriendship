using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public GameObject RunPoint;
    public Rigidbody2D Player;
    public Transform Other;
    public float WantedDistance;
    public Flashlight.flash Flash;

    void Start()
    {
       // Flash = GetComponent< Flashlight.flash >();
        target = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.Find("Eyes");
    }
    void Update()
    {
        
        var step = moveSpeed * Time.deltaTime;
        float dist = Vector3.Distance(RunPoint.transform.position, Other.transform.position);
        
        if (dist <= WantedDistance && !Flash.IsToggled(Flash.light))
        {

            if (enemy.activeInHierarchy == true && Vector3.Distance(enemy.transform.position, RunPoint.transform.position) >= 0.1f)
            {
                enemy.gameObject.GetComponent<Enemy>().enabled = true;
                enemy.SetActive(true);

            }
            transform.position = new Vector3(transform.position.x, -19.5f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
            moveSpeed = 15;
        }
        else if (dist <= WantedDistance && Flash.IsToggled(Flash.light))
        {
            
            enemy.SetActive(false);
            transform.position = new Vector3(transform.position.x, -19.5f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, -step);
            moveSpeed = 50;
        }
        
    }
}
