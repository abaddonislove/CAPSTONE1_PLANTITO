using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEditorInternal;
using JetBrains.Annotations;
using UnityEngine.Playables;
using UnityEngine.Assertions.Must;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private PottedPlant plantPrefab;
    [SerializeField]
    private PlayerStats playerStatsPrefab;
    public static List<PottedPlant> plants = new List<PottedPlant>();
    public static PlayerStats playerStats = new PlayerStats();
    
    const string PLANTS_SUB = "/Plants";
    const string PLANTS_COUNT_SUB = "/Plants.count";
    const string PLAYERSTATS_SUB = "/PlayerStats";
    public static SaveSystem Instance { get; private set; }

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

        GeneratePlayerStats();
        LoadPlant();
        LoadPlayerStats();
    }

/*    private void Awake()
    {
        LoadPlant();
    }*/

    private void OnApplicationQuit()
    {
        SavePlants();   
        SavePlayerStats();
    }

    public void SavePlants()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PLANTS_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + PLANTS_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;

        FileStream countStream = new FileStream(countPath, FileMode.Create);

        formatter.Serialize(countStream, plants.Count);
        countStream.Close();

        for (int i = 0; i < plants.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            PottedPlantData data = new PottedPlantData(plants[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public void LoadPlant()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PLANTS_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + PLANTS_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;
        
        int plantCount = 0;

        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);

            plantCount = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }
        else
        {
            Debug.Log("Error! Path not found in " + countPath);
        }

        for (int i = 0; i < plantCount; i++)
        {
            if (File.Exists(path + i)) 
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                PottedPlantData data = formatter.Deserialize(stream) as PottedPlantData;

                stream.Close();

                Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);

                PottedPlant pottedPlant = Instantiate(plantPrefab, position, Quaternion.identity);
                pottedPlant.plantIndex = data.plantIndex;
                pottedPlant.potIndex = data.potIndex;
            }
            else
            {
                Debug.Log("Error! Path not found in " + path + i);
            }
        }
    }

    public void SavePlayerStats()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string playerStatsPath = Application.persistentDataPath + PLAYERSTATS_SUB + SceneManager.GetActiveScene().buildIndex;

        FileStream playerStatsStream = new FileStream(playerStatsPath, FileMode.Create);
        PlayerStatsData playerStatsData = new PlayerStatsData(playerStats);
        formatter.Serialize(playerStatsStream, playerStatsData);
        playerStatsStream.Close();
    }

    public void LoadPlayerStats()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string playerStatsPath = Application.persistentDataPath + PLAYERSTATS_SUB + SceneManager.GetActiveScene().buildIndex;

        if (File.Exists(playerStatsPath))
        {
            FileStream playerStatsStream = new FileStream(playerStatsPath, FileMode.Open);
            PlayerStatsData data = formatter.Deserialize(playerStatsStream) as PlayerStatsData;
            PlayerStats newPlayerStats = Instantiate(playerStatsPrefab);
            playerStats = newPlayerStats;

            Debug.Log(playerStatsPath + " " + data.money);
            playerStats.SetMoney(data.money);
            playerStats.SetDaysLived(data.daysLived);
            playerStats.SetPlantsDiscovered(data.plantsDiscovered);
            playerStats.SetResearchPoints(data.ResearchPoints);

        }
    }
    
    private void GeneratePlayerStats()
    {
        string playerStatsPath = Application.persistentDataPath + PLAYERSTATS_SUB + SceneManager.GetActiveScene().buildIndex;

        if (!File.Exists(playerStatsPath))
        {
            PlayerStats newPlayerStats = Instantiate(playerStatsPrefab);
            playerStats = newPlayerStats;
        }
    }
}
