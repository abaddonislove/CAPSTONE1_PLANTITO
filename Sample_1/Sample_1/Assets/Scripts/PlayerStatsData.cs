using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class PlayerStatsData
{
    public int money = 0;
    public int daysLived = 0;
    public int plantsDiscovered = 0;
    public int ResearchPoints = 0;

    public PlayerStatsData(PlayerStats _data)
    {
        money = _data.GetMoney();
        daysLived = _data.GetDaysLived();
        plantsDiscovered = _data.GetDaysLived();
        ResearchPoints = _data.GetResearchPoints();
    }
}
