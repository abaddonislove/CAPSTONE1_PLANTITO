using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    private GameObject optionsPanelObject;

    private void Awake()
    {
        optionsPanelObject = this.gameObject;
    }

    public void CloseButtonPressed()
    {
        optionsPanelObject.SetActive(false);
    }
}
