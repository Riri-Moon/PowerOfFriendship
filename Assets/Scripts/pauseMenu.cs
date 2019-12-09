using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject pauseMenuUI;
	
	[SerializeField] private GameObject hud;
		
	[SerializeField] private bool isPaused;
	
	[SerializeField] private GameObject player;
		
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
		}
		
		if(isPaused)
		{
			ActivateMenu();
		}
		
		else
		{
			DeactivateMenu();
		}
	}
	
	void ActivateMenu()
	{
		Time.timeScale= 0;
		AudioListener.pause=true;
		pauseMenuUI.SetActive(true);
		hud.SetActive(false);
		player.SetActive(false);
	}
	
	public void DeactivateMenu()
	{
		Time.timeScale=1;
		AudioListener.pause=false;
		pauseMenuUI.SetActive(false);
		isPaused = false;
		hud.SetActive(true);
		player.SetActive(true);
	}
}