using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
	
	[SerializeField] private GameObject pauseMenuUI;
	
	[SerializeField] private GameObject hud;
			
	[SerializeField] private GameObject musico;
		
	[SerializeField] private bool isPaused;
	
	[SerializeField] private GameObject player;
    [SerializeField] Vector3 offset;


    private void Start()
    {
        offset = (transform.position) - player.transform.position;
    }

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
	//	AudioListener.pause=true;
		pauseMenuUI.SetActive(true);
		hud.SetActive(false);
		player.SetActive(false);
		musico.SetActive(false);
	}
	
	public void DeactivateMenu()
	{
		Time.timeScale=1;
	//	AudioListener.pause=false;
		pauseMenuUI.SetActive(false);
		isPaused = false;
		hud.SetActive(true);
		player.SetActive(true);
		musico.SetActive(true);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
	
	public void RestartGame()
	{
		SceneManager.LoadScene(1);
	}
}