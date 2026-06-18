using UnityEngine;

[CreateAssetMenu(fileName = "CastleData", menuName = "Game Data/Castle")]
public class CastleData : ScriptableObject
{
    public string CastleName;
    public int ID;
    public int hp;
    public int Lv;
    public Sprite icon;
    public Sprite[] iconSkill;
    public string[] MoTaskill;
    [Header("Base")]
    public int HpPerLevel;

    public int coinUpgrade;
    public int baseGoldCost = 100;
    public int goldIncreasePerLevel = 100;

    public int Gold(int currentLevel)
    {
        coinUpgrade = baseGoldCost + goldIncreasePerLevel * (currentLevel-1);
        return coinUpgrade;
    }
}