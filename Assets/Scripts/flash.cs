using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.UI;

namespace Flashlight
{
    public class flash : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public new Light2D light;
		[SerializeField] GameObject hud_flash;
		[SerializeField] GameObject hud_flash_center;
		[SerializeField] GameObject hud_inventory;
        public battery loading;
        private Inventory duration;
        
        void Start()
        {
            light.enabled = false;
            //
            duration = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                     
               
                 if (light.enabled == false && duration.isfull[0]==true)
                {
                  
                        light.enabled = true;
                        hud_flash.SetActive(true);
                        hud_flash_center.SetActive(true);
                        hud_inventory.SetActive(false);
                    }
                    else if (duration.isfull[0]==false)
                {
                    light.enabled = false;
                }
                else if (light.enabled == true)
                {
                    light.enabled = false;
                    hud_flash.SetActive(false);
                    hud_flash_center.SetActive(false);
                    hud_inventory.SetActive(true);
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