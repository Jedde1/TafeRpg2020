using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pausePanel;
    public GameObject optionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        //Our Game to Run
        Time.timeScale = 1;
        //Cursor locked to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor is invisible
        Cursor.visible = false;
        //Hides Pause Panel
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!optionsPanel.activeSelf)
            {
                TogglePause();
            }
            else
            {
                pausePanel.SetActive(true);
                optionsPanel.SetActive(false);
            }
        }
    }

    public void TogglePause()
    {       
            isPaused = !isPaused;
            Debug.Log(isPaused);
            if (isPaused)
            {
                //Pauses Time in game
                Time.timeScale = 0;
                //Frees Cursor
                Cursor.lockState = CursorLockMode.Confined;
                //Makes Cursor Visible
                Cursor.visible = true;
                //Shows Pause Panel
                pausePanel.SetActive(true);
            }
            else
            {
                //Our Game to Run
                Time.timeScale = 1;
                //Cursor locked to middle of screen
                Cursor.lockState = CursorLockMode.Locked;
                //Cursor is invisible
                Cursor.visible = false;
                //Hides Pause Panel
                pausePanel.SetActive(false);
            }        
    }
}
