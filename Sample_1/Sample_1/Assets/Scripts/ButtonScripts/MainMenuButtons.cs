using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsPanelObject;

    public void StartButtonPressed()
    {
        SceneManagerScript.Instance.StartGame();
    }

    public void OptionsButtonPressed()
    {
        optionsPanelObject.SetActive(true);
    }

    public void ExitButtonPressed() 
    {
        Application.Quit();
    }
}
