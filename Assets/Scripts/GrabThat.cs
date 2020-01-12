using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabThat : MonoBehaviour
{
    
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    Vector2 x;
    Vector3 xy;
    public Rigidbody2D player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                float leftDot = player.transform.lossyScale.x;
                Debug.Log(leftDot);
                hit = Physics2D.Raycast(transform.position, (Vector2.right + (0.3f * Vector2.down)) * transform.localScale.x, distance);
                if (leftDot > 0.9f)
                {
                    hit = Physics2D.Raycast(transform.position, (Vector2.right + (0.3f * Vector2.down)) * transform.localScale.x, distance);
                }
                else if (leftDot < -0.9f)
                {
                    x.Set(0.3f * Mathf.Abs(Vector2.down.x), 0.3f * Mathf.Abs(Vector2.down.y));
                    hit = Physics2D.Raycast(transform.position, (Vector2.right + x) * transform.localScale.x, distance);
                }

                if (hit.collider != null && hit.collider.CompareTag("grabbable"))
                {
                    grabbed = true;
                }

            }
            else if (!Physics2D.OverlapPoint(holdpoint.transform.position, notgrabbed))

            {
                grabbed = false;
                //Debug.Log("Got it");
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                  //  Debug.Log("Throw");

                }
            }

        }
        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;

        }        



    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
        float leftDot = player.transform.lossyScale.x;

        if (leftDot > 0.9f)
        {
            Gizmos.DrawLine(transform.position, transform.position + (Vector3.right + (0.5f * Vector3.down)) * transform.localScale.x * distance);

        }
        else if (leftDot < -0.9f)
        {

            xy.Set(0.5f * Mathf.Abs(Vector3.down.x), 0.5f * Mathf.Abs(Vector3.down.y), 0.5f * Mathf.Abs(Vector3.down.z));
            Gizmos.DrawLine(transform.position, transform.position + (Vector3.right + xy) * transform.localScale.x * distance);
        }
    }
}
    

   
