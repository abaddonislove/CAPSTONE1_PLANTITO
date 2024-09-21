using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant/Pot")]
public class Pot : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite potSprite;
}
