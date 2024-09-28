using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int money = 0;
    private int daysLived = 0;
    private int plantsDiscovered = 0;
    [SerializeField]
    private int ResearchPoints = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        SaveSystem.playerStats = null;
    }

    public int GetMoney() { return money; }

    public int GetDaysLived() { return daysLived; }

    public int GetPlantsDiscovered() { return plantsDiscovered; }

    public int GetResearchPoints() { return ResearchPoints; }

    public void SetMoney(int _money) { money = _money; }

    public void SetDaysLived(int _daysLived) { daysLived = _daysLived; }

    public void SetPlantsDiscovered(int _plantsDiscovered) { plantsDiscovered = _plantsDiscovered; }

    public void SetResearchPoints(int _ResearchPoints) { ResearchPoints = _ResearchPoints; } 
}
