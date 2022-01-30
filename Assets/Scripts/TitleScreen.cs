using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///move to next scene

public class TitleScreen : MonoBehaviour {

    public GameObject Settings;

    public void PlayGame () 
    {
        SceneManager.LoadScene("Room1");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void SettingsLoad ()
    {
        Settings.SetActive(true);
    }

    public void SettingsReturn ()
    {
        Settings.SetActive(false);
    }
    
}
