using UnityEngine;

public class UnitRuntimeStats : MonoBehaviour
{
    public UnitData unitData;
    public int Level;
    public int dame;
    public int Hp;
    public float damageReduction;
    public void setup(UnitData data)
    {
        unitData = data;
        UnitRuntimeData runtime = UnitOwnedManager.Instance.GetRuntime(data.Id);
        if (runtime != null)
        {
            dame = UnitStatCalculator.getDame(data, runtime.Level);
            Hp = UnitStatCalculator.getHp(data, runtime.Level);
            damageReduction = UnitStatCalculator.getdamageReduction(data, runtime.Level);
            GetComponent<Heals_Linh>().currentHp = Hp;
            GetComponent<Heals_Linh>().maxHp = Hp;

            GetComponent<Attack>().dame = dame;
        }
    }    
}
