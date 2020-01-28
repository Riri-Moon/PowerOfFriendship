using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Script : MonoBehaviour
{
    public GameObject Window;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Window.SetActive(false);
        }
    }
}
