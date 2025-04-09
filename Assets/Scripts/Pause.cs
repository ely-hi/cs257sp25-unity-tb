using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    //public Button resumeButton;
    
    void Awake()
    {
        pauseMenu.SetActive(false);
        //resumeButton.onClick.AddListener(OnResumePressed);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            //Curser.visible = true;
            //Curser.lockState = CurserLockMode.None;
            pauseMenu.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    void OnResumePressed()
    {
        pauseMenu.SetActive(false);
       // Time.timeScale = 1;
        //Curser.visible = false;
        //Curser.lockState = CurserLockMode.Locked;
    }

    private void OnDestroy() {
        Time.timeScale = 1;
    }
}
