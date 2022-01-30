using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///move to next scene

public class TitleScreen : MonoBehaviour {
    
    public GameObject Settings;
    public GameObject Title;

    public void PlayGame () 
    {
        SceneManager.LoadScene("Room1");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void SettingsLoad ()
    {
        Settings.SetActive(true);
        Title.SetActive(false);
    }

    public void SettingsReturn ()
    {
        Title.SetActive(true);
        Settings.SetActive(false);
    }
    
}
