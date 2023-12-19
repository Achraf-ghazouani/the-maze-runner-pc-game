using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public int scoreK = 0;
    public Text textScore;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score to 0
        scoreK = 0;

        // Update the text to show the initial score
        UpdateScoreText();
    }



    // Create a function that will add to the score when the player collects a key
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            Destroy(other.gameObject);
            scoreK += 1;
            UpdateScoreText();
            if (scoreK == 5)
            {
                Destroy(GameObject.FindWithTag("port"));
            }
        }
        if (other.gameObject.CompareTag("win"))
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
    }

    // Update the score text on the UI
    void UpdateScoreText()
    {
        textScore.text = "Score: " + scoreK.ToString();
    }

    // Function to restart the level with the index of the scene in the build settings
    public void RestartLevel()
    {
        // Get the current scene index
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Load the scene
        SceneManager.LoadScene(sceneIndex);
    }
}
