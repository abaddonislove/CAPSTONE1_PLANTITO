using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant/Plant")]
public class Plant : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite plantSprite;
}
