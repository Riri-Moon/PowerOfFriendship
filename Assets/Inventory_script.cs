using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Script : MonoBehaviour
{
	[SerializeField] private GameObject Inventory;

	[SerializeField] private GameObject hud;

	[SerializeField] private bool isPaused;

	[SerializeField] private GameObject player;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			isPaused = !isPaused;
		}

		if (isPaused)
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
		Time.timeScale = 0;
		AudioListener.pause = true;
		Inventory.SetActive(true);
		hud.SetActive(false);
		player.SetActive(false);
	}

	public void DeactivateMenu()
	{
		Time.timeScale = 1;
		AudioListener.pause = false;
		Inventory.SetActive(false);
		isPaused = false;
		hud.SetActive(true);
		player.SetActive(true);
	}
}