using UnityEngine;

public static class UnitStatCalculator 
{
    public static int getHp(UnitData unit,int level)
    {
        return unit.Hp + unit.HpPerLevel * (level - 1);

    }
    public static int getDame(UnitData unit, int level)
    {
        return unit.dame+unit.DamePerLevel * (level - 1);   
    }
    public static int getdamageReduction(UnitData unit, int level)

    {
        return unit.damageReduction+unit.DamageReductionPerLevel * (level - 1);

    }
}
