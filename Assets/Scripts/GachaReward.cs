using UnityEngine;

[System.Serializable]
public class GachaReward
{
    public ItemData item;
    public UnitData unit;

    public int amount = 1;
    public float rate;

    public Sprite Icon
    {
        get
        {
            if (item != null) return item.Item;
            if (unit != null) return unit.icon;
            return null;
        }
    }

    public string Name
    {
        get
        {
            if (item != null) return item.Name;
            if (unit != null) return unit.Name;
            return "Unknown";
        }
    }
}