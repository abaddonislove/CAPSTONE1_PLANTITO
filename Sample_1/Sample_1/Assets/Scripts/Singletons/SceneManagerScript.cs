using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance { get; private set; }

    private void Awake()
    {
        // Check if an instance already exists and if so, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance to this instance of the class
        Instance = this;

        // Optionally, make this singleton persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToGarden()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            SceneManager.LoadScene("GardenScene");
        }
    }

    public void GoToHome()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        { 
            SaveSystem.Instance.SavePlants();
            SceneManager.LoadScene("FirstScene");
        }
    }
}
