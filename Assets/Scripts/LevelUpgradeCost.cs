using System;
using UnityEngine;

[Serializable]
public class LevelUpgradeCost
{
    public int start;
    public int end;
    public MaterialCost[] materialCosts;
    public float CostLv;
}
