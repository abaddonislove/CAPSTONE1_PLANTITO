using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class PottedPlantData
{
    //public string name;
    public float[] position;
    public int plantIndex;
    public int potIndex;

    public PottedPlantData(PottedPlant _pottedPlant)
    {
        Vector3 plantPosition = _pottedPlant.transform.position;

        plantIndex = _pottedPlant.plantIndex;
        potIndex = _pottedPlant.potIndex;

        position = new float[]
        {
            plantPosition.x, plantPosition.y, plantPosition.z
        };
    }

}
