using UnityEngine;
using UnityEngine.UI;

public class GamePlayUnitUIWinLost : MonoBehaviour
{
    public UnitData unit;
    public Image icon;
    public void setup(UnitData unitData)
    {
        unit = unitData;
        icon.sprite=unitData.icon;
    }    
}
