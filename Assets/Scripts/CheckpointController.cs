using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField]
    public bool activated = false;
    public static GameObject[] CheckPointsList;
    public Object CheckPoint;
   
    void Start()
    {
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }

    private void ActivateCheckPoint()
    {
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckpointController>().activated = false;
        }

        activated = true;
    }

    public static Vector2 GetActiveCheckPointPosition()
    {
        Vector2 result = new Vector2(0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                if (cp.GetComponent<CheckpointController>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        return result;
    }
}

