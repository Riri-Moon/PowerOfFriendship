using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battery : MonoBehaviour
{
    public Transform LoadingBar;
	[SerializeField] public float currentAmount;
	[SerializeField] private float speed;
	
	void Update()
	{
	if (currentAmount>0) 
	{
		currentAmount-= speed* Time.deltaTime;
	}
		
	LoadingBar.GetComponent<Image>().fillAmount = currentAmount/100;	
	}
}
