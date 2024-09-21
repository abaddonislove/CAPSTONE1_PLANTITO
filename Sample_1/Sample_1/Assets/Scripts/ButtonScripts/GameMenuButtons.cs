using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsPanelObject;

    public void OptionsButtonPressed()
    {
        optionsPanelObject.SetActive(true);
    }

    public void GardenButtonPressed()
    {
        SceneManagerScript.Instance.GoToGarden();
    }

    public void HomeButtonPressed()
    {
        SceneManagerScript.Instance.GoToHome();
    }
}
