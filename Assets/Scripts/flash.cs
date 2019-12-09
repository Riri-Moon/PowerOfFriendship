using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

namespace Flashlight
{
    public class flash : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public new Light2D light;
		[SerializeField] GameObject hud_flash;
		[SerializeField] GameObject hud_flash_center;
		[SerializeField] GameObject hud_inventory;
	
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
					hud_flash.SetActive (false);
					hud_flash_center.SetActive(false);
					hud_inventory.SetActive(true);
                }
                else if (light.enabled == false)
                {
                    light.enabled = true;
					hud_flash.SetActive (true);
					hud_flash_center.SetActive(true);
					hud_inventory.SetActive(false);
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