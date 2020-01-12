using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject target; 
    public float moveSpeed = 5; 
    public GameObject RunPoint;
    public Rigidbody2D Player;
    public Transform Other;
    public float WantedDistance;
    public Flashlight.flash Flash;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        var step = moveSpeed * Time.deltaTime;
        float dist = Vector3.Distance(RunPoint.transform.position, Other.transform.position);

        if (dist <= WantedDistance && !Flash.IsToggled(Flash.light))
        {


            transform.position = new Vector3(transform.position.x, -19.5f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
            moveSpeed = 27;
        }
        else if (dist <= WantedDistance && Flash.IsToggled(Flash.light))
        {

           // transform.position = new Vector3(transform.position.x, -19.5f, transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, -step);
            //moveSpeed = 60;
            //Waiter(2);
            enemy.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        transform.position = new Vector3(transform.position.x, -19.5f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, -50f );

 
    }

    IEnumerable Waiter(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * transform.localScale.x * WantedDistance);
    }

}
