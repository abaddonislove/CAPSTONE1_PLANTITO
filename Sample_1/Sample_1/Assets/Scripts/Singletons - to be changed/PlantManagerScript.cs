using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManagerScript : MonoBehaviour
{
    public static PlantManagerScript Instance { get; private set; }

    [SerializeField]
    public Pot[] pots;
    public Plant[] plants;

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
}
