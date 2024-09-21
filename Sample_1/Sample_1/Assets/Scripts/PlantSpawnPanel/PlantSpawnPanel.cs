using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSpawnPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject pottedPlantPrefab;
    [SerializeField]
    private GameObject pottedPlantsContainer;

    private GameObject potContainer;
    private GameObject plantContainer;
    private Image potImage;
    private Image plantImage;
    private int potIndex = 0;
    private int plantIndex = 0;

    void Start()
    {
        potContainer = this.transform.GetChild(1).transform.GetChild(0).gameObject;
        plantContainer = this.transform.GetChild(1).transform.GetChild(1).gameObject;
        potImage = potContainer.GetComponent<Image>();
        plantImage = plantContainer.GetComponent<Image>();
        potImage.sprite = PlantManagerScript.Instance.pots[potIndex].potSprite;
        plantImage.sprite = PlantManagerScript.Instance.plants[plantIndex].plantSprite;
    }

    // Update is called once per frame
    void Update()
    {
        potImage.SetNativeSize();
        plantImage.SetNativeSize();
    }

    public void SwitchToNextPot()
    {
        potIndex += 1;

        if (potIndex >= PlantManagerScript.Instance.pots.Length)
        {
            potIndex = 0;
        }

        Sprite newPot = PlantManagerScript.Instance.pots[potIndex].potSprite;
        potImage.sprite = newPot;
    }

    public void SwitchToPreviousPot() 
    {
        potIndex -= 1;

        if (potIndex < 0)
        {
            potIndex = PlantManagerScript.Instance.pots.Length - 1;
        }

        Sprite newPot = PlantManagerScript.Instance.pots[potIndex].potSprite;
        potImage.sprite = newPot;
    }

    public void SwitchToNextPlant()
    {
        plantIndex += 1;

        if (plantIndex >= PlantManagerScript.Instance.plants.Length)
        {
            plantIndex = 0;
        }

        Sprite newPlant = PlantManagerScript.Instance.plants[plantIndex].plantSprite;
        plantImage.sprite = newPlant;
    }

    public void SwitchToPreviousPlant()
    {
        plantIndex -= 1;

        if (plantIndex < 0)
        {
            plantIndex = PlantManagerScript.Instance.plants.Length - 1;
        }

        Sprite newPlant = PlantManagerScript.Instance.plants[plantIndex].plantSprite;
        plantImage.sprite = newPlant;
    }

    public void SpawnPlant()
    {
        GameObject newPottedPlant = Instantiate(pottedPlantPrefab, pottedPlantsContainer.transform);
        newPottedPlant.transform.position = new Vector3(1, 5);
        newPottedPlant.GetComponent<PottedPlant>().potIndex = potIndex;
        newPottedPlant.GetComponent<PottedPlant>().plantIndex = plantIndex;
    }

    public void DragPanel()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePosition.x, mousePosition.y);
        //Debug.Log(mousePosition);
    }
}
