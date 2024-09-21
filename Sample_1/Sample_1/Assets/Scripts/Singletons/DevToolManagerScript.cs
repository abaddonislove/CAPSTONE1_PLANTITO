using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevToolManagerScript : MonoBehaviour
{
    public static DevToolManagerScript Instance { get; private set; }

    [SerializeField]
    private GameObject plantSpawnerPanel;

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
    }

    public void TogglePlantSpawnerPanel()
    {
        plantSpawnerPanel.SetActive(!plantSpawnerPanel.activeSelf);
    }
}
