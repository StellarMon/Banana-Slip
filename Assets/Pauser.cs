using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.gameObject.activeInHierarchy)
        {
            PauseMenu.gameObject.SetActive (true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenu.gameObject.SetActive (false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }

    }

}
