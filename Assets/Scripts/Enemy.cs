using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject target; 
    public float moveSpeed; 
    public GameObject RunPoint;
    public Rigidbody2D Player;
    public Transform Other;
    public float WantedDistance;
    public Flashlight.flash Flash;
    Transform Edge;
    public bool MoveRight;
    float FaceRight;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {

        var step = moveSpeed * Time.deltaTime;
        float dist = Vector3.Distance(RunPoint.transform.position, Other.transform.position);
        float Play_Dist = Vector3.Distance(Player.transform.position, RunPoint.transform.position);
        float player_enemy_dist = Vector3.Distance(enemy.transform.position, Player.transform.position);

        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * moveSpeed, 0, 0);
            Moving(dist, WantedDistance, Flash, player_enemy_dist, Play_Dist, FaceRight);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * moveSpeed, 0, 0);
            Moving(dist, WantedDistance, Flash, player_enemy_dist, Play_Dist, FaceRight);

        }


    }
    private void Moving(float dist, float WantedDistance, Flashlight.flash light , float player_enemy_dist, float Play_Dist, float FaceRight)
    {
        FaceRight = Player.transform.lossyScale.x;

        if (dist <= WantedDistance && !Flash.IsToggled(Flash.light))
        {
            MoveRight = false;
        }
        else if (player_enemy_dist >= Play_Dist && Flash.IsToggled(Flash.light) && FaceRight > 0.9f)
        {
            Debug.Log(FaceRight);
            MoveRight = true;

        }
        else if (enemy.transform.position.x <= RunPoint.transform.position.x && Flash.IsToggled(Flash.light))
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge"))
        {
            if (MoveRight == true)
            {
                MoveRight = false;
            }
            else MoveRight = true;
        }
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
