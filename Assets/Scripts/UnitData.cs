using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="NewUnit",menuName ="Game/Unit Data")]
public class UnitData : ScriptableObject
{
    [Header("Thông tin")]
    public GameObject prelaf;
    public Sprite icon;
    public string Name;
    public int Id;
    public int cost;
    public int Cooldown;
    [Header("Chỉ số cơ bản")]
    public int Hp;
    public int dame;
    public int Level;
    public int damageReduction;
    public int LevelMax;
    [Header("Growth")]
    public int HpPerLevel;
    public int DamePerLevel;
    public int DamageReductionPerLevel;

    [Header("Nguyên liệu nâng cấp")]
    public int baseGoldCost = 100;
    public int goldIncreasePerLevel = 100;
    public LevelUpgradeCost[] levels;

    [Header("Skill")]
    public Sprite iconSkill;
    public string ThongTinSkill;

    [Header("Relic")]
    public TreasureType UnitId;
    public int Gold(int currentLevel)
    {
        return baseGoldCost + goldIncreasePerLevel * (currentLevel - 1);
    }
    public MaterialCost[] GetMaterialsCost(int currentLevel)
    {
        foreach(LevelUpgradeCost level in levels)
        {
            if(currentLevel>=level.start && currentLevel<level.end)
            {
               return level.materialCosts;
            }    
        }
        return null;
    }    
}
