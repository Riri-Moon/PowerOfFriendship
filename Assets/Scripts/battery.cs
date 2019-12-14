using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Experimental.Rendering.LWRP;

public class battery : MonoBehaviour
{
    public Transform LoadingBar;
	[SerializeField] public float currentAmount;
	[SerializeField] public float speed;
    private Inventory duration;
    public Flashlight.flash Flash;
   public  PickItUp Des_name;
    float OriginalAmount;
    bool Ended;
    private void Start()
    {
        OriginalAmount = currentAmount;
        duration = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {       
        if (duration.isfull[0] == true 
            && Flash.light.enabled == true)
        {

            Flash.light.enabled = true;
    
            LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

            if (currentAmount > 0)
            {

                currentAmount -= speed * Time.deltaTime;
                Debug.Log(currentAmount);
            }

            if (LoadingBar.GetComponent<Image>().fillAmount <= 0)
            {
                Debug.Log("Prislo to sem");


                duration.isfull[0] = false;
                Flash.light.enabled = false;
                currentAmount = OriginalAmount;


                Debug.Log(LoadingBar.GetComponent<Image>().fillAmount);
            }
        }


    }




}
