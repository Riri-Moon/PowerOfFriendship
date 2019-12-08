using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip[] Audioclip;
    public AudioSource Audio;
    public float maxSpeed = 70;
    public float speed = 276.0f;
    public float jumpPower = 1500f;     
    public bool grounded;
    private Rigidbody2D rb2;
    private Animator anim;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));


        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
           transform.localScale = new Vector3(-1, 1, 1);

        }

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            
            transform.localScale = new Vector3(1, 1, 1);
        }   
    
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            PlaySound(1);
            rb2.AddForce(Vector2.up * jumpPower);
         
        }
    }
    

    void FixedUpdate()
    {
     
            float h = Input.GetAxisRaw("Horizontal");
        rb2.AddForce((Vector2.right * speed) * h);
        
        if (rb2.velocity.x > maxSpeed)
        {
            rb2.velocity = new Vector2(maxSpeed, rb2.velocity.y);
        }

        if (rb2.velocity.x < -maxSpeed)
        {
            rb2.velocity = new Vector2(-maxSpeed, rb2.velocity.y);
        }

    }

    void PlaySound(int clip)
    {
        Audio.clip = Audioclip[clip];
        Audio.Play();
    }

}
