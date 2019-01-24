using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour {

    public void Buttons(string buttonName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(buttonName);
    }

    public void Change(string changeScene)
    {
        SceneManager.LoadScene(changeScene);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
