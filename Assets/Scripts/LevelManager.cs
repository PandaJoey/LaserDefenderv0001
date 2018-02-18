using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public void loadLevel(string name) {
        Debug.Log("Level load request for " + name);
        SceneManager.LoadScene(name);
      


    }
    public void quitRequest() {
        Debug.Log("Quit Game Please");
        Application.Quit();
    }
    public void LoadNextLevel() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

}
