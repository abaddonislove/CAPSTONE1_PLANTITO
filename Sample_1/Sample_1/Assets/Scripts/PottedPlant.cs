using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PottedPlant : MonoBehaviour
{
    [SerializeField]
    public int potIndex;
    [SerializeField]
    public int plantIndex;

    private GameObject potContainer;
    private GameObject plantContainer;

    private void Awake()
    {
        SaveSystem.plants.Add(this);
    }

    void Start()
    {
        potContainer = this.transform.GetChild(0).gameObject;
        plantContainer = this.transform.GetChild(1).gameObject;

        potContainer.GetComponent<SpriteRenderer>().sprite = PlantManagerScript.Instance.pots[potIndex].potSprite;
        plantContainer.GetComponent<SpriteRenderer>().sprite = PlantManagerScript.Instance.plants[plantIndex].plantSprite;
    }

    private void OnDestroy()
    {
        SaveSystem.plants.Remove(this);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePosition.x, mousePosition.y);
    }
}
