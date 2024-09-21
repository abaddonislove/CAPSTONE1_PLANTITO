using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private PottedPlant plantPrefab;
    public static List<PottedPlant> plants = new List<PottedPlant>();

    const string PLANTS_SUB = "/Plants";
    const string PLANTS_COUNT_SUB = "/Plants.count";
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

        LoadPlant();
    }

/*    private void Awake()
    {
        LoadPlant();
    }*/

    private void OnApplicationQuit()
    {
        SavePlants();   
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
}
