using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Lamp_light : MonoBehaviour
{

    public new Light2D light;
    public float Min;
    float z = 115;
    public float Max;   
    public float speed;
    public bool GoRight = true;

    // Vector3 lightrotation;
    // Update is called once per frame

 
    void Right()
    {

       
        if (GoRight == true)
        {


                var lightrotation = new Vector3(0f, 0f, z);
                light.transform.eulerAngles = lightrotation;
                z += speed;
            if(z>=Max)
            GoRight = false;


        }
       if (GoRight == false)
        {

                var lightrotation = new Vector3(0f, 0f, z);
                light.transform.eulerAngles = lightrotation;
                z -= speed;
            if(z<=Min)
            GoRight = true;



        }

    }


    void LateUpdate()
    {

        Right();
  

    }



}
