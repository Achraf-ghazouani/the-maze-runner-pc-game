using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //function to go to the next level 
    public void NextLevel1()
    {
        // Get the current scene index
        int sceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        // Load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex + 1);
    }

    //function to quit
    public void Quit()
    {
        Application.Quit();
    }
}
