using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

namespace Flashlight
{
    public class flash : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        public new Light2D light;


        void Start()
        {

            light.enabled = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (light.enabled == true)
                {
                    light.enabled = false;
                }
                else if (light.enabled == false)
                {
                    light.enabled = true;
                }
            }
        }


        public bool IsToggled(Light2D light)
        {
            if (light.enabled == true)
                return true;
            else return false;
        }
    }
}
