using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {
    
    public static bool GamePaused = false;

    public GameObject PauseMenu;
    public GameObject ControlMenu;
    public GameObject SettingMenu;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }


    void Pause ()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }

    public void controlLoad ()
    {
        PauseMenu.SetActive(false);
        ControlMenu.SetActive(true);
    }

    public void controlReturn ()
    {
        ControlMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void settingLoad ()
    {
        PauseMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void settingReturn ()
    {
        SettingMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void returnMenu ()
    {
        //not sure if anything else needs to take place here
        SceneManager.LoadScene("Title");
    }

}